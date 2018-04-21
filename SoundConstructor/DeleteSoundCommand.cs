using System.Collections.Generic;
using Model;

namespace SoundConstructor
{
	class DeleteSoundCommand : Command
	{
		private string soundName;
		private List<Sound> sounds;

		public DeleteSoundCommand(string soundName, List<Sound> Sounds)
		{
			this.soundName = soundName;
			this.sounds = Sounds;
		}

		public void Execute()
		{
			foreach (Sound sound in sounds)
			{
				if (sound.Name == soundName)
				{
					sounds.Remove(sound);
					return;
				}
			}
		}
	}
}
