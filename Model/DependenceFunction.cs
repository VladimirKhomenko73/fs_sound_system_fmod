using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public class DependenceFunction
   {
      SortedList<double, double> tableOfValues;
      
      public double GetY(double x)
      {
         double y;
         if (tableOfValues.TryGetValue(x, out y))
         {
            return y;
         }
         else
         {
            PiecewiseLinearApproximator approximator = new PiecewiseLinearApproximator();
            approximator.SetTableOfValues(tableOfValues);
            y = approximator.GetY(x);
            return y;
         }

      }

      public void SetTableOfValues(SortedList<double, double> tableOfValues)
      {
         this.tableOfValues = tableOfValues;
      }

      public SortedList<double, double> GetTableOfValues()
      {
         return tableOfValues;
      }
   }
}
