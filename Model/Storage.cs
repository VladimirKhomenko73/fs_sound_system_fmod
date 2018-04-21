using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Collections;

namespace Model
{
	/// <summary>
	/// Этот класс содержит список одиночных воспроизводимых звуков и повторяемых звуков, а также файл со списком расположения аудио файлов
	/// </summary>
	/// <remarks>
	/// Инициализирует строку (string) хранилища размещений файлов 
	/// </remarks>
   public class Storage
   {
      /// <summary>
      /// Список всех звуков из хранилища
      /// </summary>
      public List<Sound> Sounds = new List<Sound>();
      /// <summary>
      /// Файл хранилища
      /// </summary>
      public string StorageFile;
      private XDocument document = new XDocument();

      public Storage()
      {
          StorageFile = Properties.Settings.Default.StorageFile;
      }


      /// <summary> 
      /// Загрузка данных о звуках в память и построение списка звуков. 
      /// </summary>
      public void Restore()
      {
          XDocument document = XDocument.Load(StorageFile);
          foreach (XElement item in document.Root.Elements("sound"))
          {
              Sound sound = new Sound()
              {
                  Name = item.Attribute("name").Value,
                  Type = item.Attribute("type").Value,
                  SoundFile = item.Element("soundFile").Value,
                  Position = item.Element("position").Value,
                 // VolumeParameterValue = Double.Parse(item.Element("valueOfXmlParameterForVolume").Value.Replace('.', ',')),
                 // FrequencyParameterValue = Double.Parse(item.Element("valueOfXmlParameterForFrequency").Value.Replace('.', ','))
              };

              foreach (XElement item2 in item.Element("volumeParameters").Elements("parameter"))
              {
                  SortedList<double, double> tableOfValues = new SortedList<double, double>();
                  foreach (XElement item3 in item2.Element("tableOfValues").Elements("entry"))
                  {
                      tableOfValues.Add((double)item3.Attribute("x"), (double)item3.Attribute("y"));
                  }
                  sound.VolumeParametersList.Add(new Parameter()
                  {
                      Name = (string)item2.Attribute("name"),
                      TableOfValues = tableOfValues
                  }
                  );
              }

              XElement item4 = item.Element("frequencyParameter");
              {
                  sound.FrequencyParameter.Name = (string)item4.Attribute("name");
                  SortedList<double, double> tableOfValues = new SortedList<double, double>();
                  foreach (XElement item5 in item4.Element("tableOfValues").Elements("entry"))
                  {
                      tableOfValues.Add((double)item5.Attribute("x"), (double)item5.Attribute("y"));
                  }
                  sound.FrequencyParameter.TableOfValues = tableOfValues;
              }
              Sounds.Add(sound);
          }

      }

      public void SaveSounds()
      {
         document.Save(StorageFile);
      }

      public List<Sound> GetSounds()
      {
        return Sounds;
      }

       /*
      private XElement GetRepeatedSoundsInXml(List<Sound> repeatedSounds)
      {
         List<XElement> soundsInXmlCollection = new List<XElement>();
         foreach (Sound sound in repeatedSounds)
         {
				XElement tableOfValuesForVolumeInXml = GetTableOfValuesForVolumeInXml(sound.TableOfValuesForVolume);
				XElement tableOfValuesForFrequencyInXml = GetTableOfValuesForFrequencyInXml(sound.TableOfValuesForFrequency);

            XElement soundInXml = new XElement("RepeatedSound",
               new XElement("Name", sound.Name),
               new XElement("SoundType", sound.Type),
               new XElement("ValueOfXmlParameterForVolume", sound.VolumeParameterValue),
               new XElement("ValueOfXmlParameterForFrequency", sound.FrequencyParameterValue),
               new XElement("SoundFileLocation", sound.SoundFile),
               tableOfValuesForVolumeInXml, tableOfValuesForFrequencyInXml);

            soundsInXmlCollection.Add(soundInXml);
         }
         XElement repeatedSoundsInXml = new XElement("RepeatedSounds", soundsInXmlCollection);
         return repeatedSoundsInXml;
      }
*/

       /* /// <summary>
		/// Этот метод создает таблицу значений громкости
		/// </summary>
		/// <remarks>
		/// Использует отсортированные списки
		/// Использует ключи
		/// </remarks>
		/// <param name="Entry ">Вход</param>
		/// <param name="Parameter">Параметр для ключа</param>
		/// <param name="Volume ">Громкость, целое от 0 до 100</param>
		/// <returns> таблицу значений громкости в Xml</returns>
      private XElement GetTableOfValuesForVolumeInXml(SortedList<double, double> tableOfValuesForVolume)
      {
         IList<double> keys = tableOfValuesForVolume.Keys;
         IList<double> values = tableOfValuesForVolume.Values;
         List<XElement> entries = new List<XElement>();
         foreach (Double key in keys)
         {
            int indexOfKey = keys.IndexOf(key);
            XElement entry = new XElement("Entry",
               new XElement("Parameter", key),
               new XElement("Volume", values[indexOfKey]));
            entries.Add(entry);
         }
         XElement tableOfValuesForVolumeInXml = new XElement("TableOfValuesForVolume", entries);
         return tableOfValuesForVolumeInXml;
      }
       */
/*		/// <summary> 
		/// Этот метод создает таблицу значений частоты
		/// </summary>
		/// <remarks>
		/// Использует отсортированные списки
		/// Использует ключи
		/// </remarks>
		/// <param name="Entry ">Вход</param>
		/// <param name="Parameter">Параметр для ключа</param>
		/// <param name="Frequency ">Частота, целое от 0 до 100</param>
		/// <returns> таблицу значений частоты в Xml</returns>
      private XElement GetTableOfValuesForFrequencyInXml(SortedList<double, double> tableOfValuesForFrequency)
      {
         IList<double> keys = tableOfValuesForFrequency.Keys;
         IList<double> values = tableOfValuesForFrequency.Values;
         List<XElement> entries = new List<XElement>();
         foreach (Double key in keys)
         {
            int indexOfKey = keys.IndexOf(key);
            XElement entry = new XElement("Entry",
               new XElement("Parameter", key),
               new XElement("Frequency", values[indexOfKey]));
            entries.Add(entry);
         }
         XElement tableOfValuesForFrequencyInXml = new XElement("TableOfValuesForFrequency", entries);
         return tableOfValuesForFrequencyInXml;
      }
*/
   }
}
