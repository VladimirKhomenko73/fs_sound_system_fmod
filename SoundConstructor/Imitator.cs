using System.Collections.Generic;
using System.ComponentModel;
using Model;
using Communicator;
using System;
using System.Threading;

namespace SoundConstructor
{
	class Imitator
	{
		static Imitator theInstance = new Imitator();

		Communicator.Communicator communicator;
		AudioPlayer audioPlayer;
		
        private List<Sound> sounds;

		internal static Imitator Instance
		{
			get { return theInstance; }
		}

		public Communicator.Communicator Communicator
		{
			set { communicator = value; }
		}

		public AudioPlayer AudioPlayer
		{
			set { audioPlayer = value; }
		}

		public List<Sound> Sounds
		{
			set { sounds = value; }
		}

		private Imitator()
		{
			
		}

		internal void StartImitation()
		{
			BindCommunicatorEventsWithHandlers();
			RegisterAllXmlParametersOfAllSounds();
			StartListeningToNetwork();
            audioPlayer.init();
		}

		private void BindCommunicatorEventsWithHandlers()
		{
			communicator.DataExchange += new EventHandler<EventArgs>(Communicator_DataExchange);
			//communicator.DataReceived += new EventHandler<EventArgs>(Communicator_DataReceived);
			//communicator.DataSent += new EventHandler<global::Communicator.Communicator.ParameterInfoEventArgs>(Communicator_DataSent);		
		}

		private void Communicator_DataExchange(object sender, EventArgs e)
		{
			UpdateAllXmlParametersValuesOfAllSounds();
			PlayAllSounds();
		}

/*		private void Communicator_DataSent(object sender, Communicator.Communicator.ParameterInfoEventArgs e)
		{
			UpdateAllXmlParametersValuesOfAllSounds();
			PlayAllSounds();
		}
 * */

/*		private void Communicator_DataReceived(object sender, EventArgs e)
		{
			UpdateAllXmlParametersValuesOfAllSounds();
			PlayAllSounds();
		}
*/
		private void RegisterAllXmlParametersOfAllSounds()
		{
			foreach (Sound sound in sounds)
			{
				foreach(Model.Parameter item in sound.VolumeParametersList)
                    communicator.AddParameter(item.Name, ParameterDirection.input);
				communicator.AddParameter(sound.FrequencyParameter.Name, ParameterDirection.input);
				//communicator.AddParameter(sound.NameOfXmlParameterForEcho, ParameterDirection.input);
			}
		}

		private void StartListeningToNetwork()
		{
			communicator.Start();
		}
		
		private void UpdateAllXmlParametersValuesOfAllSounds()
		{
			foreach (Sound sound in sounds)
			{
				foreach(Model.Parameter item in sound.VolumeParametersList)
                    item.Value = Convert.ToDouble(communicator.GetParameterValueByName(item.Name));
				sound.FrequencyParameter.Value =
					Convert.ToDouble(communicator.GetParameterValueByName(sound.FrequencyParameter.Name));
				//sound.ValueOfXmlParameterForEcho =
				//	Convert.ToDouble(communicator.GetParameterValueByName(sound.NameOfXmlParameterForEcho));
			}	
		}

		private void PlayAllSounds()
		{
			foreach (Sound sound in sounds)
			{
		        audioPlayer.Play(sound.Name, sound.Type, sound.Volume, sound.Frequency, sound.Echo, sound.SoundFile);
			}
		}

		internal void StopImitation()
		{
			StopListeningToNetwork();
			StopPlayingSounds();
		}

		private void StopPlayingSounds()
		{
			foreach (Sound sound in sounds)
			{
				audioPlayer.Stop(sound.Name);
			}
		}

		private void StopListeningToNetwork()
		{
			communicator.Stop();
		}
	}
}
