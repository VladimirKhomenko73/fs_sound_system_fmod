using System.Collections.Generic;
using System.Windows.Forms;
using NUnit.Framework;

namespace SoundConstructor
{
	[TestFixture]
	class WindowTest
	{
		private Window window;
		private Presenter presenter;

		[SetUp]
		public void SetUp()
		{
			window = new Window();
			presenter = new Presenter(window);
			window.Presenter = presenter;
			window.Show();
		}

		[Test]
		public void SetNamesOfOnetimeSounds()
		{
			List<string> namesOfOnetimeSounds = new List<string>()
			{
				"Двигатель включили",
				"Двигатель выключили"
			};
			window.NamesOfOnetimeSounds = namesOfOnetimeSounds;

			TreeNode soundsTreeNode = window.mainTreeView.Nodes[0];
			TreeNode onetimeSoundsTreeNode = soundsTreeNode.Nodes[0];
			TreeNode firstOnetimeSoundTreeNode = onetimeSoundsTreeNode.Nodes[0];
			Assert.AreEqual(firstOnetimeSoundTreeNode.Text, "Двигатель включили");
			TreeNode secondOnetimeSoundTreeNode = onetimeSoundsTreeNode.Nodes[1];
			Assert.AreEqual(secondOnetimeSoundTreeNode.Text, "Двигатель выключили");
		}

		[Test]
		public void SetNamesOfRepeatedSounds()
		{
			List<string> namesOfRepeatedSounds = new List<string>()
			{
				"Левая турбина",
				"Правая турбина"
			};
			window.NamesOfRepeatedSounds = namesOfRepeatedSounds;

			TreeNode soundsTreeNode = window.mainTreeView.Nodes[0];
			TreeNode repeatedSoundsTreeNode = soundsTreeNode.Nodes[1];
			TreeNode firstRepeatedSoundTreeNode = repeatedSoundsTreeNode.Nodes[0];
			Assert.AreEqual(firstRepeatedSoundTreeNode.Text, "Левая турбина");
			TreeNode secondRepeatedSoundTreeNode = repeatedSoundsTreeNode.Nodes[1];
			Assert.AreEqual(secondRepeatedSoundTreeNode.Text, "Правая турбина");
		}
	}
}
