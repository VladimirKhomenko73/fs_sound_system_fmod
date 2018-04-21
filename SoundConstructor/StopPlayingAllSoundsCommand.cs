using System.Collections.Generic;
using Model;

namespace SoundConstructor
{
	class StopPlayingAllSoundsCommand : Command
	{
		private List<Sound> repeatedSounds;
		private AudioPlayer audioPlayer;

		public StopPlayingAllSoundsCommand(List<Sound> repeatedSounds, AudioPlayer audioPlayer)
		{
			this.repeatedSounds = repeatedSounds;
			this.audioPlayer = audioPlayer;
		}

		public void Execute()
		{
			foreach (Sound sound in repeatedSounds)
			{
				audioPlayer.Stop(sound.Name);
			}
		}
	}
}
