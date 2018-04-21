using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace UdpTransceiver
{

    /// <summary>
    /// UDP приемник
    /// </summary>
    [Serializable]
    [CLSCompliant(true)]
    public class UDPTransceiver : IDisposable
    {
        private UdpClient Receiver;
        private UdpClient Transmitter;

        private IPEndPoint RemoteSendingEndPoint;
        private IPEndPoint LocalReceivingEndPoint;
        private IPEndPoint RemoteReceivingEndPoint;
        private IPEndPoint LocalSendingEndPoint;

        private byte[] rawDatagram;
        public byte[] RawDatagram
        {
            get { return rawDatagram; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="HostIP">IP-адрес (кого слушаем)</param>
        /// <param name="HostPort">Номер порта</param>
        public UDPTransceiver(IPAddress LocalIP, int LocalReceivingPort, int LocalSendingPort,
                                IPAddress RemoteIP, int RemoteReceivingPort, int RemoteSendingPort)
        {
            LocalReceivingEndPoint = new IPEndPoint(LocalIP, LocalReceivingPort);
            if (LocalReceivingPort == LocalSendingPort)
                LocalSendingEndPoint = LocalReceivingEndPoint;
            else
                LocalSendingEndPoint = new IPEndPoint(LocalIP, LocalSendingPort);

            RemoteReceivingEndPoint = new IPEndPoint(RemoteIP, RemoteReceivingPort);
            if (RemoteReceivingPort == RemoteSendingPort)
                RemoteSendingEndPoint = RemoteReceivingEndPoint;
            else
                RemoteSendingEndPoint = new IPEndPoint(LocalIP, RemoteSendingPort);

            try
            {
                Receiver = new UdpClient(LocalReceivingEndPoint);
                if (LocalReceivingEndPoint == LocalSendingEndPoint)
                    Transmitter = Receiver;
                else
                    Transmitter = new UdpClient(LocalSendingEndPoint);

                Receiver.Client.ReceiveTimeout = 20;
                Transmitter.Client.SendTimeout = 10;
            }
            catch
            {
                ; // TODO
            }
        }

        /// <summary>
        /// Прием текстового сообщения
        /// </summary>
        /// <returns>string</returns>
        public string Recieve()
        {
            string Result = String.Empty;
            if (Receiver != null & RemoteSendingEndPoint != null)
            {
                try
                {
                    rawDatagram = Receiver.Receive(ref RemoteSendingEndPoint);
                    Result = Encoding.ASCII.GetString(RawDatagram);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentNullException("UDPClient, IPEndPoint", "not initialized");
            }
            return Result;
        }

        /// <summary>
        /// Прием сообщения в формате информационного пакеиа (тип-длина-тело)
        /// </summary>
        /// <returns>UDPDatagram</returns>
        public UDPDatagram ReceiveDatagram()
        {
            UDPDatagram Result = new UDPDatagram();
            if (Receiver != null & RemoteSendingEndPoint != null)
            {
                try
                {
                    rawDatagram = Receiver.Receive(ref RemoteSendingEndPoint);
                    Result.InitializeDatagram(rawDatagram);
                }
                catch (SocketException sex)
                {
                    //throw sex;  
                }
                catch (Exception ex)
                {
                    //throw ex;
                }
            }
            else
            {
                ; // throw new ArgumentNullException("UDPClient, IPEndPoint", "not initialized");
            }
            return Result;
        }

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                
                Receiver.Close();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #endregion


        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="Datagram">байт массив</param>
        public void Send(Byte[] Datagram)
        {
            if (Transmitter != null)
            {
                try
                {

                    Transmitter.Send(Datagram, Datagram.Length);

                }
                catch (Exception ex)
                {
                    throw ex;
                }                
            }
            else
            {
                throw new ArgumentNullException("UDPClient", "not initialized");
            }
        }

        /// <summary>
        /// Отправка сообщения (согласно протоколу)
        /// </summary>
        /// <param name="Datagram">Информационный пакет</param>
        public void Send(UDPDatagram Datagram)
        {

            if (Transmitter != null)
            {
                try
                {

                    byte[] Message = Datagram.ToByteArray();

                                                            
                    Transmitter.Send(Message, Message.Length, RemoteReceivingEndPoint);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            else
            {
                throw new ArgumentNullException("UDPClient", "not initialized");
            }
        
        }

        public void Send(UDPDatagram Datagram, string HostName, int Port)
        {

            if (Transmitter != null)
            {
                try
                {

                    byte[] Message = Datagram.ToByteArray();


                    Transmitter.Send(Message, Message.Length, HostName, Port);

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            else
            {
                throw new ArgumentNullException("UDPClient", "not initialized");
            }
        
        }


        #region IDisposable Members
/*
        public void Dispose()
        {
            try
            {
                
                Transmitter.Close();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        */
        

        #endregion
    }

    /// <summary>
    /// Информационный пакет 
    /// </summary>
    [Serializable]
    public class UDPDatagram
    {
        #region Properties

        /// <summary>
        /// Тип пакета
        /// </summary>
        private PackageTypes packageType;
        public PackageTypes PackageType
        {
            get { return packageType; }
            set { packageType = value; }
        }

        /// <summary>
        /// Длина пакета
        /// </summary>
        private Int16 packageLenght;
        public Int16 PackageLenght
        {
            
            get { return packageLenght; }
            
        }

        /// <summary>
        /// Тело сообщения
        /// </summary>
        private string messageBody;
        public string MessageBody
        {
            get { return messageBody; }
            set 
            { 
                messageBody = value; 
                
                packageLenght =  Int16.Parse( messageBody.Length.ToString() );
            }
        } 

        #endregion

        #region ctors

        public UDPDatagram()
        {
            packageType = PackageTypes.Undefined;

            MessageBody = String.Empty;

        }

        public UDPDatagram(byte[] Datagram)
        {
            InitializeDatagram(Datagram);

        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Инициализация полей класса
        /// </summary>
        /// <param name="Datagram"></param>
        public void InitializeDatagram(byte[] Datagram)
        {
            if (Datagram.Length >= 4)
            {
                try
                {
                    byte[] bType = new byte[] { Datagram[0], Datagram[1] };
                    byte[] bLenght = new byte[] { Datagram[2], Datagram[3] };

                    Int16 type = BitConverter.ToInt16(bType, 0);


                    packageType = (PackageTypes)type;

                    switch (packageType)
                    { 
                        case PackageTypes.Info:

                            #region Info package

                            packageLenght = BitConverter.ToInt16(bLenght, 0);

                            if (packageLenght != 0)
                            {
                                messageBody = Encoding.ASCII.GetString(Datagram, 4, Datagram.Length - 4);
                            }
                            else
                            {
                                messageBody = String.Empty;
                            } 

                            #endregion

                            break;

                        case PackageTypes.Ready:
                            break;

                        case PackageTypes.GetData:
                            break;

                        case PackageTypes.SendData:
                            break;

                        case PackageTypes.Undefined:
                            break;

                        default:

                            #region Default

                            packageType = PackageTypes.Undefined;
                            packageLenght = 0;
                            messageBody = "GeneratedBody: UDP datagramm was not correct format."; 

                            #endregion

                            break;
                    }

                    #region Old Code
                    //if (packageType != PackageTypes.Ready)
                    //{

                    //    packageLenght = BitConverter.ToInt16(bLenght, 0);

                    //    if (packageLenght != 0)
                    //    {
                    //        messageBody = Encoding.ASCII.GetString(Datagram, 4, Datagram.Length - 4);
                    //    }
                    //    else
                    //    {
                    //        messageBody = String.Empty;
                    //    }

                    //}
                    //else
                    //{
                    //    packageLenght = 0;
                    //    messageBody = String.Empty;
                    //} 
                    #endregion
                }
                catch (IndexOutOfRangeException ioex)
                {
                    throw new IndexOutOfRangeException("Ошибка при инициализации параметров информационного пакета.", ioex);
                }
                catch (InvalidCastException icex)
                {
                    throw new InvalidCastException("Ошибка преобразования типов при инициализации параметров информационного пакета", icex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка инициализации параметров информационного пакета", ex);
                }
            }
            else
            {
                throw new Exception("Полученный пакет некорректен или поврежден.");
            }
        }

        public override string ToString()
        {
            StringBuilder Result = new StringBuilder();
            Result.Append(packageType.ToString());
            Result.Append("|");
            Result.Append(packageLenght.ToString());
            Result.Append("|");
            Result.Append(messageBody);

            return Result.ToString();
        }

        public byte[] ToByteArray()
        {
            byte[] Result;

            byte[] arrType = BitConverter.GetBytes((Int16)PackageType);

            byte[] arrLenght = BitConverter.GetBytes(packageLenght);

            byte[] arrMessage = Encoding.ASCII.GetBytes(MessageBody);

            Result = new byte[arrType.Length + arrLenght.Length + arrMessage.Length];

            arrType.CopyTo(Result, 0);
            arrLenght.CopyTo(Result, arrType.Length);
            arrMessage.CopyTo(Result, arrType.Length + arrLenght.Length);

            return Result;
        } 

        #endregion

    }

    /// <summary>
    /// Типы пакетов
    /// </summary>
    public enum PackageTypes
    {
        Info = 0,
        Ready = 1,
        GetData = 2, 
        SendData = 3,
        Undefined = 4
    
    }
}
