namespace SoundConstructor
{
   partial class Window
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
          this.components = new System.ComponentModel.Container();
          System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Разовые");
          System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Циклические");
          System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Источники звуков", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.mnuStripFile = new System.Windows.Forms.MenuStrip();
          this.imitationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.splitContainer2 = new System.Windows.Forms.SplitContainer();
          this.mainTreeView = new System.Windows.Forms.TreeView();
          this.mainTabControl = new System.Windows.Forms.TabControl();
          this.tabPageForRepeatedSoundSettings = new System.Windows.Forms.TabPage();
          this.RepeatedSoundPanel1 = new SoundSystemControls.RepeatedSoundPanel();
          this.contextMenuForSoundTreeNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.mnuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuItemPlayStop = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuItemRename = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuItemSaveAll = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
          this.contextMenuForRootsOfSoundTreeNodes = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.mnuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          this.mnuStripFile.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
          this.splitContainer2.Panel1.SuspendLayout();
          this.splitContainer2.Panel2.SuspendLayout();
          this.splitContainer2.SuspendLayout();
          this.mainTabControl.SuspendLayout();
          this.tabPageForRepeatedSoundSettings.SuspendLayout();
          this.contextMenuForSoundTreeNodes.SuspendLayout();
          this.contextMenuForRootsOfSoundTreeNodes.SuspendLayout();
          this.SuspendLayout();
          // 
          // splitContainer1
          // 
          this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer1.IsSplitterFixed = true;
          this.splitContainer1.Location = new System.Drawing.Point(0, 0);
          this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
          this.splitContainer1.Name = "splitContainer1";
          this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this.mnuStripFile);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
          this.splitContainer1.Size = new System.Drawing.Size(1008, 609);
          this.splitContainer1.SplitterDistance = 25;
          this.splitContainer1.SplitterWidth = 3;
          this.splitContainer1.TabIndex = 0;
          // 
          // mnuStripFile
          // 
          this.mnuStripFile.BackColor = System.Drawing.SystemColors.Control;
          this.mnuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imitationMenuItem});
          this.mnuStripFile.Location = new System.Drawing.Point(0, 0);
          this.mnuStripFile.Name = "mnuStripFile";
          this.mnuStripFile.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
          this.mnuStripFile.Size = new System.Drawing.Size(1008, 24);
          this.mnuStripFile.TabIndex = 0;
          this.mnuStripFile.Text = "menuStrip1";
          // 
          // imitationMenuItem
          // 
          this.imitationMenuItem.Name = "imitationMenuItem";
          this.imitationMenuItem.Size = new System.Drawing.Size(68, 20);
          this.imitationMenuItem.Text = "Имитация";
          this.imitationMenuItem.Click += new System.EventHandler(this.imitationMenuItem_Click);
          // 
          // splitContainer2
          // 
          this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer2.Location = new System.Drawing.Point(0, 0);
          this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
          this.splitContainer2.Name = "splitContainer2";
          // 
          // splitContainer2.Panel1
          // 
          this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
          this.splitContainer2.Panel1.Controls.Add(this.mainTreeView);
          // 
          // splitContainer2.Panel2
          // 
          this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
          this.splitContainer2.Panel2.Controls.Add(this.mainTabControl);
          this.splitContainer2.Size = new System.Drawing.Size(1008, 581);
          this.splitContainer2.SplitterDistance = 195;
          this.splitContainer2.SplitterWidth = 3;
          this.splitContainer2.TabIndex = 0;
          // 
          // mainTreeView
          // 
          this.mainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.mainTreeView.FullRowSelect = true;
          this.mainTreeView.HideSelection = false;
          this.mainTreeView.ItemHeight = 18;
          this.mainTreeView.LabelEdit = true;
          this.mainTreeView.Location = new System.Drawing.Point(0, 0);
          this.mainTreeView.Margin = new System.Windows.Forms.Padding(2);
          this.mainTreeView.Name = "mainTreeView";
          treeNode1.Name = "";
          treeNode1.Text = "Разовые";
          treeNode2.Name = "";
          treeNode2.Text = "Циклические";
          treeNode3.Name = "ndSounds";
          treeNode3.Text = "Источники звуков";
          this.mainTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
          this.mainTreeView.ShowLines = false;
          this.mainTreeView.ShowNodeToolTips = true;
          this.mainTreeView.ShowRootLines = false;
          this.mainTreeView.Size = new System.Drawing.Size(195, 581);
          this.mainTreeView.TabIndex = 2;
          this.mainTreeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.mainTreeView_BeforeLabelEdit);
          this.mainTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.mainTreeView_AfterLabelEdit);
          this.mainTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mainTreeView_NodeMouseClick);
          // 
          // mainTabControl
          // 
          this.mainTabControl.Controls.Add(this.tabPageForRepeatedSoundSettings);
          this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
          this.mainTabControl.HotTrack = true;
          this.mainTabControl.Location = new System.Drawing.Point(0, 0);
          this.mainTabControl.Margin = new System.Windows.Forms.Padding(2);
          this.mainTabControl.Name = "mainTabControl";
          this.mainTabControl.SelectedIndex = 0;
          this.mainTabControl.Size = new System.Drawing.Size(810, 581);
          this.mainTabControl.TabIndex = 4;
          this.mainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.mainTabControl_Selected);
          // 
          // tabPageForRepeatedSoundSettings
          // 
          this.tabPageForRepeatedSoundSettings.BackColor = System.Drawing.SystemColors.Control;
          this.tabPageForRepeatedSoundSettings.Controls.Add(this.RepeatedSoundPanel1);
          this.tabPageForRepeatedSoundSettings.Location = new System.Drawing.Point(4, 22);
          this.tabPageForRepeatedSoundSettings.Margin = new System.Windows.Forms.Padding(2);
          this.tabPageForRepeatedSoundSettings.Name = "tabPageForRepeatedSoundSettings";
          this.tabPageForRepeatedSoundSettings.Size = new System.Drawing.Size(802, 555);
          this.tabPageForRepeatedSoundSettings.TabIndex = 1;
          this.tabPageForRepeatedSoundSettings.Text = "Циклический";
          // 
          // RepeatedSoundPanel1
          // 
          this.RepeatedSoundPanel1.AutoScroll = true;
          this.RepeatedSoundPanel1.BackColor = System.Drawing.SystemColors.Control;
          this.RepeatedSoundPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.RepeatedSoundPanel1.Echo = false;
          this.RepeatedSoundPanel1.Frequency = 0D;
          this.RepeatedSoundPanel1.Location = new System.Drawing.Point(0, 0);
          this.RepeatedSoundPanel1.Margin = new System.Windows.Forms.Padding(2);
          this.RepeatedSoundPanel1.Name = "RepeatedSoundPanel1";
          this.RepeatedSoundPanel1.Size = new System.Drawing.Size(802, 555);
          this.RepeatedSoundPanel1.SoundName = "Название источника звука";
          this.RepeatedSoundPanel1.TabIndex = 0;
          this.RepeatedSoundPanel1.ValueOfXmlParameterForEcho = 0D;
          this.RepeatedSoundPanel1.ValueOfXmlParameterForFrequency = 0D;
          this.RepeatedSoundPanel1.ValueOfXmlParameterForVolume = 0D;
          this.RepeatedSoundPanel1.ValueOfXmlParameterToEnableEchoFrom = 0D;
          this.RepeatedSoundPanel1.Volume = 0D;
          this.RepeatedSoundPanel1.Load += new System.EventHandler(this.RepeatedSoundPanel1_Load);
          // 
          // contextMenuForSoundTreeNodes
          // 
          this.contextMenuForSoundTreeNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemOpen,
            this.toolStripSeparator4,
            this.mnuItemPlayStop,
            this.toolStripSeparator5,
            this.mnuItemRename,
            this.toolStripSeparator6,
            this.mnuItemSaveAll,
            this.toolStripSeparator1,
            this.mnuItemDelete});
          this.contextMenuForSoundTreeNodes.Name = "contextMenuStrip1";
          this.contextMenuForSoundTreeNodes.Size = new System.Drawing.Size(264, 138);
          // 
          // mnuItemOpen
          // 
          this.mnuItemOpen.Name = "mnuItemOpen";
          this.mnuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
          this.mnuItemOpen.Size = new System.Drawing.Size(263, 22);
          this.mnuItemOpen.Text = "Открыть";
          this.mnuItemOpen.Click += new System.EventHandler(this.mnuItemOpen_Click);
          // 
          // toolStripSeparator4
          // 
          this.toolStripSeparator4.Name = "toolStripSeparator4";
          this.toolStripSeparator4.Size = new System.Drawing.Size(260, 6);
          // 
          // mnuItemPlayStop
          // 
          this.mnuItemPlayStop.Name = "mnuItemPlayStop";
          this.mnuItemPlayStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
          this.mnuItemPlayStop.Size = new System.Drawing.Size(263, 22);
          this.mnuItemPlayStop.Text = "Воспроизвести/Остановить";
          this.mnuItemPlayStop.Click += new System.EventHandler(this.mnuItemPlayStop_Click);
          // 
          // toolStripSeparator5
          // 
          this.toolStripSeparator5.Name = "toolStripSeparator5";
          this.toolStripSeparator5.Size = new System.Drawing.Size(260, 6);
          // 
          // mnuItemRename
          // 
          this.mnuItemRename.Name = "mnuItemRename";
          this.mnuItemRename.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
          this.mnuItemRename.Size = new System.Drawing.Size(263, 22);
          this.mnuItemRename.Text = "Переименовать";
          this.mnuItemRename.Click += new System.EventHandler(this.mnuItemRename_Click);
          // 
          // toolStripSeparator6
          // 
          this.toolStripSeparator6.Name = "toolStripSeparator6";
          this.toolStripSeparator6.Size = new System.Drawing.Size(260, 6);
          // 
          // mnuItemSaveAll
          // 
          this.mnuItemSaveAll.Name = "mnuItemSaveAll";
          this.mnuItemSaveAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                      | System.Windows.Forms.Keys.S)));
          this.mnuItemSaveAll.Size = new System.Drawing.Size(263, 22);
          this.mnuItemSaveAll.Text = "Сохранить все";
          this.mnuItemSaveAll.Click += new System.EventHandler(this.mnuItemSaveAll_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(260, 6);
          // 
          // mnuItemDelete
          // 
          this.mnuItemDelete.Name = "mnuItemDelete";
          this.mnuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
          this.mnuItemDelete.Size = new System.Drawing.Size(263, 22);
          this.mnuItemDelete.Text = "Удалить";
          this.mnuItemDelete.Click += new System.EventHandler(this.mnuItemDelete_Click);
          // 
          // contextMenuForRootsOfSoundTreeNodes
          // 
          this.contextMenuForRootsOfSoundTreeNodes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemAdd});
          this.contextMenuForRootsOfSoundTreeNodes.Name = "cntxTreeViewForRootOfSounds";
          this.contextMenuForRootsOfSoundTreeNodes.Size = new System.Drawing.Size(136, 26);
          // 
          // mnuItemAdd
          // 
          this.mnuItemAdd.Name = "mnuItemAdd";
          this.mnuItemAdd.Size = new System.Drawing.Size(135, 22);
          this.mnuItemAdd.Text = "Добавить";
          this.mnuItemAdd.Click += new System.EventHandler(this.mnuItemAdd_Click);
          // 
          // Window
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.AutoScroll = true;
          this.ClientSize = new System.Drawing.Size(1008, 609);
          this.Controls.Add(this.splitContainer1);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Margin = new System.Windows.Forms.Padding(2);
          this.Name = "Window";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "Звуковой конструктор";
          this.Load += new System.EventHandler(this.Window_Load);
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel1.PerformLayout();
          this.splitContainer1.Panel2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
          this.splitContainer1.ResumeLayout(false);
          this.mnuStripFile.ResumeLayout(false);
          this.mnuStripFile.PerformLayout();
          this.splitContainer2.Panel1.ResumeLayout(false);
          this.splitContainer2.Panel2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
          this.splitContainer2.ResumeLayout(false);
          this.mainTabControl.ResumeLayout(false);
          this.tabPageForRepeatedSoundSettings.ResumeLayout(false);
          this.contextMenuForSoundTreeNodes.ResumeLayout(false);
          this.contextMenuForRootsOfSoundTreeNodes.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.MenuStrip mnuStripFile;
      private System.Windows.Forms.SplitContainer splitContainer2;
      private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.TabPage tabPageForRepeatedSoundSettings;
      private System.Windows.Forms.ContextMenuStrip contextMenuForSoundTreeNodes;
		private SoundSystemControls.RepeatedSoundPanel RepeatedSoundPanel1;
      private System.Windows.Forms.ToolStripMenuItem mnuItemOpen;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripMenuItem mnuItemPlayStop;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripMenuItem mnuItemRename;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
      private System.Windows.Forms.ToolStripMenuItem mnuItemSaveAll;
      private System.Windows.Forms.ContextMenuStrip contextMenuForRootsOfSoundTreeNodes;
      private System.Windows.Forms.ToolStripMenuItem mnuItemAdd;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem mnuItemDelete;
		public System.Windows.Forms.TreeView mainTreeView;
		private System.Windows.Forms.ToolStripMenuItem imitationMenuItem;


   }
}

