using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundConstructor
{
	class MockWindow 
	{
		public Presenter Presenter { private get; set; }

		private IList<string> namesOfRepeatedSounds;

		// Fields for repeated sound
		string nameOfRepeatedSound;
		string nameOfXmlParameterForVolume;
		string nameOfXmlParameterForFrequency;
		double valueOfXmlParameterForVolume;
		double valueOfXmlParameterForFrequency;
		double volumeOfRepeatedSound;
		double frequencyOfRepeatedSound;
		string soundFileLocationOfRepeatedSound;
		SortedList<double, double> tableOfValuesForVolume;
		SortedList<double, double> tableOfValuesForFrequency;

			
		public IList<string> NamesOfRepeatedSounds
		{
			private get { return namesOfRepeatedSounds; }
			set
			{
				namesOfRepeatedSounds = value;
			}
		}


		public string NameOfRepeatedSound
		{
			get { return nameOfRepeatedSound; }
			set
			{
				nameOfRepeatedSound = value;
			}
		}

		public string NameOfXmlParameterForVolume
		{
			get { return nameOfXmlParameterForVolume; }
			set
			{
				nameOfXmlParameterForVolume = value;
			}
		}

		public string NameOfXmlParameterForFrequency
		{
			get { return nameOfXmlParameterForFrequency; }
			set
			{
				nameOfXmlParameterForFrequency = value;
			}
		}

		public double ValueOfXmlParameterForVolume
		{
			get { return valueOfXmlParameterForVolume; }
			set
			{
				valueOfXmlParameterForVolume = value;
			}
		}

		public double ValueOfXmlParameterForFrequency
		{
			get { return valueOfXmlParameterForFrequency; }
			set
			{
				valueOfXmlParameterForFrequency = value;
			}
		}

		public double VolumeOfRepeatedSound
		{
			get { return volumeOfRepeatedSound; }
			set
			{
				volumeOfRepeatedSound = value;
			}
		}

		public double FrequencyOfRepeatedSound
		{
			get { return frequencyOfRepeatedSound; }
			set
			{
				frequencyOfRepeatedSound = value;
			}
		}

		public string SoundFileLocationOfRepeatedSound
		{
			get { return soundFileLocationOfRepeatedSound; }
			set
			{
				soundFileLocationOfRepeatedSound = value;
			}
		}

		public SortedList<double, double> TableOfValuesForVolume
		{
			get { return tableOfValuesForVolume; }
			set
			{
				tableOfValuesForVolume = value;
			}
		}

		public SortedList<double, double> TableOfValuesForFrequency
		{
			get { return tableOfValuesForFrequency; }
			set
			{
				tableOfValuesForFrequency = value;
			}
		}
	}
}
