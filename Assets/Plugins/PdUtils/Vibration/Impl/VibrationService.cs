using PdUtils.PlayerPrefs;
using UnityEngine;

namespace PdUtils.Vibration.Impl
{
    public class VibrationService : IVibrationService
    {
        private readonly IPlayerPrefsManager _playerPrefsManager;
        private bool? _enabled;

        public VibrationService(IPlayerPrefsManager playerPrefsManager)
        {
            _playerPrefsManager = playerPrefsManager;
        }

        public bool Enabled
        {
            set => _playerPrefsManager.SetValue(PlayerPrefsKeys.VibrationOn.Value(), value);
            get
            {
                if (!_enabled.HasValue) _enabled = _playerPrefsManager.GetValue(PlayerPrefsKeys.VibrationOn.Value(), true);
                return _enabled.Value;
            }
        }

        public void Vibrate()
        {
            if (Enabled) Handheld.Vibrate();
        }
    }
}