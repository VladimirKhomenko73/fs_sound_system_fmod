namespace SoundSystemControls
{
   partial class RepeatedSoundPanel
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbDependenceFunction = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableOfValuesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataSet = new System.Data.DataSet();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.nameOfXmlParameterForEchoComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.nameOfXmlParameterForFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.selectSoundFileLocationButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nameOfXmlParameterForVolumeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.soundFileLocationTextBox = new System.Windows.Forms.TextBox();
            this.grp = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.valueOfXmlParameterForEchoTextBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.playPauseButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.valueOfXmlParameterForFrequencyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.frequencyTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblParameterValue = new System.Windows.Forms.Label();
            this.valueOfXmlParameterForVolumeTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.volumeTextBox = new System.Windows.Forms.TextBox();
            this.soundNameLabel = new System.Windows.Forms.Label();
            this.SoundTypeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableOfValuesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grp.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.mainChart);
            this.groupBox4.Controls.Add(this.cmbDependenceFunction);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tableOfValuesDataGridView);
            this.groupBox4.Location = new System.Drawing.Point(8, 258);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(774, 282);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Функция зависимости";
            // 
            // mainChart
            // 
            this.mainChart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.mainChart.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Lavender;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.White;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 90F;
            chartArea1.InnerPlotPosition.Width = 94.5F;
            chartArea1.InnerPlotPosition.X = 5.5F;
            chartArea1.InnerPlotPosition.Y = 3.5F;
            chartArea1.Name = "Default";
            this.mainChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.mainChart.Legends.Add(legend1);
            this.mainChart.Location = new System.Drawing.Point(262, 9);
            this.mainChart.Margin = new System.Windows.Forms.Padding(2);
            this.mainChart.Name = "mainChart";
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series1.BackImageTransparentColor = System.Drawing.SystemColors.ButtonFace;
            series1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series1.BorderWidth = 3;
            series1.ChartArea = "Default";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.CornflowerBlue;
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.SteelBlue;
            series1.MarkerColor = System.Drawing.Color.SteelBlue;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "VolumeSeries";
            series1.ShadowColor = System.Drawing.Color.DimGray;
            series1.ShadowOffset = 1;
            series2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series2.BackImageTransparentColor = System.Drawing.SystemColors.ButtonFace;
            series2.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            series2.BorderWidth = 3;
            series2.ChartArea = "Default";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.CornflowerBlue;
            series2.LabelBackColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.SteelBlue;
            series2.MarkerColor = System.Drawing.Color.SteelBlue;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series2.Name = "FrequencySeries";
            series2.ShadowColor = System.Drawing.Color.DimGray;
            series2.ShadowOffset = 1;
            this.mainChart.Series.Add(series1);
            this.mainChart.Series.Add(series2);
            this.mainChart.Size = new System.Drawing.Size(506, 265);
            this.mainChart.TabIndex = 18;
            this.mainChart.Text = "chart1";
            this.mainChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chrtMain_MouseDown);
            this.mainChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chrtMain_MouseMove);
            this.mainChart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chrtMain_MouseUp);
            // 
            // cmbDependenceFunction
            // 
            this.cmbDependenceFunction.Items.AddRange(new object[] {
            "(громкость)",
            "(частота)"});
            this.cmbDependenceFunction.Location = new System.Drawing.Point(96, 22);
            this.cmbDependenceFunction.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDependenceFunction.Name = "cmbDependenceFunction";
            this.cmbDependenceFunction.Size = new System.Drawing.Size(162, 21);
            this.cmbDependenceFunction.TabIndex = 17;
            this.cmbDependenceFunction.Text = "(не выбрано)";
            this.cmbDependenceFunction.SelectedIndexChanged += new System.EventHandler(this.cmbXmlParameters_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Функция для:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 50);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Точки графика:";
            // 
            // tableOfValuesDataGridView
            // 
            this.tableOfValuesDataGridView.AllowUserToResizeColumns = false;
            this.tableOfValuesDataGridView.AllowUserToResizeRows = false;
            this.tableOfValuesDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableOfValuesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableOfValuesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableOfValuesDataGridView.DataSource = this.dataSet;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableOfValuesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableOfValuesDataGridView.Location = new System.Drawing.Point(18, 70);
            this.tableOfValuesDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.tableOfValuesDataGridView.MultiSelect = false;
            this.tableOfValuesDataGridView.Name = "tableOfValuesDataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableOfValuesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tableOfValuesDataGridView.RowTemplate.Height = 24;
            this.tableOfValuesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableOfValuesDataGridView.Size = new System.Drawing.Size(240, 204);
            this.tableOfValuesDataGridView.TabIndex = 15;
            this.tableOfValuesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrTableOfValues_CellClick);
            this.tableOfValuesDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrTableOfValues_CellValueChanged);
            this.tableOfValuesDataGridView.SelectionChanged += new System.EventHandler(this.dtgrTableOfValues_SelectionChanged);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "NewDataSet";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox5);
            this.groupBox7.Controls.Add(this.groupBox6);
            this.groupBox7.Controls.Add(this.selectSoundFileLocationButton);
            this.groupBox7.Controls.Add(this.groupBox3);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.soundFileLocationTextBox);
            this.groupBox7.Location = new System.Drawing.Point(8, 34);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(774, 100);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Общие настройки";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.nameOfXmlParameterForEchoComboBox);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(456, 45);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(234, 48);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Эхо";
            // 
            // nameOfXmlParameterForEchoComboBox
            // 
            this.nameOfXmlParameterForEchoComboBox.Items.AddRange(new object[] {
            "(громкость)",
            "(частота)"});
            this.nameOfXmlParameterForEchoComboBox.Location = new System.Drawing.Point(100, 19);
            this.nameOfXmlParameterForEchoComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameOfXmlParameterForEchoComboBox.Name = "nameOfXmlParameterForEchoComboBox";
            this.nameOfXmlParameterForEchoComboBox.Size = new System.Drawing.Size(130, 21);
            this.nameOfXmlParameterForEchoComboBox.TabIndex = 18;
            this.nameOfXmlParameterForEchoComboBox.Text = "(не выбрано)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Имя параметра:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.nameOfXmlParameterForFrequencyTextBox);
            this.groupBox6.Location = new System.Drawing.Point(230, 45);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(222, 48);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Частота";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 20);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Имя параметра:";
            // 
            // nameOfXmlParameterForFrequencyTextBox
            // 
            this.nameOfXmlParameterForFrequencyTextBox.Location = new System.Drawing.Point(96, 16);
            this.nameOfXmlParameterForFrequencyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameOfXmlParameterForFrequencyTextBox.Name = "nameOfXmlParameterForFrequencyTextBox";
            this.nameOfXmlParameterForFrequencyTextBox.Size = new System.Drawing.Size(122, 20);
            this.nameOfXmlParameterForFrequencyTextBox.TabIndex = 1;
            this.nameOfXmlParameterForFrequencyTextBox.TextChanged += new System.EventHandler(this.NameOfXmlParameterForFrequencyTextBox_TextChanged);
            // 
            // selectSoundFileLocationButton
            // 
            this.selectSoundFileLocationButton.Location = new System.Drawing.Point(605, 16);
            this.selectSoundFileLocationButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectSoundFileLocationButton.Name = "selectSoundFileLocationButton";
            this.selectSoundFileLocationButton.Size = new System.Drawing.Size(85, 25);
            this.selectSoundFileLocationButton.TabIndex = 13;
            this.selectSoundFileLocationButton.Text = "Открыть";
            this.selectSoundFileLocationButton.UseVisualStyleBackColor = true;
            this.selectSoundFileLocationButton.Click += new System.EventHandler(this.SelectSoundFileLocationButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.nameOfXmlParameterForVolumeTextBox);
            this.groupBox3.Location = new System.Drawing.Point(4, 44);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(226, 49);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Громкость";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Имя параметра:";
            // 
            // nameOfXmlParameterForVolumeTextBox
            // 
            this.nameOfXmlParameterForVolumeTextBox.Location = new System.Drawing.Point(103, 17);
            this.nameOfXmlParameterForVolumeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameOfXmlParameterForVolumeTextBox.Name = "nameOfXmlParameterForVolumeTextBox";
            this.nameOfXmlParameterForVolumeTextBox.Size = new System.Drawing.Size(119, 20);
            this.nameOfXmlParameterForVolumeTextBox.TabIndex = 1;
            this.nameOfXmlParameterForVolumeTextBox.TextChanged += new System.EventHandler(this.NameOfXmlParameterForVolumeTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Звуковой файл:";
            // 
            // soundFileLocationTextBox
            // 
            this.soundFileLocationTextBox.Location = new System.Drawing.Point(95, 19);
            this.soundFileLocationTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.soundFileLocationTextBox.Name = "soundFileLocationTextBox";
            this.soundFileLocationTextBox.Size = new System.Drawing.Size(506, 20);
            this.soundFileLocationTextBox.TabIndex = 12;
            this.soundFileLocationTextBox.TextChanged += new System.EventHandler(this.SoundFileLocationTextBox_TextChanged);
            // 
            // grp
            // 
            this.grp.Controls.Add(this.groupBox8);
            this.grp.Controls.Add(this.stopButton);
            this.grp.Controls.Add(this.playPauseButton);
            this.grp.Controls.Add(this.groupBox2);
            this.grp.Controls.Add(this.groupBox1);
            this.grp.Location = new System.Drawing.Point(9, 138);
            this.grp.Margin = new System.Windows.Forms.Padding(2);
            this.grp.Name = "grp";
            this.grp.Padding = new System.Windows.Forms.Padding(2);
            this.grp.Size = new System.Drawing.Size(774, 133);
            this.grp.TabIndex = 20;
            this.grp.TabStop = false;
            this.grp.Text = "Тестирование звука";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.valueOfXmlParameterForEchoTextBox);
            this.groupBox8.Location = new System.Drawing.Point(14, 68);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(195, 47);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Эхо";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Значение параметра:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // valueOfXmlParameterForEchoTextBox
            // 
            this.valueOfXmlParameterForEchoTextBox.Location = new System.Drawing.Point(124, 19);
            this.valueOfXmlParameterForEchoTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.valueOfXmlParameterForEchoTextBox.Name = "valueOfXmlParameterForEchoTextBox";
            this.valueOfXmlParameterForEchoTextBox.Size = new System.Drawing.Size(60, 20);
            this.valueOfXmlParameterForEchoTextBox.TabIndex = 18;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(598, 93);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(99, 25);
            this.stopButton.TabIndex = 21;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // playPauseButton
            // 
            this.playPauseButton.Location = new System.Drawing.Point(598, 64);
            this.playPauseButton.Margin = new System.Windows.Forms.Padding(2);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(99, 25);
            this.playPauseButton.TabIndex = 14;
            this.playPauseButton.Text = "Воспроизвести";
            this.playPauseButton.UseVisualStyleBackColor = true;
            this.playPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.valueOfXmlParameterForFrequencyTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.frequencyTextBox);
            this.groupBox2.Location = new System.Drawing.Point(358, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(339, 48);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Частота";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Значение параметра:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // valueOfXmlParameterForFrequencyTextBox
            // 
            this.valueOfXmlParameterForFrequencyTextBox.Location = new System.Drawing.Point(119, 22);
            this.valueOfXmlParameterForFrequencyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.valueOfXmlParameterForFrequencyTextBox.Name = "valueOfXmlParameterForFrequencyTextBox";
            this.valueOfXmlParameterForFrequencyTextBox.Size = new System.Drawing.Size(79, 20);
            this.valueOfXmlParameterForFrequencyTextBox.TabIndex = 18;
            this.valueOfXmlParameterForFrequencyTextBox.TextChanged += new System.EventHandler(this.ValueOfXmlParameterForFrequencyTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Частота:";
            // 
            // frequencyTextBox
            // 
            this.frequencyTextBox.Location = new System.Drawing.Point(271, 22);
            this.frequencyTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.frequencyTextBox.Name = "frequencyTextBox";
            this.frequencyTextBox.Size = new System.Drawing.Size(60, 20);
            this.frequencyTextBox.TabIndex = 15;
            this.frequencyTextBox.TextChanged += new System.EventHandler(this.FrequencyTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblParameterValue);
            this.groupBox1.Controls.Add(this.valueOfXmlParameterForVolumeTextBox);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.volumeTextBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(339, 47);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Громкость";
            // 
            // lblParameterValue
            // 
            this.lblParameterValue.AutoSize = true;
            this.lblParameterValue.Location = new System.Drawing.Point(4, 22);
            this.lblParameterValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParameterValue.Name = "lblParameterValue";
            this.lblParameterValue.Size = new System.Drawing.Size(116, 13);
            this.lblParameterValue.TabIndex = 19;
            this.lblParameterValue.Text = "Значение параметра:";
            this.lblParameterValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // valueOfXmlParameterForVolumeTextBox
            // 
            this.valueOfXmlParameterForVolumeTextBox.Location = new System.Drawing.Point(119, 19);
            this.valueOfXmlParameterForVolumeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.valueOfXmlParameterForVolumeTextBox.Name = "valueOfXmlParameterForVolumeTextBox";
            this.valueOfXmlParameterForVolumeTextBox.Size = new System.Drawing.Size(79, 20);
            this.valueOfXmlParameterForVolumeTextBox.TabIndex = 18;
            this.valueOfXmlParameterForVolumeTextBox.TextChanged += new System.EventHandler(this.ValueOfXmlParameterForVolumeTextBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(202, 22);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 13;
            this.label16.Text = "Громкость:";
            // 
            // volumeTextBox
            // 
            this.volumeTextBox.Location = new System.Drawing.Point(271, 19);
            this.volumeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.volumeTextBox.Name = "volumeTextBox";
            this.volumeTextBox.Size = new System.Drawing.Size(60, 20);
            this.volumeTextBox.TabIndex = 15;
            this.volumeTextBox.TextChanged += new System.EventHandler(this.VolumeTextBox_TextChanged);
            // 
            // soundNameLabel
            // 
            this.soundNameLabel.AutoSize = true;
            this.soundNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.soundNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.soundNameLabel.Location = new System.Drawing.Point(9, 8);
            this.soundNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.soundNameLabel.Name = "soundNameLabel";
            this.soundNameLabel.Size = new System.Drawing.Size(187, 17);
            this.soundNameLabel.TabIndex = 19;
            this.soundNameLabel.Text = "Название источника звука";
            // 
            // SoundTypeComboBox
            // 
            this.SoundTypeComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Непрерывный",
            "Разовый"});
            this.SoundTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.SoundTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SoundTypeComboBox.FormattingEnabled = true;
            this.SoundTypeComboBox.Items.AddRange(new object[] {
            "Непрерывный",
            "Разовый"});
            this.SoundTypeComboBox.Location = new System.Drawing.Point(211, 7);
            this.SoundTypeComboBox.Name = "SoundTypeComboBox";
            this.SoundTypeComboBox.Size = new System.Drawing.Size(152, 21);
            this.SoundTypeComboBox.TabIndex = 22;
            this.SoundTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.SoundTypeComboBox_SelectedIndexChanged);
            // 
            // RepeatedSoundPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.SoundTypeComboBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.soundNameLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RepeatedSoundPanel";
            this.Size = new System.Drawing.Size(824, 578);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableOfValuesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grp.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.ComboBox cmbDependenceFunction;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.DataGridView tableOfValuesDataGridView;
      private System.Windows.Forms.GroupBox groupBox7;
      private System.Windows.Forms.GroupBox groupBox6;
      private System.Windows.Forms.Label label19;
      private System.Windows.Forms.TextBox nameOfXmlParameterForFrequencyTextBox;
      private System.Windows.Forms.Button selectSoundFileLocationButton;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox soundFileLocationTextBox;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox nameOfXmlParameterForVolumeTextBox;
      private System.Windows.Forms.GroupBox grp;
      private System.Windows.Forms.Button playPauseButton;
      private System.Windows.Forms.Label soundNameLabel;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.TextBox volumeTextBox;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox valueOfXmlParameterForFrequencyTextBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox frequencyTextBox;
      private System.Windows.Forms.Label lblParameterValue;
      private System.Windows.Forms.TextBox valueOfXmlParameterForVolumeTextBox;
      private System.Windows.Forms.DataVisualization.Charting.Chart mainChart;
		private System.Data.DataSet dataSet;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox valueOfXmlParameterForEchoTextBox;
		private System.Windows.Forms.ComboBox nameOfXmlParameterForEchoComboBox;
        private System.Windows.Forms.ComboBox SoundTypeComboBox;
   }
}
