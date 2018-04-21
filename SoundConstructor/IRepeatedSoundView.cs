using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundConstructor
{
   public interface IRepeatedSoundView
   {
      string Name { get; set; }
      string NameOfXmlParameterForVolume { get; set; }
      string NameOfXmlParameterForFrequency { get; set; }
      double ValueOfXmlParameterForVolume { get; set; }
      double ValueOfXmlParameterForFrequency { get; set; }

      string SoundFileLocation { get; set; }
      double VolumeOfRepeatedSound { get; set; }
      double FrequencyOfRepeatedSound { get; set; }

      void SetTableOfValuesForVolume();

      // These events are raised by View
      event EventHandler Play;
      event EventHandler Stop;
      event StringEventHandler NameChanged;
      event StringEventHandler NameOfXmlParameterForVolumeChanged;
      event StringEventHandler NameOfXmlParameterForFrequencyChanged;
      event DoubleEventHandler ValueOfXmlParameterForVolumeChanged;
      event DoubleEventHandler ValueOfXmlParameterForFrequencyChanged;
      event StringEventHandler SoundFileLocationChanged;
      event DoubleEventHandler VolumeChanged;
      event DoubleEventHandler FrequencyChanged;
   }
}
