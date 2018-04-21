using System.Collections.Generic;
using NUnit.Framework;

namespace SoundConstructor
{
	[TestFixture]
	class PresenterTest
	{
		Presenter presenter;
		MockWindow window;

		[SetUp]
		public void SetUp()
		{
			window = new MockWindow();
			presenter = new Presenter(window);
			window.Presenter = presenter;
		}

		[Test]
		public void SetValues()
		{
			presenter.NameOfOnetimeSound = "s";

		}
	}
}
