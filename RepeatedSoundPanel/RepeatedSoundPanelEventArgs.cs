using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundSystemControls
{
   public class RepeatedSoundPanelEventArgs
   {
		public RepeatedSoundPanel Panel { get; private set; }

		public RepeatedSoundPanelEventArgs(RepeatedSoundPanel panel)
      {
         Panel = panel;
      }     
   }
}
