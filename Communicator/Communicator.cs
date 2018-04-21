using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using UdpTransceiver;
using ParametersParser;
using System.Net;
using System.Threading;
using Communicator.Properties;

namespace Communicator
{
	/// Перечислимые типы
	/// <summary>
	/// Виды параметров по направлению передачи - входные, выходные, комбинированные
	/// </summary>
	public enum ParameterDirection { input, output, inpout }
	/// <summary>
	/// Состояния коммуникатора
	/// </summary>
	public enum CommunicatorState { stoped, active }
	/// <summary>
	/// Тип узла - центральный узел, подчиненный узел
	/// </summary>
	public enum HostType { Master, Slave }
	/// <summary>
	/// Режим работы коммуникатора - только прием, приемопередача
	/// </summary>
	public enum CommunicationMode { Receiver, Transmitter, Transceiver }

	/// <summary>
	/// Класс-параметр обмена
	/// </summary>
	public class Parameter
	{
		/// <summary>
		/// Имя параметра
		/// </summary>
		public string Name;
		/// <summary>
		/// Значение параметра
		/// </summary>
		public string Value;
		/// <summary>
		/// Направление передачи значений параметра
		/// </summary>
		public ParameterDirection Direction;
		/// <summary>
		/// Время последнего обновления параметра
		/// </summary>
		public DateTime LastUpdateTime;
		/// <summary>
		/// Порядковый номер обновления параметра
		/// </summary>
		public Int64 UpdateCounter = 0;
		/// <summary>
		/// IP-адрес, с которого пришло последнее обновление
		/// </summary>
		public IPAddress LastIPReceiving;
		/// <summary>
		/// Порт, с которого пришло последнее обновление
		/// </summary>
		public int LastPortReceiving;
		/// <summary>
		/// Источник, с которого пришло последнее обновление
		/// </summary>
		public string LastSourceReceiver;
		/// <summary>
		/// Время последней отправки параметра
		/// </summary>
		public DateTime LastSendingTime;
		/// <summary>
		/// Порядковый номер отправки параметра
		/// </summary>
		public Int64 SendingCounter = 0;
		/// <summary>
		/// IP-адрес, на который произошла отправка в последний раз
		/// </summary>
		public IPAddress LastIPSending;
		/// <summary>
		/// Порт, с которого пришло последнее обновление
		/// </summary>
		public int LastPortSending;
		/// <summary>
		/// Получатель которому произошла отправка в последний раз
		/// </summary>
		public string LastTarget;

		/// <summary>
		/// Конструктор объекта- контейнера параметра
		/// </summary>
		/// <param name="Name">Имя параметра</param>
		/// <param name="Direction">Вид параметра по направлению передачи</param>
		public Parameter(string Name, ParameterDirection Direction)
		{
			this.Name = Name;
			this.Direction = Direction;
		}
	}

	/// <summary>
	/// Класс - коммуникатор. Обеспечивает обмен приложения с приложениями на удаленных узлах
	/// </summary>
	public class Communicator
	{
		/// <summary>
		/// Параметры соединения коммуникатора
		/// </summary>
		private static IPAddress localIP;
		private static IPAddress remoteIP;
		private static int localReceivingPort;
		private static int remoteReceivingPort;
		private static int localSendingPort;
		private static int remoteSendingPort;
		private HostType hostType;
		private CommunicationMode communicationMode;
		public CommunicatorState state;

		private string localApplicationName;
		private string remoteApplicationName;

		/// <summary>
		/// Период отсылки пакета от узла
		/// </summary>
		private int ExchangePeriod = 1000;

		private UDPTransceiver transceiver;

		private delegate void delTransmitter(UDPDatagram Datagram);

		/// <summary>
		/// Поток для работы коммуниктора
		/// </summary>
		Thread NetworkThread;
		/// <summary>
		/// Список параметров, которыми обменивается коммуникатор
		/// </summary>
		public List<Parameter> Parameters;

		private uint OutputParametersNumber = 0;
		private uint InputParametersNumber = 0;
		private bool hasInputParameterChanged;

		/// <summary>
		/// Конструктор коммуникатора
		/// </summary>
		public Communicator()
		{
			// TO DO Переделать под конфигуратор
			localIP = IPAddress.Parse(Settings.Default.localIP);
			remoteIP = IPAddress.Parse(Settings.Default.remoteIP);
			localReceivingPort = Convert.ToInt16(Settings.Default.localReceivingPort);
			remoteReceivingPort = Convert.ToInt16(Settings.Default.remoteReceivingPort); ;
			localSendingPort = Convert.ToInt16(Settings.Default.localSendingPort);
			remoteSendingPort = Convert.ToInt16(Settings.Default.remoteSendingPort);
			hostType = (HostType)Enum.Parse(typeof(HostType), Settings.Default.hostType);
			ExchangePeriod = Convert.ToInt16(Settings.Default.netExchangePeriod);
			communicationMode = (CommunicationMode)Enum.Parse(typeof(CommunicationMode), Settings.Default.communicationMode);
			localApplicationName = "Source";
			remoteApplicationName = "Target";
			state = CommunicatorState.stoped;

			transceiver = new UDPTransceiver(localIP, localReceivingPort, localSendingPort, remoteIP, remoteSendingPort, remoteSendingPort);

			// Создаем пустой список параметров.
			Parameters = new List<Parameter>();
			// Создаем поток для работы обменника
			if (hostType == HostType.Slave)
				NetworkThread = new Thread(ListenNetworkSlave);
			else
				NetworkThread = new Thread(ListenNetworkMaster);
			InputParameterChanged += (s, e) => hasInputParameterChanged = true;

		}

		/// <summary>
		/// Запускает в работу обменник
		/// </summary>
		public void Start()
		{
			state = CommunicatorState.active;
			if (NetworkThread.ThreadState == ThreadState.Aborted)
			{
				SetNetworkThread();
			}
			NetworkThread.Start();
		}

		/// <summary>
		/// Устанавливает поток для работы коммуникатора в зависимости от типа узла
		/// </summary>
		private void SetNetworkThread()
		{
			// Создаем поток для работы обменника
			if (hostType == HostType.Slave)
				NetworkThread = new Thread(ListenNetworkSlave);
			else NetworkThread = new Thread(ListenNetworkMaster);
		}

		/// <summary>
		/// Останавливает работу обменника
		/// </summary>
		public void Stop()
		{
			state = CommunicatorState.stoped;
			NetworkThread.Abort();
		}
		/// <summary>
		/// Добавление параметра в список для обмена
		/// </summary>
		/// <param name="Name">Имя нового параметра</param>
		/// <param name="Direction">Вид параметра по направлению передачи</param>
		public void AddParameter(string Name, ParameterDirection Direction)
		{
			Parameters.Add(new Parameter(Name, Direction));
			if (Direction == ParameterDirection.input || Direction == ParameterDirection.inpout)
				InputParametersNumber++;
			if (Direction == ParameterDirection.output || Direction == ParameterDirection.inpout)
				OutputParametersNumber++;
		}
		/// <summary>
		/// Удаление параметра из списка обменника по имени
		/// </summary>
		/// <param name="Name"></param>
		public void DeleteParameter(string parameterName)
		{
			Parameters.Remove(Parameters.Find(p => p.Name == parameterName));
		}

		/// <summary>
		/// Получение значения параметра в строковом виде по его имени
		/// </summary>
		/// <param name="parameterName">Имя параметра, под которым он был зарегистрирован в коммуникаторе</param>
		/// <returns>Значение параметра в виде строки</returns>
		public string GetParameterValueByName(string parameterName)
		{
			return Parameters.Find(p => p.Name == parameterName).Value;
		}

		/// <summary>
		/// Запись значения параметра по его имени
		/// </summary>
		/// <param name="parameterName">Имя параметра</param>
		/// <param name="Value">Значение</param>
		public void SetParameterValueByName(string parameterName, string Value)
		{
			Parameters.Find(p => p.Name == parameterName).Value = Value;
		}

		/// <summary>
		/// Анализатор приходящих информационных пакетов
		/// </summary>
		/// <param name="currentDatagram">Принятый пакет</param>
		private void ParseInfoPackage(UDPDatagram currentDatagram)
		{
			//Преобразуем датаграмму в сообщение
			var currentMessage = new ModelMessage(currentDatagram.MessageBody);
			// Перебираем все параметры из списка обменика
			foreach (Parameter Item in Parameters)
			{
				// Если параметр входящий или двунаправленый
				if (Item.Direction == ParameterDirection.input || Item.Direction == ParameterDirection.inpout)
				{
					// Пробуем выделить параметр с таким именем из входящего пакета
					var paramValue = currentMessage.GetParameter(Item.Name);
					// Если такой параметр есть в пакете обновляем атрибуты параметра в обменнике
					if (paramValue != null)
						lock (Item)
						{
							Item.Value = paramValue.ToString();
							Item.LastUpdateTime = DateTime.Now;
							Item.UpdateCounter++;
							//Item.LastIPReceiving = remoteIP;
							//Item.LastPortReceiving = remoteReceivingPort;
						}
				}
			}
		}

		/// <summary>
		/// Собирает пакет для отправки к моделирующему узлу
		/// </summary>
		/// <returns>Пакет для отправки</returns>
		private UDPDatagram CreateInfoPackage()
		{
			UDPDatagram Result = new UDPDatagram();
			ModelMessage Message = new ModelMessage();
			Message.Header_T = "VHost";
			Message.Header_S = DateTime.Now.ToString();

			HybridDictionary ParametersSet = new HybridDictionary();
			//HybridDictionary Entry = (HybridDictionary)GadgetsMessageQueue.Dequeue();
			uint PackageParameterCounter = 0;
			foreach (Parameter Item in Parameters)
			{
				if ((Item.Direction == ParameterDirection.output || Item.Direction == ParameterDirection.inpout)
					 && Item.Value != null)
				{
					ParametersSet.Add(Item.Name, Item.Value);
					Message.Parameters = ParametersSet; // TO DO ???
					Item.LastSendingTime = DateTime.Now;
					Item.SendingCounter++;
					//Item.LastIPSending = remoteIP;
					//Item.LastPortSending = remoteSendingPort;
					PackageParameterCounter++;
				}
			}
			Result.PackageType = PackageTypes.Info;
			Result.MessageBody = Message.ToString();
			//else
			//{
			//Если сообщений нет отправляем пустой пакет Ready
			//    Result.PackageType = PackageTypes.Ready;
			//    Result.MessageBody = String.Empty;
			//}

			return Result;
		}

		/// <summary>
		/// Формирует пакет "готовность к приему"
		/// </summary>
		/// <returns>Пакет для отправки</returns>
		private UDPDatagram CreateReadyPackage()
		{
			UDPDatagram Result = new UDPDatagram();
			ModelMessage Message = new ModelMessage();
			Message.Header_T = "VHost";
			Message.Header_S = DateTime.Now.ToString();

			HybridDictionary ParametersSet = new HybridDictionary();

			Result.PackageType = PackageTypes.Ready;
			Result.MessageBody = String.Empty;

			return Result;
		}


		public class ParameterInfoEventArgs : EventArgs
		{
			public Parameter ParameterInfo;
			public ParameterInfoEventArgs(Parameter parameter)
			{
				ParameterInfo = parameter;
			}
		}

		public event EventHandler<EventArgs> DataReceived;
		public event EventHandler<ParameterInfoEventArgs> DataSent;
		public event EventHandler<EventArgs> DataExchange;
		private event EventHandler<EventArgs> InputParameterChanged;

		private void OnInputParameterChanged()
		{
			if (InputParameterChanged != null)
				InputParameterChanged(this, EventArgs.Empty);
		}

		protected void OnDataExchange(EventArgs e)
		{
			if (DataExchange != null)
				DataExchange(this, e);
		}

		protected void OnDataReceived(EventArgs e)
		{
			if (DataReceived != null)
				DataReceived(this, e);
		}

		protected void OnDataSent(ParameterInfoEventArgs e)
		{
			if (DataSent != null)
				DataSent(this, e);
		}



		/*
		private void TransmittionComplete(IAsyncResult result)
		{
			 transceiver.Dispose();
		}
		*/
		/// <summary>
		/// Осуществляет обмен коммуникатора с удаленным узлом в режиме подчиненного узла
		/// </summary>
		private void ListenNetworkSlave()
		{
			while (state == CommunicatorState.active)
			{
				//Получаем датаграмму
				UDPDatagram currentDatagram = transceiver.ReceiveDatagram();

				//Console.WriteLine("{0} : Package of type {1} received.", DateTime.Now, currentDatagramm.PackageType);
				//Если пришел информационный пакет и включен режим приемопередатчика или приемника
				if (currentDatagram.PackageType == PackageTypes.Info &&
					 (communicationMode == CommunicationMode.Transceiver || communicationMode == CommunicationMode.Receiver))
				{
					ParseInfoPackage(currentDatagram);
				}
				// Если принятый пакет - это признак готовности главной машины к приему (Ready) и включен режим приемопередатчика или передатчика
				else if (currentDatagram.PackageType == PackageTypes.Ready &&
					 (communicationMode == CommunicationMode.Transceiver || communicationMode == CommunicationMode.Transmitter))
				{
					//InitializeTransmitter();
					UDPDatagram SendDatagram = CreateInfoPackage();
					transceiver.Send(SendDatagram);
					//delTransmitter TransmitterDelegate = new delTransmitter(transmitter.Send);
					//AsyncCallback TransmitterCallBack = new AsyncCallback(TransmittionComplete);
					//TransmitterDelegate.BeginInvoke(SendDatagram, TransmitterCallBack, null);

				}
				if (InputParametersNumber != 0 && hasInputParameterChanged)
				{
					OnDataReceived(EventArgs.Empty); // получены новые данные
					hasInputParameterChanged = false;
				}

				if (OutputParametersNumber != 0) // && currentDatagram.PackageType == PackageTypes.SendData
				{
					foreach (Parameter Item in Parameters)
					{
						if ((Item.Direction == ParameterDirection.output || Item.Direction == ParameterDirection.inpout) && Item.Value != null)
							OnDataSent(new ParameterInfoEventArgs(Item)); // отправлены данные
					}
				}

				OnDataExchange(EventArgs.Empty); // произошел цикл обмена
			}
		}
		/// <summary>
		/// Осуществляет обмен коммуникатора с удаленным узлом в режиме главного узла
		/// </summary>
		private void ListenNetworkMaster()
		{
			UDPDatagram SendDatagram;
			UDPDatagram ReadyDatagram;
			UDPDatagram CurrentDatagram;
			while (state == CommunicatorState.active)
			{
				Thread.Sleep(ExchangePeriod);
				// Формируем и отправляем инфо-пакет
				if ((communicationMode == CommunicationMode.Transceiver || communicationMode == CommunicationMode.Transmitter)
					 && OutputParametersNumber != 0)
				{
					SendDatagram = CreateInfoPackage();
					transceiver.Send(SendDatagram);
				}
				if ((communicationMode == CommunicationMode.Transceiver || communicationMode == CommunicationMode.Receiver)
					 && InputParametersNumber != 0)
				{
					// Формируем и отправляем пакет "готовность к приему"                
					ReadyDatagram = CreateReadyPackage();
					transceiver.Send(ReadyDatagram);
					//Получаем датаграмму
					CurrentDatagram = transceiver.ReceiveDatagram();
					//Если пришел информационный пакет
					if (CurrentDatagram.PackageType == PackageTypes.Info) ///????
					{
						ParseInfoPackage(CurrentDatagram);
					}
					if (hasInputParameterChanged)
					{
						OnDataReceived(EventArgs.Empty); // получены новые данные
						hasInputParameterChanged = false;
					}
				}
				OnDataExchange(EventArgs.Empty); // произошел цикл обмена
			}
		}
	}
}
