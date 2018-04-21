using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundConstructor
{
   public delegate void StringEventHandler(object sender, string value);
   public delegate void IntEventHandler(object sender, int value);
   public delegate void DoubleEventHandler(object sender, double value);
   public delegate void BoolEventHandler(object sender, bool value);
}
