namespace Model
{
   public class OnetimeSound
   {
      public string Name { get; set; }
      public string XmlParameterName { get; set; }
      
      private double xmlParameterValue;
      public double XmlParameterValue 
      {
         get { return xmlParameterValue; }
         set 
         {
            if (value == 1)
            {
               xmlParameterValue = value;
            }
            else 
            {
               xmlParameterValue = 0;
            }
         }
      }
      
		public double SpecifiedVolume { get; set; }
		public double SpecifiedFrequency { get; set; }

      public double Volume
      {
         get
         {
            if (XmlParameterValue == 1)
            {
               return SpecifiedVolume;
            }
            else return 0;
         }
      }

      public double Frequency
      {
         get
         {
            if (XmlParameterValue == 1)
            {
               return SpecifiedFrequency;
            }
            else return 0;
         }
      }

		public uint MaxDuration { get; set; }
		public bool BlockRepeat { get; set; }
		public string SoundFileLocation { get; set; }
   }
}
