using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace SoundSystemControls
{
   public partial class RepeatedSoundPanel : UserControl
   {
		// Значения этих полей устанавливаются через соответствующие
		// свойства Presenter'ом. Они нужны для того, чтобы данный класс
		// не инициировал ложно события изменения (например, SoundNameChanged) 
		string soundName;
        /// <summary>
        /// Тип звука - непрерывный, разовый ...
        /// </summary>
        string soundType;
		string nameOfXmlParameterForVolume;
		string nameOfXmlParameterForFrequency;
		string nameOfXmlParameterForEcho;
		double valueOfXmlParameterForVolume;
		double valueOfXmlParameterForFrequency;
		double valueOfXmlParameterForEcho;
		double valueOfXmlParameterToEnableEchoFrom;
		double volume;
		double frequency;
		bool echo;
		string soundFileLocation;

      SortedList<double, double> tableOfValuesForVolume;
      SortedList<double, double> tableOfValuesForFrequency;
      DependentQuantity currentDependentQuantity;
      double currentTestXmlParameterForVolume;
      double currentTestXmlParameterForFrequency;
      double currentTestVolume;
      double currentTestFrequency;
      int middleTrackPoint = 51;

      public RepeatedSoundPanel()
      {
         InitializeComponent();
         tableOfValuesDataGridView.AutoGenerateColumns = true;
      }

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue("")]
      public string SoundName
      {
         get
         {
            return soundNameLabel.Text;
         }
         set
         {
				soundName = value;
            soundNameLabel.Text = value;
         }
      }

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue("")]
      public string NameOfXmlParameterForVolume
      {
         get
         {
            return this.nameOfXmlParameterForVolumeTextBox.Text;
         }
         set
         {
			nameOfXmlParameterForVolume = value;
            nameOfXmlParameterForVolumeTextBox.Text = value;
         }
      }

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue("")]
      public string SoundType
      {
          get
          {
              return this.SoundTypeComboBox.Text;
          }
          set
          {
              soundType = value;
              SoundTypeComboBox.Text = value;
          }
      }

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue("")]
      public string NameOfXmlParameterForFrequency
      {
         get
         {
            return this.nameOfXmlParameterForFrequencyTextBox.Text;
         }
         set
         {
				nameOfXmlParameterForFrequency = value;
            nameOfXmlParameterForFrequencyTextBox.Text = value;
         }
      }

		[Category("Repeated Sound Data"),
		Description(""),
		DefaultValue("")]
		public string NameOfXmlParameterForEcho
		{
			get
			{
				return nameOfXmlParameterForEchoComboBox.SelectedText;
			}
			set
			{
				nameOfXmlParameterForEcho = value;
				nameOfXmlParameterForEchoComboBox.SelectedText = value;
			}
		}

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue(0)]
      public double ValueOfXmlParameterForVolume
      {
         get
         {
            if (valueOfXmlParameterForVolumeTextBox.Text.Equals(String.Empty))
            {
               return 0;
            }
            else return Double.Parse(valueOfXmlParameterForVolumeTextBox.Text.Replace('.', ','));
         }
         set
         {
				valueOfXmlParameterForVolume = value;
            valueOfXmlParameterForVolumeTextBox.Text = value.ToString();
         }
      }

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue(0)]
      public double ValueOfXmlParameterForFrequency
      {
         get
         {
            if (valueOfXmlParameterForFrequencyTextBox.Text.Equals(String.Empty))
            {
               return 0;
            }
            else return Double.Parse(valueOfXmlParameterForFrequencyTextBox.Text.Replace('.', ','));
         }
         set
         {
				valueOfXmlParameterForFrequency = value;
            valueOfXmlParameterForFrequencyTextBox.Text = value.ToString();
         }
      }

		[Category("Repeated Sound Data"),
		Description(""),
		DefaultValue(0)]
		public double ValueOfXmlParameterForEcho
		{
			get
			{
				if (valueOfXmlParameterForFrequencyTextBox.Text.Equals(String.Empty))
				{
					return 0;
				}
				else return Double.Parse(valueOfXmlParameterForFrequencyTextBox.Text.Replace('.', ','));
			}
			set
			{
				valueOfXmlParameterForEcho = value;
				valueOfXmlParameterForFrequencyTextBox.Text = value.ToString();
			}
		}

		[Category("Repeated Sound Data"),
		Description(""),
		DefaultValue(0)]
		public double ValueOfXmlParameterToEnableEchoFrom
		{
			get
			{
				if (valueOfXmlParameterForFrequencyTextBox.Text.Equals(String.Empty))
				{
					return 0;
				}
				else return Double.Parse(valueOfXmlParameterForFrequencyTextBox.Text.Replace('.', ','));
			}
			set
			{
				valueOfXmlParameterToEnableEchoFrom = value;
				valueOfXmlParameterForFrequencyTextBox.Text = value.ToString();
			}
		}

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue("")]
      public string SoundFileLocation
      {
         get
         {
            return soundFileLocationTextBox.Text;
         }
         set
         {
				soundFileLocation = value;
            soundFileLocationTextBox.Text = value;
         }
      }

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue(0)]
      public double Volume
      {
         get
         {
            if (this.valueOfXmlParameterForVolumeTextBox.Text.Equals(String.Empty))
            {
               return 0;
            }
            else return Double.Parse(this.valueOfXmlParameterForVolumeTextBox.Text.Replace('.', ','));
         }
         set
         {
				volume = value;
            volumeTextBox.Text = value.ToString();
         }
      }

      [Category("Repeated Sound Data"),
      Description(""),
      DefaultValue(0)]
      public double Frequency
      {
         get
         {
            if (this.valueOfXmlParameterForFrequencyTextBox.Text.Equals(String.Empty))
            {
               return 0;
            }
            else return Double.Parse(this.valueOfXmlParameterForFrequencyTextBox.Text.Replace('.', ','));
         }
         set
         {
				frequency = value;
            frequencyTextBox.Text = value.ToString();
         }
      }

		[Category("Repeated Sound Data"),
		Description(""),
		DefaultValue(0)]
		public bool Echo { get; set; }

		[Category("Repeated Sound Data"),
		Description(""),
		DefaultValue(null)]
		public SortedList<double, double> TableOfValuesForVolume
		{
			get { return tableOfValuesForVolume; }
			set
			{
				tableOfValuesForVolume = value;
			}
		}

		[Category("Repeated Sound Data"),
		Description(""),
		DefaultValue(null)]
		public SortedList<double, double> TableOfValuesForFrequency
		{
			get { return tableOfValuesForFrequency; }
			set
			{
				tableOfValuesForFrequency = value;
			}
		}

      private void NameOfXmlParameterForVolumeTextBox_TextChanged(object sender, EventArgs e)
      {
         if (nameOfXmlParameterForVolumeTextBox.Text != nameOfXmlParameterForVolume)
         {
				RaiseNameOfXmlParameterForVolumeChangedEvent();
         }
         RefreshXmlParametersList();
      }
		
		private void NameOfXmlParameterForFrequencyTextBox_TextChanged(object sender, EventArgs e)
		{
			if (nameOfXmlParameterForFrequencyTextBox.Text != nameOfXmlParameterForFrequency)
			{
				RaiseNameOfXmlParameterForFrequencyChangedEvent();
			}
			RefreshXmlParametersList();
		}

		private void RaiseNameOfXmlParameterForVolumeChangedEvent()
		{
			if (NameOfXmlParameterForVolumeChanged != null)
			{
				NameOfXmlParameterForVolumeChanged(this, EventArgs.Empty);
			}
		}

        private void RaiseSoundTypeChangedEvent()
        {
            if (SoundTypeChanged != null)
            {
                SoundTypeChanged(this, EventArgs.Empty);
            }
        }

		private void RaiseNameOfXmlParameterForFrequencyChangedEvent()
		{
			if (NameOfXmlParameterForFrequencyChanged != null)
			{
				NameOfXmlParameterForFrequencyChanged(this, EventArgs.Empty);
			}
		}

		private void RaiseValueOfXmlParameterForVolumeChangedEvent()
		{
			if (ValueOfXmlParameterForVolumeChanged != null)
			{
				ValueOfXmlParameterForVolumeChanged(this, EventArgs.Empty);
			}
		}

		private void RaiseValueOfXmlParameterForFrequencyChangedEvent()
		{
			if (ValueOfXmlParameterForFrequencyChanged != null)
			{
				ValueOfXmlParameterForFrequencyChanged(this, EventArgs.Empty);
			}
		}

		private void RaiseSoundFileLocationChangedEvent(object sender)
		{
			if (SoundFileLocationChanged != null)
			{
				SoundFileLocationChanged(this, EventArgs.Empty);
			}
		}

		private void RaiseTableOfValuesForVolumeChangedEvent(object sender)
		{
			if (TableOfValuesForVolumeChanged != null)
			{
				TableOfValuesForVolumeChanged(this, EventArgs.Empty);
			}
		}

		private void RaiseTableOfValuesForFrequencyChangedEvent(object sender)
		{
			if (TableOfValuesForFrequencyChanged != null)
			{
				TableOfValuesForFrequencyChanged(this, EventArgs.Empty);
			}
		}

		private void RaisePlayEvent()
		{
			if (Play != null)
			{
				Play(this, EventArgs.Empty);
			}
		}

		private void RaisePauseEvent()
		{
			if (Pause != null)
			{
				Pause(this, EventArgs.Empty);
			}
		}

		private void RaiseStopEvent()
		{
			if (Stop != null)
			{
				Stop(this, EventArgs.Empty);
			}
		}


      private void RefreshXmlParametersList()
      {
         ComboBox.ObjectCollection xmlParameters = cmbDependenceFunction.Items;
			ComboBox.ObjectCollection echoParameters = nameOfXmlParameterForEchoComboBox.Items;
         string xmlVolumeParameterName = nameOfXmlParameterForVolumeTextBox.Text;
        /* if (xmlVolumeParameterName.Equals(String.Empty))
         {
            xmlParameters[0] = "(громкость)";
				echoParameters[0] = "(громкость)";
         }
         else
         {
            xmlParameters[0] = xmlVolumeParameterName;
				echoParameters[0] = xmlVolumeParameterName;
         }
         * */
         xmlParameters[0] = "(громкость)";
         echoParameters[0] = "(громкость)";

         string xmlFrequencyParameterName = nameOfXmlParameterForFrequencyTextBox.Text;
         /*
          if (xmlFrequencyParameterName.Equals(String.Empty))
         {
            xmlParameters[1] = "(частота)";
				echoParameters[1] = "(частота)";
         }
         else
         {
            xmlParameters[1] = xmlFrequencyParameterName;
				echoParameters[1] = xmlFrequencyParameterName;
         }
          * */
         xmlParameters[1] = "(частота)";
         echoParameters[1] = "(частота)";
      }

      private void SelectSoundFileLocationButton_Click(object sender, EventArgs e)
      {
         string soundFileLocation = SelectFileWithDialog();
         if (!String.IsNullOrEmpty(soundFileLocation))
         {
            soundFileLocationTextBox.Text = soundFileLocation;
            RaiseSoundFileLocationChangedEvent(sender);
         }
      }

      private string SelectFileWithDialog()
      {
         OpenFileDialog openFileDialog = new OpenFileDialog();
         openFileDialog.CheckPathExists = true;
         openFileDialog.CheckFileExists = true;
         openFileDialog.Multiselect = false;
         openFileDialog.Filter = GetOpenFileDialogFilter();

         DialogResult dialogResult = openFileDialog.ShowDialog();
         if (dialogResult == DialogResult.OK)
         {
            return openFileDialog.FileName;
         }
         else return String.Empty;
      }

      private string GetOpenFileDialogFilter()
      {
         return String.Concat(
                     "Звуковые файлы (все типы)|",
                        "*.asf;*.wm;*.wma;*.wmv;*.wmd;*.wav;*.snd;*.au;*.aif;*.aifc;",
                        "*.aiff;*.wma;*.mp2;*.mp3;*.adts;*.adt;*.aac|",
                     "Файл Windows Media (ASF) (*.asf;*.wm;*.wma;*.wmv;*.wmd)|",
                        "*.asf;*.wm;*.wma;*.wmv;*.wmd|",
                     "Файл аудио Windows (WAV) (*.wav;*.snd;*.au;*.aif;*.aifc;*.aiff;",
                        "*.wma;*.mp2;*.mp3;*.adts;*.adt;*.aac)|",
                        "*.wav;*.snd;*.au;*.aif;*.aifc;*.aiff;*.wma;*.mp2;*.mp3;*.adts;",
                        "*.adt;*.aac|",
                     "Все файлы (*.*)|*.*");
      }

      private void SoundFileLocationTextBox_TextChanged(object sender, EventArgs e)
      {
         if (soundFileLocationTextBox.Text != soundFileLocation &&
				SoundFileLocationChanged != null)
         {
            SoundFileLocationChanged(this, EventArgs.Empty);
         }
      }

      private void ValueOfXmlParameterForVolumeTextBox_TextChanged(object sender, EventArgs e)
      {
         //currentTestXmlParameterForVolume = Double.Parse(txtValueOfXmlParameterForVolume.Text);
         //if (currentDependentQuantity == DependentQuantity.Volume)
         //{
         //   UpdateXmlParameterForVolumeInTableOfValues();
         //}
         //if (TableOfValuesForVolumeChanged != null)
         //{
         //   RaiseTableOfValuesForVolumeChangedEvent(sender);
         //}
         try
         {
            //Double.Parse(txtValueOfXmlParameterForVolume.Text.Replace('.', ','));
            if (valueOfXmlParameterForVolumeTextBox.Text != valueOfXmlParameterForVolume.ToString())
            {
					RaiseValueOfXmlParameterForVolumeChangedEvent();
            }
         }
         catch (Exception exception)
         {

         }
      }

      private void ValueOfXmlParameterForFrequencyTextBox_TextChanged(object sender, EventArgs e)
      {
         //currentTestXmlParameterForFrequency = Double.Parse(txtValueOfXmlParameterForFrequency.Text);
         //if (currentDependentQuantity == DependentQuantity.Frequency)
         //{
         //   UpdateXmlParameterForFrequencyInTableOfValues();
         //}
         //if (TableOfValuesForFrequencyChanged != null)
         //{
         //   RaiseTableOfValuesForFrequencyChangedEvent(sender);
         //}

         try
         {
            //Double.Parse(txtValueOfXmlParameterForFrequency.Text.Replace('.', ','));
            if (valueOfXmlParameterForFrequencyTextBox.Text != valueOfXmlParameterForFrequency.ToString())
            {
					RaiseValueOfXmlParameterForFrequencyChangedEvent();
            }
         }
         catch (Exception exception)
         {

         }
      }

      private void UpdateCurrentTestVolume(double newTestVolume)
      {
         currentTestVolume = newTestVolume;
      }

      private void VolumeTextBox_TextChanged(object sender, EventArgs e)
      {
         try
         {
            currentTestVolume = Double.Parse(volumeTextBox.Text);
            if (currentDependentQuantity == DependentQuantity.Volume)
            {
               UpdateVolumeInTableOfValues();
            }
         }
         catch (Exception exception)
         {

         }
      }

      private void FrequencyTextBox_TextChanged(object sender, EventArgs e)
      {
         try
         {
            currentTestFrequency = Double.Parse(frequencyTextBox.Text);
            if (currentDependentQuantity == DependentQuantity.Frequency)
            {
               UpdateFrequencyInTableOfValues();
            }
         }
         catch (Exception exception)
         {

         }
      }     

      private bool ExistsInDataSet(double parameterValue)
      {
         foreach (DataRow row in dataSet.Tables[0].Rows)
         {
            if (row.ItemArray[0].Equals(parameterValue))
            {
               return true;
            }
         }
         return false;
      }

      private void UpdateVolumeInTableOfValues()
      {
         foreach (DataGridViewRow row in tableOfValuesDataGridView.Rows)
         {
            if (row.Index != (tableOfValuesDataGridView.Rows.Count - 1) &&
               row.Cells[0].Value.Equals(currentTestXmlParameterForVolume))
            {
               row.Cells[1].Value = currentTestVolume;
            }
         }
      }

      private void UpdateFrequencyInTableOfValues()
      {
         foreach (DataGridViewRow row in tableOfValuesDataGridView.Rows)
         {
            if (row.Index != (tableOfValuesDataGridView.Rows.Count - 1) &&
               row.Cells[0].Value.Equals(currentTestXmlParameterForFrequency))
            {
               row.Cells[1].Value = currentTestFrequency;
            }
         }
      }

      private void UpdateXmlParameterForVolumeInTableOfValues()
      {
         foreach (DataGridViewRow row in tableOfValuesDataGridView.Rows)
         {
            if (row.Index != (tableOfValuesDataGridView.Rows.Count - 1) &&
               row.Cells[1].Value.Equals(currentTestVolume))
            {
               row.Cells[0].Value = currentTestXmlParameterForVolume;
            }
         }
      }

      private void UpdateXmlParameterForFrequencyInTableOfValues()
      {
         foreach (DataGridViewRow row in tableOfValuesDataGridView.Rows)
         {
            if (row.Index != (tableOfValuesDataGridView.Rows.Count - 1) &&
               row.Cells[1].Value.Equals(currentTestFrequency))
            {
               row.Cells[0].Value = currentTestXmlParameterForFrequency;
            }
         }
      }
		
		private void StopButton_Click(object sender, EventArgs e)
		{
			RaiseStopEvent();
			ChangeToPlayButton();
            playPauseButton.Text = "Воспроизвести";
		}

      private void PlayPauseButton_Click(object sender, EventArgs e)
      {
			if (IsPlayButton(sender))
			{
				RaisePlayEvent();
				ChangeToPauseButton();
			}
			else if (IsPauseButton(sender))
			{
				RaisePauseEvent();
				ChangeToPlayButton();
			}
      }

      private bool IsPlayButton(object sender)
      {
         return ((Button)sender).Text.Equals("Воспроизвести");
      }

		private bool IsPauseButton(object sender)
		{
			return ((Button)sender).Text.Equals("Пауза");
		}
      
		private void ChangeToPlayButton()
		{
			playPauseButton.Text = "Воспроизвести";
		}

		private void ChangeToPauseButton()
		{
			playPauseButton.Text = "Пауза";
		}

      #region Код обработки таблицы и диаграммы

      /// <summary>
      /// Обработчик события SelectedIndexChanged
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void cmbXmlParameters_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetCurrentDependentQuantity();
         SetAppropriateChartSeries();
         ExportChartSeriesToDataSet();
         BindTableOfValuesToDataSet();
         SetSortedColumn();
      }

      private void SetAppropriateChartSeries()
      {
         if (currentDependentQuantity == DependentQuantity.Volume)
         {
            SetChartSeriesForVolume();
         }
         else if (currentDependentQuantity == DependentQuantity.Frequency)
         {
            SetChartSeriesForFrequency();
         }
         MakeOnlyAppropriateChartSeriesVisible();
      }

      private void MakeOnlyAppropriateChartSeriesVisible()
      {
         if (currentDependentQuantity == DependentQuantity.Volume)
         {
            mainChart.Series["VolumeSeries"].Enabled = true;
            mainChart.Series["FrequencySeries"].Enabled = false;
         }
         else if (currentDependentQuantity == DependentQuantity.Frequency)
         {
            mainChart.Series["VolumeSeries"].Enabled = false;
            mainChart.Series["FrequencySeries"].Enabled = true;
         }
      }

      private void SetCurrentDependentQuantity()
      {
        /* if (IsXmlParameterSelected(NameOfXmlParameterForVolume))
         {
            currentDependentQuantity = DependentQuantity.Volume;
         }
         else if (IsXmlParameterSelected(NameOfXmlParameterForFrequency))
         {
            currentDependentQuantity = DependentQuantity.Frequency;
         }
         * */
          if (cmbDependenceFunction.SelectedItem.ToString() == "(громкость)")
          {
              currentDependentQuantity = DependentQuantity.Volume;
          }
          else if (cmbDependenceFunction.SelectedItem.ToString() == "(частота)")
          {
              currentDependentQuantity = DependentQuantity.Frequency;
          }
      }

      private void SetChartSeriesForVolume()
      {
         IList<double> xs = tableOfValuesForVolume.Keys;
         IList<double> ys = tableOfValuesForVolume.Values;

         mainChart.Series["VolumeSeries"].Points.Clear();

         // Заполнить ряд (series) значениями
         for (int i = 0; i < xs.Count; i++)
         {
            mainChart.Series["VolumeSeries"].Points.AddXY(xs[i], ys[i]);
         }
      }

      private void SetChartSeriesForFrequency()
      {
         IList<double> xs = tableOfValuesForFrequency.Keys;
         IList<double> ys = tableOfValuesForFrequency.Values;

         mainChart.Series["FrequencySeries"].Points.Clear();

         // Заполнить ряд (series) значениями
         for (int i = 0; i < xs.Count; i++)
         {
            mainChart.Series["FrequencySeries"].Points.AddXY(xs[i], ys[i]);
         }
      }

      private void ExportChartSeriesToDataSet()
      {
         // Экспортировать значения всех рядов (series)
         dataSet = mainChart.DataManipulator.ExportSeriesValues();
      }

      private void BindTableOfValuesToDataSet()
      {
         // Привязать значения соответствующего ряда диаграммы к таблице
         tableOfValuesDataGridView.DataSource = dataSet;
         if (currentDependentQuantity == DependentQuantity.Volume)
         {
            tableOfValuesDataGridView.DataMember = "VolumeSeries";
         }
         else if (currentDependentQuantity == DependentQuantity.Frequency)
         {
            tableOfValuesDataGridView.DataMember = "FrequencySeries";
         }
      }

      private void SetSortedColumn()
      {
         DataGridViewColumn sortedColumn = tableOfValuesDataGridView.Columns[0];
         ListSortDirection direction = ListSortDirection.Ascending;
         tableOfValuesDataGridView.Sort(sortedColumn, direction);
      }
/*
      private bool IsXmlParameterSelected(string nameOfXmlParameter)
      {
         string nameOfSelectedXmlParameter = cmbDependenceFunction.SelectedItem.ToString();
         if (nameOfSelectedXmlParameter == nameOfXmlParameter)
         {
            return true;
         }
         else return false;
      }
       */


      /// <summary>
      /// Обработчик события CurrentValueChanged
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void dtgrTableOfValues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
      {
         // Обновить таблицу. Без этого метода происходит следующее:
         // 1) в некотором случае (когда введенное значение больше следующего в таблице 
         //    и когда для подтверждения ввода используется клавиша TAB) значения Х-ов в таблице
         //    отображаются не в порядке сортировки; 
         // 2) код ниже - dataView.Sort = "X ASC" - не производит сортировки значений в dataView;
         // 3) как следствие, в диаграмме новая точка всегда соединяется с последней, а не с теми,
         //    с которыми должна соединяться.
         RefreshTableOfValues();
         SetCurrentTestValues();

         DataView dataView = null;
         if (currentDependentQuantity == DependentQuantity.Volume)
         {
            // Обновить данные в диаграмме с помощью объекта DataSet, привязанного к таблице
            dataView = new DataView(dataSet.Tables["VolumeSeries"]);
            dataView.Sort = "X ASC";
            mainChart.Series["VolumeSeries"].Points.DataBindXY(dataView, "X", dataView, "Y");
         }
         else if (currentDependentQuantity == DependentQuantity.Frequency)
         {
            // Обновить данные в диаграмме с помощью объекта DataSet, привязанного к таблице
            dataView = new DataView(dataSet.Tables["FrequencySeries"]);
            dataView.Sort = "X ASC";
            mainChart.Series["FrequencySeries"].Points.DataBindXY(dataView, "X", dataView, "Y");
         }
         UpdateTablesOfValues();

         // Сделать диаграмму недействительной 
         mainChart.Invalidate();

      }

      private void RefreshTableOfValues()
      {
         // Обновление таблицы заключается в установке столбца, по которому производится сортировка
         SetSortedColumn();
      }

      private void dtgrTableOfValues_SelectionChanged(object sender, EventArgs e)
      {
         //SetCurrentTestValues();
      }

      private void SetCurrentTestValues()
      {
         SetCurrentTestXmlParameter();
         SetCurrentTestDependentQuantities();
      }

      private void SetCurrentTestXmlParameter()
      {
         if (IsTableOfValueNotEmpty() &&
            HasTableOfValuesSelectedRow() &&
            SelectedRowHasProperValues())
         {
            DataGridViewRow selectedRow = tableOfValuesDataGridView.SelectedRows[0];
            double value = (double)selectedRow.Cells[0].Value;
            if (currentDependentQuantity == DependentQuantity.Volume)
            {
               currentTestXmlParameterForVolume = value;
               valueOfXmlParameterForVolumeTextBox.Text = currentTestXmlParameterForVolume.ToString();
            }
            else if (currentDependentQuantity == DependentQuantity.Frequency)
            {
               currentTestXmlParameterForFrequency = value;
               valueOfXmlParameterForFrequencyTextBox.Text = currentTestXmlParameterForFrequency.ToString();
            }
         }
      }

      private void SetCurrentTestDependentQuantities()
      {
         if (IsTableOfValueNotEmpty() &&
            HasTableOfValuesSelectedRow() &&
            SelectedRowHasProperValues())
         {
            DataGridViewRow selectedRow = tableOfValuesDataGridView.SelectedRows[0];
            double value = (double)selectedRow.Cells[1].Value;
            if (currentDependentQuantity == DependentQuantity.Volume)
            {
               currentTestVolume = value;
               volumeTextBox.Text = currentTestVolume.ToString();
            }
            else if (currentDependentQuantity == DependentQuantity.Frequency)
            {
               currentTestFrequency = value;
               frequencyTextBox.Text = currentTestFrequency.ToString();
            }
         }
      }

      private bool IsTableOfValueNotEmpty()
      {
         if (tableOfValuesDataGridView.Rows.Count > 1)
         {

            return true;
         }
         else return false;
      }

      private bool HasTableOfValuesSelectedRow()
      {
         if (tableOfValuesDataGridView.SelectedRows.Count != 0)
         {
            return true;
         }
         else return false;
      }

      private bool SelectedRowHasProperValues()
      {
         DataGridViewRow selectedRow = tableOfValuesDataGridView.SelectedRows[0];
         object keyCellValue = selectedRow.Cells[0].Value;
         object valueCellValue = selectedRow.Cells[1].Value;
         try
         {
            Convert.ToDouble(keyCellValue);            
         }
         catch (Exception e)
         {
            return false;
         }
         try
         {
            Convert.ToDouble(valueCellValue);
         }
         catch (Exception e)
         {
            return false;
         }
         return true;
      }

      /// <summary>
      /// Выбранная в текущий момент точка данных
      /// </summary>
      private DataPoint selectedDataPoint = null;

      /// <summary>
      /// Обработчик события MouseDown
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void chrtMain_MouseDown(object sender, MouseEventArgs e)
      {
         // Вызвать метод Hit Test
         HitTestResult hitResult = mainChart.HitTest(e.X, e.Y);

         // Инициализировать выбранную в текущий момент точку данных
         selectedDataPoint = null;
         if (hitResult.ChartElementType == ChartElementType.DataPoint)
         {
            selectedDataPoint = (DataPoint)hitResult.Object;

            // Показать значение точки в метке (label)
            selectedDataPoint.IsValueShownAsLabel = true;

            // Установить форму курсора 
            mainChart.Cursor = Cursors.SizeNS;
         }
      }

      /// <summary>
      /// Обработчик события MouseMove
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void chrtMain_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         // Проверить, выбрана ли точка данных
         if (selectedDataPoint != null)
         {
            // Координаты курсора не должны быть вне пределов диаграммы
            int coordinate = e.Y;
            if (coordinate < 0)
               coordinate = 0;
            if (coordinate > mainChart.Size.Height - 1)
               coordinate = mainChart.Size.Height - 1;

            // Вычислить новое значение Y из текущей позиции курсора
            string seriesName = GetCurrentSeriesName();
            double yValue = mainChart.ChartAreas["Default"].AxisY.PixelPositionToValue(coordinate);
            yValue = Math.Min(yValue, mainChart.ChartAreas["Default"].AxisY.Maximum);
            yValue = Math.Max(yValue, mainChart.ChartAreas["Default"].AxisY.Minimum);

            if ((yValue <= 0) &&
               (mainChart.Series[seriesName].ChartType == SeriesChartType.Column))
            {
               yValue = 0.01;
            }

            int coordinateX = e.X;
            if (coordinateX < 0)
                coordinateX = 0;
            if (coordinateX > mainChart.Size.Width - 1)
                coordinateX = mainChart.Size.Width - 1;
            double xValue = mainChart.ChartAreas[0].AxisX.PixelPositionToValue(coordinateX);
            xValue = Math.Min(xValue, mainChart.ChartAreas[0].AxisX.Maximum);
            xValue = Math.Max(xValue, mainChart.ChartAreas[0].AxisX.Minimum);

            if ((xValue <= 0) &&
               (mainChart.Series[seriesName].ChartType == SeriesChartType.Column))
            {
                xValue = 0.01;
            }
            // Обновить значение Y выбранной точки данных
            selectedDataPoint.YValues[0] = yValue;
            selectedDataPoint.XValue = xValue;
            // Сделать диаграмму недействительной 
            mainChart.Invalidate();

            // Заставить диаграмму перерисоваться
            mainChart.Update();
         }
         else
         {
            // Установить другую форму курсора над точками данных
            HitTestResult hitResult = mainChart.HitTest(e.X, e.Y);
            if (hitResult.ChartElementType == ChartElementType.DataPoint)
            {
               mainChart.Cursor = Cursors.Hand;
            }
            else
            {
               mainChart.Cursor = Cursors.Default;
            }
         }
      }

      private string GetCurrentSeriesName()
      {
         string seriesName = "";
         if (currentDependentQuantity == DependentQuantity.Volume)
         {
            seriesName = "VolumeSeries";
         }
         else if (currentDependentQuantity == DependentQuantity.Frequency)
         {
            seriesName = "FrequencySeries";
         }
         return seriesName;
      }

      /// <summary>
      /// Обработчик события MouseUp
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void chrtMain_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         // Инициализировать выбранную в текущий момент точку данных
         if (selectedDataPoint != null)
         {
            // Спрятать метку (label) точки
            selectedDataPoint.IsValueShownAsLabel = false;

            // Сбросить значение выбранной точки данных
            selectedDataPoint = null;

            // Сделать диаграмму недействительной 
            mainChart.Invalidate();

            // Сбросить стиль курсора
            mainChart.Cursor = Cursors.Default;

            ExportChartSeriesToDataSet();
            BindTableOfValuesToDataSet();
            SetSortedColumn();
            UpdateTablesOfValues();
            SetCurrentTestValues();
         }
      }

      private void UpdateTablesOfValues()
      {
         if (currentDependentQuantity == DependentQuantity.Volume)
         {
            UpdateTableOfValuesForVolume();
         }
         else if (currentDependentQuantity == DependentQuantity.Frequency)
         {
            UpdateTableOfValuesForFrequency();
         }
      }

      private void UpdateTableOfValuesForVolume()
      {
         tableOfValuesForVolume.Clear();
         foreach (DataRow row in dataSet.Tables["VolumeSeries"].Rows)
         {
            try
            {
               double key = (double)row[0];
               double value = (double)row[1];
               tableOfValuesForVolume.Add(key, value);
            }
            catch (Exception e)
            {

            }
         }

			RaiseTableOfValuesForVolumeChangedEvent();
      }

      private void UpdateTableOfValuesForFrequency()
      {
         tableOfValuesForFrequency.Clear();
         foreach (DataRow row in dataSet.Tables["FrequencySeries"].Rows)
         {
            try
            {
               double key = (double)row[0];
               double value = (double)row[1];
               tableOfValuesForFrequency.Add(key, value);
            }
            catch (Exception e)
            {

            }
         }

			RaiseTableOfValuesForFrequencyChangedEvent();
      }

		private void RaiseTableOfValuesForVolumeChangedEvent()
		{
			if (TableOfValuesForVolumeChanged != null)
			{
				TableOfValuesForVolumeChanged(this, EventArgs.Empty);
			}
		}

		private void RaiseTableOfValuesForFrequencyChangedEvent()
		{
			if (TableOfValuesForFrequencyChanged != null)
			{
				TableOfValuesForFrequencyChanged(this, EventArgs.Empty);
			}
		}

      #endregion

      public event EventHandler SoundNameChanged;
      public event EventHandler SoundTypeChanged;
      public event EventHandler NameOfXmlParameterForVolumeChanged;
      public event EventHandler NameOfXmlParameterForFrequencyChanged;
      public event EventHandler ValueOfXmlParameterForVolumeChanged;
      public event EventHandler ValueOfXmlParameterForFrequencyChanged;
	  public event EventHandler SoundFileLocationChanged;
      public event EventHandler TableOfValuesForVolumeChanged;
      public event EventHandler TableOfValuesForFrequencyChanged;
      public event EventHandler Play;
	  public event EventHandler Pause;
      public event EventHandler Stop;

      private void dtgrTableOfValues_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         SetCurrentTestValues();
      }

      private void SoundTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
          if (SoundTypeComboBox.Text != SoundType)
          {
              RaiseNameOfXmlParameterForVolumeChangedEvent();
          }
          RefreshXmlParametersList();
      }
    }
}
