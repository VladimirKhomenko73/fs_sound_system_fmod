using System;
using System.Collections.Generic;
using FMOD;

namespace Model
{
	public class AudioPlayer
	{
        Dictionary<string, int[]> sounds = new Dictionary<string, int[]>();
        Dictionary<string, float> soundsFreq = new Dictionary<string, float>();
        FMOD.RESULT result = FMOD.RESULT.OK;
        FMOD.System system = null;
        FMOD.Sound[] sound = new FMOD.Sound[2];
        FMOD.Channel[] channel = new FMOD.Channel[2];
        FMOD.DSP dsplowpass = null;
        FMOD.DSP dspflange = null;
        FMOD.DSP dspdistortion = null;
        FMOD.DSP dspecho = null;


        public void init()
        {
                result = FMOD.Factory.System_Create(ref system);
                result = system.init(128, FMOD.INITFLAGS.NORMAL, (IntPtr)null);
                result = system.createDSPByType(FMOD.DSP_TYPE.LOWPASS, ref dsplowpass);
                result = system.createDSPByType(FMOD.DSP_TYPE.FLANGE, ref dspflange);
                result = system.createDSPByType(FMOD.DSP_TYPE.DISTORTION, ref dspdistortion);
                result = system.createDSPByType(FMOD.DSP_TYPE.ECHO, ref dspecho);
        }
        /// <summary>
        /// Вызывает проигрывание циклического звука
        /// </summary>
        /// <param name="soundName"></param>
        /// <param name="volume"></param>
        /// <param name="frequency"></param>
        /// <param name="echo"></param>
        /// <param name="soundFileLocation"></param>
		public void Play(string soundName, string soundType, double volume, double frequency,
			bool echo, string soundFileLocation)
		{
            if (!SoundExists(soundName))
            {
                int[] indexes = new int[2];
                float mainFreq = 0;
                for (int i = 0; i < sound.Length; i++)
                {
                    if (soundType == "Непрерывный")
                        result = system.createStream(soundFileLocation, FMOD.MODE.LOOP_NORMAL, ref sound[i]);
                    else
                        result = system.createStream(soundFileLocation, FMOD.MODE.SOFTWARE, ref sound[i]);
                }
                if (result == RESULT.OK)
                {
                    for (int i = 0; i < channel.Length; i++)
                    {
                        result = system.playSound(FMOD.CHANNELINDEX.FREE, sound[i], false, ref channel[i]);
                        channel[i].getIndex(ref indexes[i]);
                    }
                    for (int i = 0; i < channel.Length; i++)
                    {
                            result = channel[i].setVolume(((float)volume));
                            channel[i].getFrequency(ref mainFreq);
                    }
                    result = channel[0].setPan(-1);
                    result = channel[1].setPan(1);
                    sounds.Add(soundName, indexes);
                    soundsFreq.Add(soundName, mainFreq);
                }
            }
            else
            {
                int[] inds;
                float freq;
                sounds.TryGetValue(soundName, out inds);
                soundsFreq.TryGetValue(soundName, out freq);
                for (int i = 0; i < channel.Length; i++)
                {
                    system.getChannel(inds[i], ref channel[i]);
                    //if (soundName.Contains("Стартер"))
                    //    result = channel[i].setVolume((float)1);
                    //else
                    result = channel[i].setVolume((float)(volume / 100));
                    if (freq / 100 * frequency < freq)
                        result = channel[i].setFrequency((float)(freq / 100 * frequency));
                }
            }
        }

		public void Pause(string soundName)
		{
			PausePlayback(soundName);
		}

		public void Stop(string soundName)
		{
			StopPlayback(soundName);
		}

		private bool SoundExists(string soundName)
		{
			return sounds.ContainsKey(soundName);
		}

		public void SetSoundFileLocation(string soundName, string soundFileLocation)
		{
			if (SoundExists(soundName))
			{
				//ZPlay player = GetPlayerBySoundName(soundName);
				//player.OpenFile(soundFileLocation, TStreamFormat.sfAutodetect);
			}
		}

		public void SetVolume(string soundName, double volume)
		{
            int[] inds;
            sounds.TryGetValue(soundName, out inds);
            if (SoundExists(soundName))
			{
                for (int i = 0; i < channel.Length; i++)
                {
                    system.getChannel(inds[i], ref channel[i]);
                    if(!soundName.Contains("Стартер"))
                        result = channel[i].setVolume((float)(volume/100));
                    else
                        result = channel[i].setVolume((float)1);
                }
            }
		}

		public void SetFrequency(string soundName, double frequency)
		{
            int[] inds;
            float freq;
            sounds.TryGetValue(soundName, out inds);
            soundsFreq.TryGetValue(soundName, out freq);
            if (SoundExists(soundName))
            {
                for (int i = 0; i < channel.Length; i++)
                {
                    system.getChannel(inds[i], ref channel[i]);
                    if (freq / 100 * frequency < freq)
                        result = channel[i].setFrequency((float)(freq/100*frequency));
                }
            }
		}
		
		public void EnableEcho(string soundName, bool enable)
		{
			if (SoundExists(soundName))
			{
			}
		}

		private void PausePlayback(string soundName)
		{
			if (SoundExists(soundName) &&
				IsSoundBeingPlayed(soundName))
			{
                int[] inds;
                sounds.TryGetValue(soundName, out inds);

                for (int i = 0; i < channel.Length; i++)
                {
                    system.getChannel(inds[i], ref channel[i]);
                }

                bool paused = false;
                for (int i = 0; i < channel.Length; i++)
                    result = channel[i].getPaused(ref paused);

                paused = !paused;
                for (int i = 0; i < channel.Length; i++)
                    result = channel[i].setPaused(paused);
            }
		}
		
		private void StopPlayback(string soundName)
		{
			if (SoundExists(soundName))
			{
                int[] inds;
                sounds.TryGetValue(soundName, out inds);
                for (int i = 0; i < channel.Length; i++)
                {
                    system.getChannel(inds[i], ref channel[i]);
                    if (channel[i] != null)
                    {
                        channel[i].stop();
                        channel[i] = null;
                    }
                }
                sounds.Remove(soundName);
            }
		}

		private bool IsSoundBeingPlayed(string soundName)
		{
            if (SoundExists(soundName))
            {
                bool ch1 = false, ch2 = false;
                int[] inds;
                sounds.TryGetValue(soundName, out inds);
                for (int i = 0; i < channel.Length; i++)
                {
                    system.getChannel(inds[i], ref channel[i]);
                    if (i == 0)
                        channel[0].isPlaying(ref ch1);
                    else
                        channel[1].isPlaying(ref ch2);
                }
                if (ch1 && ch2)
                    return true;
            }
			return false;
		}
	}
}
