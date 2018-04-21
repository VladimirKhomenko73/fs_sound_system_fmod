using System;
using System.Collections.Generic;

namespace SoundConstructor
{
    public interface View
    {
		 IList<string> NamesOfSounds { set; }

		 string NameOfSound { set; }
         string SoundType { set; }
		 string NameOfXmlParameterForVolume { set; }
		 string NameOfXmlParameterForFrequency { set; }
		 string NameOfXmlParameterForEcho { set; }
		 double ValueOfXmlParameterForVolume { set; }
		 double ValueOfXmlParameterForFrequency { set; }
		 double ValueOfXmlParameterForEcho { set; }
		 double ValueOfXmlParameterToEnableEchoFrom { set; }
		 double VolumeOfSound { set; }
		 double FrequencyOfSound { set; }
		 bool Echo { set; }
		 string SoundFileLocationOfSound { set; }
		 SortedList<double, double> TableOfValuesForVolume { set; }
		 SortedList<double, double> TableOfValuesForFrequency { set; }

		 bool ImitationIsRunning { set; }

		 Presenter Presenter { set; }
    }
}
