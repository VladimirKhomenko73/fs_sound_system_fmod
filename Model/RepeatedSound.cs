using System;
using System.Collections.Generic;
namespace Model
{
     public class Parameter
    {
        public string Name;
        public SortedList<double, double> TableOfValues 
        {
            get { return dependenceFunction.GetTableOfValues(); }
			set { dependenceFunction.SetTableOfValues(value); }
        }
        public double Value;
        public DependenceFunction dependenceFunction = new DependenceFunction();
    
        public Parameter()
        {
         TableOfValues = new SortedList<double, double>(); 
        }
     }
    
    public class Sound
	{
		public string Name { get; set; }
        public string Type { get; set; }
        public string SoundFile { get; set; }
        public string Position { get; set; }

        /// <summary>
        /// Список параметров для громкости
        /// </summary>
        public List<Parameter> VolumeParametersList = new List<Parameter>();
        /// <summary>
        /// Параметр частоты
        /// </summary>
        public Parameter FrequencyParameter = new Parameter();

        public Parameter EchoParameter = new Parameter();

        //public double VolumeParameterValue;
        //public double FrequencyParameterValue; 

		public double Volume
		{
			get
			{
				try
				{
					double multiplicatedVolume = 1;
                    foreach (Parameter item in VolumeParametersList)
                        multiplicatedVolume = multiplicatedVolume * item.dependenceFunction.GetY(item.Value);
                    return 100 * multiplicatedVolume;
				}
				catch (Exception e)
				{
					return 0;
				}
			}
		}

		public double Frequency
		{
			get
			{
				try
				{
                    double frequency = FrequencyParameter.dependenceFunction.GetY(FrequencyParameter.Value);
					return 100 * frequency;
				}
				catch (Exception e)
				{
					return 0;
				}
			}
		}

        public string NameOfXmlParameterForVolume
        {
            get
            {
                try
                {
                    return VolumeParametersList[0].Name;
                }
                catch (Exception e)
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    VolumeParametersList[0].Name = value;
                }
                catch (Exception e)
                {
                    VolumeParametersList[0].Name = "";
                }
            }
        }

        public double ValueOfXmlParameterForVolume
        {
            get
            {
                try
                {
                    return VolumeParametersList[0].Value;
                }
                catch (Exception e)
                {
                    return 0;
                }
            }
            set
            {
                try
                {
                    VolumeParametersList[0].Value = value;
                }
                catch (Exception e)
                {
                    VolumeParametersList[0].Value = 0;
                }
            }
        }
        
             
       public SortedList<double, double> TableOfValuesForVolume
        {
            get
            {
                try
                {
                    return VolumeParametersList[0].TableOfValues;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    VolumeParametersList[0].TableOfValues = value;
                }
                catch (Exception e)
                {
                    VolumeParametersList[0].TableOfValues = null;
                }
            }
        }
		public bool Echo; 
		}


	}
