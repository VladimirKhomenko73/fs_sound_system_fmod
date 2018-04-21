using System;
using System.Collections.Generic;
using Model;

namespace SoundConstructor
{
	class AddNewRepeatedSoundCommand : Command
	{
		private List<Sound> sounds;
		private Sound sound;
		private string newSoundName = "Новый циклический звук";

		public AddNewRepeatedSoundCommand(Sound sound, List<Sound> sounds)
		{
			this.sound = sound;
			this.sounds = sounds;
		}

		public void Execute()
		{
			sound = new Sound();
			sound.Name = GetFinalNewSoundName();
			sounds.Add(sound);
		}

		private string GetFinalNewSoundName()
		{
			string proposalFinalSoundName = newSoundName;
			int index = 0;
			while (true)
			{
				Sound foundSound = sounds.Find(sound => sound.Name == proposalFinalSoundName);
				if (foundSound == null)
				{
					return proposalFinalSoundName;
				}
				else
				{
					index++;
					proposalFinalSoundName = String.Concat(newSoundName, index);
				}
			}
		}
	}
}
