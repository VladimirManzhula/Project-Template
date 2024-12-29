using PdUtils.PlayerPrefs;
using UnityEngine;

namespace PdUtils.AppVersion.Impl
{
	public class AppVersionService : IAppVersionService, IConfigurable
	{
		private const string AppVersionKey = "AppVersion";
		
		private readonly IPlayerPrefsManager _playerPrefs;

		public AppVersionService(IPlayerPrefsManager playerPrefs)
		{
			_playerPrefs = playerPrefs;
		}
		
		public void Configure()
		{
			_playerPrefs.SetValue(AppVersionKey, Application.version);
			_playerPrefs.Save();
		}

		public Version GetVersion()
		{
			return Version.FromString(Application.version);
		}
	}
}