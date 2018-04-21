using System.Collections.Generic;
using Model;

namespace SoundConstructor
{
	class ChangeNameCommand : Command
	{
		private string oldNameOfSound;
		private string newNameOfSound;
		private List<Sound> sounds;

		public ChangeNameCommand(string oldNameOfSound, string newNameOfSound, 
			List<Sound> sounds)
		{
			this.oldNameOfSound = oldNameOfSound;
			this.newNameOfSound = newNameOfSound;
			this.sounds = sounds;
		}

		public void Execute()
		{
			object sound = GetSoundByName(oldNameOfSound);
			if (sound != null &&
				sound is Sound)
			{
				((Sound)sound).Name = newNameOfSound;
			}
		}

		private object GetSoundByName(string soundName)
		{
			foreach (Sound sound in sounds)
			{
				if (sound.Name == soundName)
				{
					return sound;
				}
			}
			return null;
		}
	}
}
