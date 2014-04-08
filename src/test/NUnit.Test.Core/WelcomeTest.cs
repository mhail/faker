using NUnit.Framework;
using System;
using Core;
using FakeItEasy;

namespace NUnit.Test.Core
{
	[TestFixture ()]
	public class WelcomeTest
	{
		private INameProvider nameProvider;
		private Welcomer welcomer;

		[SetUp]
		public void SetUp()
		{
			nameProvider = A.Fake<INameProvider> ();
			welcomer = new Welcomer (nameProvider);
		}

		[Test ()]
		public void TestCase ()
		{
			// Setup
			A.CallTo (() => nameProvider.GetName ()).Returns ("World");

			// Execute
			var result = welcomer.GetWelcomeMessage ();

			Assert.AreEqual ("Hello World", result);
		}
	}
}

