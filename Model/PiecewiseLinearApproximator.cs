using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   // Piecewise linear approximation - http://pers.narod.ru/study/methods/03.html#kli
   class PiecewiseLinearApproximator
   {
      SortedList<double, double> tableOfValues;

      public void SetTableOfValues(SortedList<double, double> tableOfValues)
      {
         this.tableOfValues = tableOfValues;
      }

      public double GetY(double x)
      {
         PiecewiseLinearApproximationData approximationData = GetApproximationData(x);
         LinearFunctionParameters linearFunctionParameters = new LinearFunctionParameters();
         linearFunctionParameters.X = x;
         double y = CalculateY(approximationData, linearFunctionParameters);
         return y;
      }

      private PiecewiseLinearApproximationData GetApproximationData(double x)
      {
         double previousExistingX = GetPreviousExistingX(x);
         double nextExistingX = GetNextExistingX(x);
         double yForPreviousExistingX;
         double yForNextExistingX;
         tableOfValues.TryGetValue(previousExistingX, out yForPreviousExistingX);
         tableOfValues.TryGetValue(nextExistingX, out yForNextExistingX);
         return new PiecewiseLinearApproximationData
         {
            PreviousExistingX = previousExistingX,
            NextExistingX = nextExistingX,
            YForPreviousExistingX = yForPreviousExistingX,
            YForNextExistingX = yForNextExistingX
         };
      }

      private double CalculateY(PiecewiseLinearApproximationData approximationData, LinearFunctionParameters linearFunctionParameters)
      {
         // y = k * x+ b
         linearFunctionParameters.K = GetK(approximationData);
         linearFunctionParameters.B = GetB(approximationData.YForPreviousExistingX, linearFunctionParameters.K, approximationData.PreviousExistingX);
         double y = linearFunctionParameters.K * linearFunctionParameters.X + linearFunctionParameters.B;
         return y;
      }

      private double GetK(PiecewiseLinearApproximationData approximationData)
      {
         // k = (f1 - f0)/(x1 - x0);
         double k = (approximationData.YForNextExistingX - approximationData.YForPreviousExistingX) /
            (approximationData.NextExistingX - approximationData.PreviousExistingX);
         return k;
      }

      private double GetB(double f0, double k, double x0)
      {
         // b = f0 - k * x0 ( or, which is equal, b = f1 - k * x1)          
         double b = f0 - k * x0;
         return b;
      }

      private double GetPreviousExistingX(double x)
      {
         IList<double> values = tableOfValues.Keys;
         double nextExistingX = GetNextExistingX(x);
         int indexOfNextExistingX = values.IndexOf(nextExistingX);
         int indexOfPreviousExistingX = indexOfNextExistingX - 1;
         double previousExistingX = values[indexOfPreviousExistingX];
         return previousExistingX;
      }

      private double GetNextExistingX(double x)
      {
         IList<double> values = tableOfValues.Keys;
         foreach (double currentX in values)
         {
            if (currentX > x)
            {
               return currentX;
            }
         }
         return 0;
      }
   }
}
