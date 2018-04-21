using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using SoundSystemControls;
using Model;

namespace SoundConstructor
{
	public partial class Window : Form, View
	{
		Control currentSoundPanel;

		TreeNodeCollection SoundsTreeNodes
		{
			get { return mainTreeView.Nodes[0].Nodes; }
		}

		TreeNodeCollection RepeatedSoundsTreeNodes
		{
			get { return mainTreeView.Nodes[0].Nodes; }
		}

		private delegate Control CreateSoundPanelDelegate();
		private CreateSoundPanelDelegate CreateSoundPanel;

		#region View implementation

		public Presenter Presenter { private get; set; }

		private IList<string> namesOfRepeatedSounds;


		public IList<string> NamesOfSounds
		{
			private get
			{
				List<string> namesOfRepeatedSounds = new List<string>();
				foreach (TreeNode treeNode in RepeatedSoundsTreeNodes)
				{
					namesOfRepeatedSounds.Add(treeNode.Text);
				}
				return namesOfRepeatedSounds;
			}
			set
			{
				if (AreCollectionsNotEqual(namesOfRepeatedSounds, value))
				{
					UpdateRepeatedSoundsTreeNodes(value);
					mainTreeView.ExpandAll();
				}
			}
		}

		private bool AreCollectionsNotEqual(IList<string> collection, IList<string> secondCollection)
		{
			if (collection == null || secondCollection == null ||
				collection.Count != secondCollection.Count)
			{
				return true;
			}

			foreach (string element in collection)
			{
				if (!secondCollection.Contains(element))
				{
					return true;
				}
			}

			return false;
		}

		private void UpdateRepeatedSoundsTreeNodes(IList<string> namesOfRepeatedSounds)
		{
			RepeatedSoundsTreeNodes.Clear();
			foreach (string name in namesOfRepeatedSounds)
			{
				TreeNode node = new TreeNode(name);
				RepeatedSoundsTreeNodes.Add(node);
			}
		}


		public string NameOfSound
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).SoundName;
				}
				else return "";
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).SoundName = value;
				}
			}
		}

        public string SoundType
        {
            get
            {
                if (currentSoundPanel is RepeatedSoundPanel)
                {
                    return ((RepeatedSoundPanel)currentSoundPanel).SoundType;
                }
                else return "";
            }
            set
            {
                if (currentSoundPanel is RepeatedSoundPanel)
                {
                    ((RepeatedSoundPanel)currentSoundPanel).SoundType = value;
                }
            }
        }

		public string NameOfXmlParameterForVolume
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).NameOfXmlParameterForVolume;
				}
				else return "";
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).NameOfXmlParameterForVolume = value;
				}
			}
		}

		public string NameOfXmlParameterForFrequency
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).NameOfXmlParameterForFrequency;
				}
				else return "";
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).NameOfXmlParameterForFrequency = value;
				}
			}
		}

		public string NameOfXmlParameterForEcho
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).NameOfXmlParameterForEcho;
				}
				else return "";
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).NameOfXmlParameterForEcho = value;
				}
			}
		}

		public double ValueOfXmlParameterForVolume
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterForVolume;
				}
				else return 0.0;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterForVolume = value;
				}
			}
		}

		public double ValueOfXmlParameterForFrequency
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterForFrequency;
				}
				else return 0.0;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterForFrequency = value;
				}
			}
		}

		public double ValueOfXmlParameterForEcho
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterForEcho;
				}
				else return 0.0;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterForEcho = value;
				}
			}
		}

		public double ValueOfXmlParameterToEnableEchoFrom
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterToEnableEchoFrom;
				}
				else return 0.0;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterToEnableEchoFrom = value;
				}
			}
		}

		public double VolumeOfSound
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).Volume;
				}
				else return 0.0;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).Volume = value;
				}
			}
		}

		public double FrequencyOfSound
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).Frequency;
				}
				else return 0.0;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).Frequency = value;
				}
			}
		}

		public bool Echo
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).Echo;
				}
				else return false; ;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).Echo = value;
				}
			}
		}

		public string SoundFileLocationOfSound
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).SoundFileLocation;
				}
				else return "";
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).SoundFileLocation = value;
				}
			}
		}

		public SortedList<double, double> TableOfValuesForVolume
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).TableOfValuesForVolume;
				}
				else return null;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).TableOfValuesForVolume = value;
				}
			}
		}

		public SortedList<double, double> TableOfValuesForFrequency
		{
			get
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					return ((RepeatedSoundPanel)currentSoundPanel).TableOfValuesForFrequency;
				}
				else return null;
			}
			set
			{
				if (currentSoundPanel is RepeatedSoundPanel)
				{
					((RepeatedSoundPanel)currentSoundPanel).TableOfValuesForFrequency = value;
				}
			}
		}

		private bool imitationIsRunning;
		public bool ImitationIsRunning
		{
			get { return imitationIsRunning; }
			set
			{
				imitationIsRunning = value;
				ChangeImitationIsRunningViewState(imitationIsRunning);
			}
		}

		private void ChangeImitationIsRunningViewState(bool isRunning)
		{
			if (isRunning)
			{
				imitationMenuItem.Text = "Остановить";
			}
			else
			{
				imitationMenuItem.Text = "Имитация";
			}
		}

		#endregion

		public Window()
		{
			InitializeComponent();
			RemoveSampleTabPages();            
		}

		private void RemoveSampleTabPages()
		{
			mainTabControl.TabPages.Clear();
		}

		private void RemoveSoundFromTree(string soundName)
		{
			TreeNode node = SoundsTreeNodes.Find(soundName, true)[0];
			SoundsTreeNodes.Remove(node);
		}


		private bool IsRepeatedSoundTreeNode(TreeNode treeNode)
		{
			if (IsSoundTreeNode(treeNode))
			{
				return IsChildOfTheRootOfRepeatedSounds(treeNode);
			}
			else return false;
		}

		private bool IsSoundTreeNode(TreeNode treeNode)
		{
			if (IsNotTreeNode(treeNode) ||
				IsRootOfTheWholeTree(treeNode) ||
				IsRootOfRepeatedSoundTreeNodes(treeNode))
			{
				return false;
			}
			else return true;
		}

		private bool IsNotSoundTreeNode(TreeNode treeNode)
		{
			if (IsSoundTreeNode(treeNode))
			{
				return false;
			}
			else return true;
		}

		private bool IsNotTreeNode(TreeNode treeNode)
		{
			return treeNode == null;
		}

		private bool IsRootOfTheWholeTree(TreeNode treeNode)
		{
			return treeNode.Parent == null;
		}

		private bool IsRootOfSoundTreeNodes(TreeNode treeNode)
		{
			return treeNode.Text.Equals("Циклические");
		}

		private bool IsRootOfRepeatedSoundTreeNodes(TreeNode treeNode)
		{
			return treeNode.Text.Equals("Циклические");
		}


		private bool IsChildOfTheRootOfRepeatedSounds(TreeNode treeNode)
		{
			string parentNodeName = treeNode.Parent.Text;
			if (parentNodeName.Equals("Циклические"))
			{
				return true;
			}
			else return false;
		}

		private void CreateAndOpenTabPage(string soundName)
		{
			PrepareForCreatingTabPage(soundName);
			CreateTabPage(soundName);
			OpenTabPage(soundName);
		}

		private void PrepareForCreatingTabPage(string soundName)
		{
            if (IsNameOfRepeatedSound(soundName))
			{
				CreateSoundPanel = CreateRepeatedSoundPanel;
			}
		}

		private bool IsNameOfRepeatedSound(string soundName)
		{
			if (NamesOfSounds.Contains(soundName))
			{
				return true;
			}
			else return false;
		}

		private void CreateTabPage(string soundName)
		{
			if (TabPageDoesNotExist(soundName))
			{
				TabPage tabPage = new TabPage(soundName);

				Control soundPanel = CreateSoundPanel();
				AddSoundPanel(tabPage, soundPanel);

				mainTabControl.Controls.Add(tabPage);
			}
		}

		private void OpenTabPage(string soundName)
		{
			foreach (TabPage tabPage in mainTabControl.TabPages)
			{
				if (tabPage.Text == soundName)
				{
					mainTabControl.SelectedTab = tabPage;
					currentSoundPanel = mainTabControl.SelectedTab.Controls[0];
					return;
				}
			}
		}

		private bool TabPageDoesNotExist(string soundName)
		{
			return !TabPageExists(soundName);
		}

		private bool TabPageExists(string soundName)
		{
			bool exists = false;
			foreach (TabPage tabPage in mainTabControl.TabPages)
			{
				if (tabPage.Text == soundName)
				{
					exists = true;
				}
			}
			return exists;
		}

		private RepeatedSoundPanel CreateRepeatedSoundPanel()
		{
			RepeatedSoundPanel repeatedSoundPanel = new RepeatedSoundPanel();
			repeatedSoundPanel.AutoScroll = true;
			repeatedSoundPanel.Dock = DockStyle.Fill;

			BindRepeatedSoundPanelEventsWithHandlers(repeatedSoundPanel);
			return repeatedSoundPanel;
		}

		private void AddSoundPanel(TabPage tabPage, Control soundPanel)
		{
			tabPage.Controls.Add(soundPanel);
		}

		private void BindRepeatedSoundPanelEventsWithHandlers(RepeatedSoundPanel repeatedSoundPanel)
		{
			repeatedSoundPanel.SoundNameChanged += new EventHandler(repeatedSoundPanel_SoundNameChanged);
			repeatedSoundPanel.NameOfXmlParameterForVolumeChanged += new EventHandler(repeatedSoundPanel_NameOfXmlParameterForVolumeChanged);
			repeatedSoundPanel.NameOfXmlParameterForFrequencyChanged += new EventHandler(repeatedSoundPanel_NameOfXmlParameterForFrequencyChanged);
			repeatedSoundPanel.ValueOfXmlParameterForVolumeChanged += new EventHandler(repeatedSoundPanel_ValueOfXmlParameterForVolumeChanged);
			repeatedSoundPanel.ValueOfXmlParameterForFrequencyChanged += new EventHandler(repeatedSoundPanel_ValueOfXmlParameterForFrequencyChanged);
			repeatedSoundPanel.SoundFileLocationChanged += new EventHandler(repeatedSoundPanel_SoundFileLocationChanged);
			repeatedSoundPanel.TableOfValuesForVolumeChanged += new EventHandler(repeatedSoundPanel_TableOfValuesForVolumeChanged);
			repeatedSoundPanel.TableOfValuesForFrequencyChanged += new EventHandler(repeatedSoundPanel_TableOfValuesForFrequencyChanged);
			repeatedSoundPanel.Play += new EventHandler(repeatedSoundPanel_Play);
			repeatedSoundPanel.Stop += new EventHandler(repeatedSoundPanel_Stop);
		}

		void repeatedSoundPanel_SoundNameChanged(object sender, EventArgs e)
		{
			Presenter.NameOfRepeatedSound = ((RepeatedSoundPanel)currentSoundPanel).SoundName;
		}

		void repeatedSoundPanel_NameOfXmlParameterForVolumeChanged(object sender, EventArgs e)
		{
			Presenter.NameOfXmlParameterForVolume = ((RepeatedSoundPanel)currentSoundPanel).NameOfXmlParameterForVolume;
		}

		void repeatedSoundPanel_NameOfXmlParameterForFrequencyChanged(object sender, EventArgs e)
		{
			Presenter.NameOfXmlParameterForFrequency = ((RepeatedSoundPanel)currentSoundPanel).NameOfXmlParameterForFrequency;
		}

		void repeatedSoundPanel_SoundFileLocationChanged(object sender, EventArgs e)
		{
			Presenter.SoundFileLocationOfRepeatedSound = ((RepeatedSoundPanel)currentSoundPanel).SoundFileLocation;
		}

		void repeatedSoundPanel_ValueOfXmlParameterForVolumeChanged(object sender, EventArgs e)
		{
			Presenter.ValueOfXmlParameterForVolume = ((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterForVolume;
		}

		void repeatedSoundPanel_ValueOfXmlParameterForFrequencyChanged(object sender, EventArgs e)
		{
			Presenter.ValueOfXmlParameterForFrequency = ((RepeatedSoundPanel)currentSoundPanel).ValueOfXmlParameterForFrequency;
		}

		void repeatedSoundPanel_TableOfValuesForVolumeChanged(object sender, EventArgs e)
		{
			Presenter.TableOfValuesForVolume = ((RepeatedSoundPanel)currentSoundPanel).TableOfValuesForVolume;
		}

		void repeatedSoundPanel_TableOfValuesForFrequencyChanged(object sender, EventArgs e)
		{
			Presenter.TableOfValuesForFrequency = ((RepeatedSoundPanel)currentSoundPanel).TableOfValuesForFrequency;
		}

		void repeatedSoundPanel_EchoChanged(object sender, EventArgs e)
		{
			Presenter.TableOfValuesForFrequency = ((RepeatedSoundPanel)currentSoundPanel).TableOfValuesForFrequency;
		}

		void repeatedSoundPanel_Play(object sender, EventArgs e)
		{
			string soundName = ((RepeatedSoundPanel)currentSoundPanel).SoundName;
			Presenter.PlayRepeatedSound(soundName);
		}

		void repeatedSoundPanel_Stop(object sender, EventArgs e)
		{
			string soundName = ((RepeatedSoundPanel)currentSoundPanel).SoundName;
			Presenter.StopSound(soundName);
		}

		private void mainTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			MouseButtons pressedButton = e.Button;
			TreeNode selectedTreeNode = e.Node;
			mainTreeView.SelectedNode = selectedTreeNode;

			if (pressedButton == MouseButtons.Right)
			{
				if (IsRootOfSoundTreeNodes(selectedTreeNode))
				{
					contextMenuForRootsOfSoundTreeNodes.Show(MousePosition);
				}
				else if (IsSoundTreeNode(selectedTreeNode))
				{
					contextMenuForSoundTreeNodes.Show(MousePosition);
				}
			}
			else if (pressedButton == MouseButtons.Left)
			{
				if (IsSoundTreeNode(selectedTreeNode))
				{
					string soundName = selectedTreeNode.Text;
					CreateAndOpenTabPage(soundName);
					Presenter.OpenSound(soundName);
				}
			}
		}

		private void mainTabControl_Selected(object sender, TabControlEventArgs e)
		{
			if (e.TabPage != null)
			{
				currentSoundPanel = mainTabControl.SelectedTab.Controls[0];
				string soundName = e.TabPage.Text;
				Presenter.OpenSound(soundName);
			}
		}

		private void mnuItemOpen_Click(object sender, EventArgs e)
		{
			TreeNode selectedTreeNode = mainTreeView.SelectedNode;
			if (IsSoundTreeNode(selectedTreeNode))
			{
				string soundName = selectedTreeNode.Text;
				Presenter.OpenSound(soundName);
				mainTreeView.SelectedNode = GetTreeNodeByText(soundName);
				GetTreeNodeByText(soundName).Checked = true;
				CreateAndOpenTabPage(soundName);
			}
		}

		private void mnuItemPlayStop_Click(object sender, EventArgs e)
		{
			string soundName = mainTreeView.SelectedNode.Text;
			if (IsNameOfRepeatedSound(soundName))
			{
				Presenter.PlayRepeatedSound(soundName);
			}
		}

		private void mnuItemRename_Click(object sender, EventArgs e)
		{
			TreeNode selectedTreeNode = mainTreeView.SelectedNode;
			selectedTreeNode.BeginEdit();
		}

		private void mainTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			string oldNameOfSound = e.Node.Text;

            if (IsNameOfRepeatedSound(oldNameOfSound))
			{
				string newNameOfSound = e.Label;
				if (!String.IsNullOrEmpty(newNameOfSound))
				{
					Presenter.ChangeName(oldNameOfSound, newNameOfSound);
					ChangeTextOfAppropriateTabPageIfExists(oldNameOfSound, newNameOfSound);
				}
			}
		}

		private void ChangeTextOfAppropriateTabPageIfExists(string oldNameOfSound, string newNameOfSound)
		{
			if (TabPageExists(oldNameOfSound))
			{
				TabPage tabPage = GetTabPageByText(oldNameOfSound);
				tabPage.Text = newNameOfSound;
			}
		}

		private TabPage GetTabPageByText(string soundName)
		{
			foreach (TabPage tabPage in mainTabControl.TabPages)
			{
				if (tabPage.Text == soundName)
				{
					return tabPage;
				}
			}
			return null;
		}

		private void mnuItemSaveAll_Click(object sender, EventArgs e)
		{
			Presenter.SaveAllSounds();
		}

		private void mnuItemDelete_Click(object sender, EventArgs e)
		{
			string soundName = mainTreeView.SelectedNode.Text;
			DeleteSound(soundName);
		}

		private void DeleteSound(string soundName)
		{
			DeleteTreeNode(soundName);
			CloseTabPage(soundName);
			Presenter.DeleteSound(soundName);
		}

		private void DeleteTreeNode(string soundName)
		{
			TreeNode treeNodeToDelete = GetTreeNodeByText(soundName);
			SoundsTreeNodes.Remove(treeNodeToDelete);
		}

		private TreeNode GetTreeNodeByText(string soundName)
		{

			foreach (TreeNode treeNode in RepeatedSoundsTreeNodes)
			{
				if (treeNode.Text == soundName)
				{
					return treeNode;
				}
			}

			return null;
		}

		private void CloseTabPage(string soundName)
		{
			TabPage tabPage = GetTabPageByText(soundName);
			if (tabPage != null)
			{
				mainTabControl.TabPages.Remove(tabPage);
			}
		}

		private void mnuItemAdd_Click(object sender, EventArgs e)
		{
			TreeNode selectedTreeNode = mainTreeView.SelectedNode;
            if (IsRootOfRepeatedSoundTreeNodes(selectedTreeNode))
			{
				Presenter.AddRepeatedSound();
			}
		}

		private void mainTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			TreeNode nodeToEdit = e.Node;
			if (!RepeatedSoundsTreeNodes.Contains(nodeToEdit))
			{
				e.CancelEdit = true;
			}
			if (contextMenuForSoundTreeNodes.Visible == true)
				e.CancelEdit = false;
		}

		private void imitationMenuItem_Click(object sender, EventArgs e)
		{
			if (imitationMenuItem.Text == "Имитация")
			{
				Presenter.ImitationIsRunning = true;
			}
			else if (imitationMenuItem.Text == "Остановить")
			{
				Presenter.ImitationIsRunning = false;
			}
		}

        private void RepeatedSoundPanel1_Load(object sender, EventArgs e)
        {
        }

        private void Window_Load(object sender, EventArgs e)
        {
            Presenter.ImitationIsRunning = true;
            ChangeImitationIsRunningViewState(ImitationIsRunning);
        }		
	}
}

