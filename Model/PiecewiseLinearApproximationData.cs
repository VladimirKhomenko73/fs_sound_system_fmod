using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   class PiecewiseLinearApproximationData
   {
      public double PreviousExistingX { get; set; }
      public double NextExistingX { get; set; }
      public double YForPreviousExistingX { get; set; }
      public double CurrentY { get; set; }
      public double YForNextExistingX { get; set; }
   }
}
