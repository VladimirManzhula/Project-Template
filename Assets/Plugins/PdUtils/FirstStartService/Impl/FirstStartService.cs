using System;
using PdUtils.DateTimeService;
using PdUtils.PlayerPrefs;

namespace PdUtils.FirstStartService.Impl
{
	public class FirstStartService : IFirstStartService
	{
		private const string FirstStartKey = "Game.FirstStartTs";
		private const string FirstStartTimeKey = "Game.FirstStartTimeTs";

		private readonly IPlayerPrefsManager _prefsManager;
		private readonly IDateTimeService _dateTimeService;

		private DateTime? _firstTimeUtc;

		public FirstStartService(IPlayerPrefsManager prefsManager, IDateTimeService dateTimeService)
		{
			_prefsManager = prefsManager;
			_dateTimeService = dateTimeService;
		}

		public void SaveFirstStart(Action firstStartAction)
		{
			if (!_prefsManager.HasKey(FirstStartKey))
			{
				_prefsManager.SetValue(FirstStartKey, true);
				firstStartAction?.Invoke();

				var startTimeMs = _dateTimeService.UtcNow.ToUnixTimeMilliseconds();
				_prefsManager.SetValue(FirstStartTimeKey, startTimeMs);
			}
			else
			{
				_prefsManager.SetValue(FirstStartKey, false);
			}
			_prefsManager.Save();
		}

		public DateTime? GetFirstStartTimeUtc()
		{
			if (!_prefsManager.HasKey(FirstStartTimeKey))
				return null;

			if (_firstTimeUtc.HasValue)
				return _firstTimeUtc.Value;
			
			var startTimeMs = _prefsManager.GetValue<long>(FirstStartTimeKey);
			_firstTimeUtc = DateTimeOffset.FromUnixTimeMilliseconds(startTimeMs).DateTime;
			return _firstTimeUtc;
		}
	}
}