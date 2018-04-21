using System;
using System.Collections.Generic;
using System.ComponentModel;
using Model;
using Communicator;
using System.Threading;

namespace SoundConstructor
{
	public class Presenter
	{
		AudioPlayer audioPlayer = new AudioPlayer();
		Storage storage = new Storage();
		Communicator.Communicator communicator = new Communicator.Communicator();
		Imitator imitator = Imitator.Instance;
		View view;

		List<Sound> Sounds;

        Sound currentSound = new Sound();

		BackgroundWorker updateViewBackgroundWorker = new BackgroundWorker();
		bool imitationIsRunning;
		public Presenter(View view)
		{
			RestoreAllSounds();
			imitator.Communicator = communicator;
			imitator.AudioPlayer = audioPlayer;
			imitator.Sounds = Sounds;

            this.view = view;
			view.Presenter = this;
			view.NamesOfSounds = NamesOfRepeatedSounds;

			updateViewBackgroundWorker.DoWork +=
				new DoWorkEventHandler(UpdateView);
			updateViewBackgroundWorker.WorkerSupportsCancellation
				= true;
			updateViewBackgroundWorker.WorkerReportsProgress = true;
			updateViewBackgroundWorker.ProgressChanged +=
				new ProgressChangedEventHandler(updateViewBackgroundWorker_ProgressChanged);
           // communicator.DataExchange += new EventHandler<EventArgs>(Communicator_DataExchange);
		}
/*
        private void Communicator_DataExchange(object sender, EventArgs e)
        {
            UpdateView();
        }
        */
		void updateViewBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			UpdateView();
		}

		void UpdateView(object sender, DoWorkEventArgs e)
		{
			while (true)
			{
				Thread.Sleep(2000);
				updateViewBackgroundWorker.ReportProgress(0);
				if (updateViewBackgroundWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
			}
		}

		private void RestoreAllSounds()
		{
			storage.Restore();
			Sounds = storage.GetSounds();
		}

		public IList<string> NamesOfRepeatedSounds
		{
			get
			{
				IList<string> namesOfRepeatedSounds = new List<string>();
				foreach (Sound sound in Sounds)
				{
					namesOfRepeatedSounds.Add(sound.Name);
				}
				return namesOfRepeatedSounds;
			}
		}

		public string NameOfRepeatedSound
		{
			get { return currentSound.Name; }
			set
			{
				currentSound.Name = value;
				UpdateView();
			}
		}

        public string SoundType
        {
            get { return currentSound.Type; }
            set
            {
                currentSound.Type = value;
                UpdateView();
            }
        }

		
        public string NameOfXmlParameterForVolume
		{
			get { return currentSound.NameOfXmlParameterForVolume; }
			set
			{
				currentSound.NameOfXmlParameterForVolume = value;
				UpdateView();
			}
		}

		public string NameOfXmlParameterForFrequency
		{
			get { return currentSound.FrequencyParameter.Name; }
			set
			{
				currentSound.FrequencyParameter.Name = value;
				UpdateView();
			}
		}

		public string NameOfXmlParameterForEcho
		{
			get { return currentSound.EchoParameter.Name; }
			set
			{
                currentSound.EchoParameter.Name = value;
				UpdateView();
			}
		}

		public double ValueOfXmlParameterForVolume
		{
			get { return currentSound.ValueOfXmlParameterForVolume; }
			set
			{
				currentSound.ValueOfXmlParameterForVolume = value;
                audioPlayer.SetVolume(currentSound.Name,
                    currentSound.Volume);
				UpdateView();
			}
		}

		public double ValueOfXmlParameterForFrequency
		{
            get { return currentSound.FrequencyParameter.Value; ; }
			set
			{
                currentSound.FrequencyParameter.Value = value;
				audioPlayer.SetFrequency(currentSound.Name,
					currentSound.Frequency);
				UpdateView();
			}
		}

		public double ValueOfXmlParameterForEcho
		{
			get { return currentSound.EchoParameter.Value; }
			set
			{
                currentSound.EchoParameter.Value = value;
				audioPlayer.EnableEcho(currentSound.Name,
					currentSound.Echo);
				UpdateView();
			}
		}

		public double VolumeOfRepeatedSound
		{
			get { return currentSound.Volume; }
		}

		public double FrequencyOfRepeatedSound
		{
			get { return currentSound.Frequency; }
		}

		public string SoundFileLocationOfRepeatedSound
		{
			get { return currentSound.SoundFile; }
			set
			{
				currentSound.SoundFile = value;
				audioPlayer.SetSoundFileLocation(currentSound.Name,
					currentSound.SoundFile);
				UpdateView();
			}
		}

		public SortedList<double, double> TableOfValuesForVolume
		{
			get { return currentSound.TableOfValuesForVolume; }
			set
			{
				currentSound.TableOfValuesForVolume = value;
				UpdateView();
			}
		}

		public SortedList<double, double> TableOfValuesForFrequency
		{
			get { return currentSound.FrequencyParameter.TableOfValues; }
			set
			{
                currentSound.FrequencyParameter.TableOfValues = value;
				UpdateView();
			}
		}

		public bool ImitationIsRunning
		{
			get { return imitationIsRunning; }
			set
			{
				imitationIsRunning = value;
				if (imitationIsRunning)
				{
					imitator.StartImitation();
					updateViewBackgroundWorker.RunWorkerAsync();
				}
				else
				{
					imitator.StopImitation();
					updateViewBackgroundWorker.CancelAsync();
				}
				UpdateView();
			}
		}

		internal void UpdateView()
		{
                view.NameOfSound = NameOfRepeatedSound;
                view.SoundType = SoundType;
                view.NameOfXmlParameterForVolume = NameOfXmlParameterForVolume;
                view.NameOfXmlParameterForFrequency = NameOfXmlParameterForFrequency;
                //view.NameOfXmlParameterForEcho = NameOfXmlParameterForEcho;
                view.ValueOfXmlParameterForVolume = ValueOfXmlParameterForVolume;
                view.ValueOfXmlParameterForFrequency = ValueOfXmlParameterForFrequency;
                //view.ValueOfXmlParameterForEcho = ValueOfXmlParameterForEcho;
                view.VolumeOfSound = VolumeOfRepeatedSound;
                view.FrequencyOfSound = FrequencyOfRepeatedSound;
                view.SoundFileLocationOfSound = SoundFileLocationOfRepeatedSound;
                view.TableOfValuesForVolume = TableOfValuesForVolume;
                view.TableOfValuesForFrequency = TableOfValuesForFrequency;

                view.ImitationIsRunning = ImitationIsRunning;
 		}

		internal void OpenSound(string soundName)
		{
            if (IsNameOfRepeatedSound(soundName))
			{
				currentSound = (Sound)GetSoundByName(soundName);
			}

			UpdateView();
		}

		private object GetSoundByName(string soundName)
		{
			object sound = null;
			foreach (Sound aSound in Sounds)
			{
				if (aSound.Name == soundName)
				{
					sound = aSound;
				}
			}

			return sound;
		}


		private bool IsNameOfRepeatedSound(string soundName)
		{
			if (NamesOfRepeatedSounds.Contains(soundName))
			{
				return true;
			}
			else return false;
		}

		internal void AddRepeatedSound()
		{
			AddNewRepeatedSoundCommand command =
				new AddNewRepeatedSoundCommand(currentSound, Sounds);
			command.Execute();

			view.NamesOfSounds = NamesOfRepeatedSounds;
		}

		internal void ChangeName(string oldNameOfSound, string newNameOfSound)
		{
			ChangeNameCommand command =
				new ChangeNameCommand(oldNameOfSound, newNameOfSound, Sounds);
			command.Execute();
			UpdateView();
		}


		internal void PlayRepeatedSound(string soundName)
		{
			Sound sound = (Sound)GetSoundByName(soundName);
			audioPlayer.Play(sound.Name, sound.Type, sound.Volume, sound.Frequency,
				sound.Echo, sound.SoundFile);
		}

		internal void PauseSound(string soundName)
		{
			audioPlayer.Pause(soundName);
		}

		internal void StopSound(string soundName)
		{
			audioPlayer.Stop(soundName);
		}

		internal void SaveAllSounds()
		{
			storage.SaveSounds();
		}

		internal void DeleteSound(string soundName)
		{
			DeleteSoundCommand command =
				new DeleteSoundCommand(soundName, Sounds);
			command.Execute();
			UpdateView();
		}
	}
}
