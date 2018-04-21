using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundConstructor
{
   public interface IOnetimeSoundView
   {
      string Name { get; set; }
      string XmlParameterName { get; set; }
      double XmlParameterValue { get; set; }
      string SoundFileLocation { get; set; }
      double MaxDuration { get; set; }
      bool BlockRepeat { get; set; }
      double Volume { get; set; }
      double Frequency { get; set; }

      // These events are raised by View
      event EventHandler Play;
      event EventHandler Stop;
      event StringEventHandler NameChanged;
      event StringEventHandler XmlParameterNameChanged;
      event DoubleEventHandler XmlParameterValueChanged;
      event StringEventHandler SoundFileLocationChanged;
      event DoubleEventHandler MaxDurationChanged;
      event BoolEventHandler BlockRepeatChanged;
      event DoubleEventHandler VolumeChanged;
      event DoubleEventHandler FrequencyChanged;
   }
}
