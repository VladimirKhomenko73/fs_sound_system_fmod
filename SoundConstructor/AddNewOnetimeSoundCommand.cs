using System;
using System.Collections.Generic;
using Model;

namespace SoundConstructor
{
	class AddNewOnetimeSoundCommand : Command
	{
		private List<OnetimeSound> sounds;
		private OnetimeSound sound;
		private string newSoundName = "Новый одноразовый звук";

		public AddNewOnetimeSoundCommand(OnetimeSound sound, List<OnetimeSound> sounds)
		{
			this.sound = sound;
			this.sounds = sounds;
		}

		public void Execute()
		{
			sound = new OnetimeSound();
			sound.Name = GetFinalNewSoundName();
			sounds.Add(sound);
		}

		private string GetFinalNewSoundName()
		{
			string proposalFinalSoundName = newSoundName;
			int index = 0;
			while (true)
			{
 				OnetimeSound foundSound = sounds.Find(sound => sound.Name == proposalFinalSoundName);
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
