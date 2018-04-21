using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Communicator
{
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
}
