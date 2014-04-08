using System;

namespace Core
{
	public interface INameProvider
	{
		string GetName();
	}

	public class Welcomer
	{
		private readonly INameProvider _nameProvider;

		public Welcomer(INameProvider nameProvider)
		{
			this._nameProvider = nameProvider;
		}

		public string GetWelcomeMessage()
		{
			return string.Format ("Hello {0}", _nameProvider.GetName ());
		}
	}
}

