using System;
using System.Collections.Generic;
using PdUtils.PlayerPrefs;
using PdUtils.RandomProvider;
using UniRx;
using UnityEngine;

namespace PdUtils.PdAudio.Impls
{
	public class PdAudio : IPdAudio, IPdAudioSettings, IConfigurable, IDisposable
	{
		private readonly IPlayerPrefsManager _playerPrefsManager;
		private readonly IPdAudioSources _pdAudioSources;
		private readonly List<AudioClip> _musicTracks;
		private readonly IRandomProvider _randomProvider;

		private readonly CompositeDisposable _disposables = new CompositeDisposable();

		private readonly IDictionary<string, AudioClip> _fullPathToClipMap = new Dictionary<string, AudioClip>();


		private bool? _musicEnabled;
		private bool? _soundFxEnabled;


		public PdAudio(
			IPlayerPrefsManager playerPrefsManager,
			IPdAudioSources pdAudioSources,
			List<AudioClip> musicTracks,
			IRandomProvider randomProvider
		)
		{
			_playerPrefsManager = playerPrefsManager;
			_pdAudioSources = pdAudioSources;
			_musicTracks = musicTracks;
			_randomProvider = randomProvider;
		}

		public void Configure()
		{
			_pdAudioSources.UiAndFxAudioSource.ignoreListenerPause = true;
		}

		public void Dispose()
		{
			_disposables?.Dispose();
		}

		public void PlayMusic()
		{
			if (!MusicEnabled)
				return;

			var rndTrackIndex = _randomProvider.Range(0, _musicTracks.Count);
			var track = _musicTracks[rndTrackIndex];
//			_pdAudioSources.MusicAudioSource.clip = GetAudioClipByPathAndName("Sound/Music", track);
			_pdAudioSources.MusicAudioSource.clip = track;
			_pdAudioSources.MusicAudioSource.Play();
		}

		public void StopMusic()
		{
			_pdAudioSources.MusicAudioSource.Stop();
		}

		public void PauseMusic()
		{
			AudioListener.pause = true;
		}

		public void UnpauseMusic()
		{
			AudioListener.pause = false;
		}

		public void PlayFxLoop(string clip, float volumeScale = 1f)
		{
			if (!SoundFxEnabled)
				return;
			
			var audioClip = GetAudioClipByPathAndName("Sound/Fx", clip);
			_pdAudioSources.UiAndFxAudioSource.volume = volumeScale;
			_pdAudioSources.UiAndFxAudioSource.loop = true;
			_pdAudioSources.UiAndFxAudioSource.clip = audioClip;
			_pdAudioSources.UiAndFxAudioSource.Play();
		}

		public void PlayFxLoop(AudioClip clip, float volumeScale = 1f)
		{
			if (!SoundFxEnabled)
				return;

			_pdAudioSources.UiAndFxAudioSource.volume = volumeScale;
			_pdAudioSources.UiAndFxAudioSource.loop = true;
			_pdAudioSources.UiAndFxAudioSource.clip = clip;
			_pdAudioSources.UiAndFxAudioSource.Play();
		}

		public void PlayFx(string clip, float volumeScale = 1f)
		{
			if (!SoundFxEnabled)
				return;

			var audioClip = GetAudioClipByPathAndName("Sound/Fx", clip);
			_pdAudioSources.UiAndFxAudioSource.PlayOneShot(audioClip, volumeScale);
		}

		public void PlayFx(AudioClip clip, float volumeScale = 1)
		{
			if (!SoundFxEnabled)
				return;
			
			_pdAudioSources.UiAndFxAudioSource.PlayOneShot(clip, volumeScale);
		}

		public void PlayUi(string clip, float volumeScale = 1f)
		{
			if (!SoundFxEnabled)
				return;

			var audioClip = GetAudioClipByPathAndName("Sound/Ui", clip);
			_pdAudioSources.UiAndFxAudioSource.PlayOneShot(audioClip, volumeScale);
		}

		public void PlayUiLoop(string clip, float volumeScale = 1f)
		{
			if (!SoundFxEnabled)
				return;

			var audioClip = GetAudioClipByPathAndName("Sound/Fx", clip);
			_pdAudioSources.UiAndFxAudioSource.volume = volumeScale;
			_pdAudioSources.UiAndFxAudioSource.loop = true;
			_pdAudioSources.UiAndFxAudioSource.clip = audioClip;
			_pdAudioSources.UiAndFxAudioSource.Play();
		}

		public void PlayUiLoop(AudioClip clip, float volumeScale = 1f)
		{
			if (!SoundFxEnabled)
				return;

			_pdAudioSources.UiAndFxAudioSource.volume = volumeScale;
			_pdAudioSources.UiAndFxAudioSource.loop = true;
			_pdAudioSources.UiAndFxAudioSource.clip = clip;
			_pdAudioSources.UiAndFxAudioSource.Play();
		}

		public void StopFxAndUi()
		{
			_pdAudioSources.UiAndFxAudioSource.volume = 1;
			_pdAudioSources.UiAndFxAudioSource.loop = false;
			_pdAudioSources.UiAndFxAudioSource.Stop();
		}

		public void SetMusicVolume(float val) => _pdAudioSources.MusicAudioSource.volume = val;

		public void SetFxAndUiVolume(float val) => _pdAudioSources.UiAndFxAudioSource.volume = val;

		public bool MusicEnabled
		{
			set
			{
				_playerPrefsManager.SetValue(PlayerPrefsKeys.MusicOn.Value(), value);
				_musicEnabled = value;
				if (value)
				{
					PlayMusic();
				}
				else
				{
					StopMusic();
				}
			}
			get
			{
				if (!_musicEnabled.HasValue)
					_musicEnabled = _playerPrefsManager.GetValue(PlayerPrefsKeys.MusicOn.Value(), true);
				return _musicEnabled.Value;
			}
		}

		public bool SoundFxEnabled
		{
			set
			{
				_playerPrefsManager.SetValue(PlayerPrefsKeys.SoundFxOn.Value(), value);
				_soundFxEnabled = value;
			}
			get
			{
				if (!_soundFxEnabled.HasValue)
					_soundFxEnabled = _playerPrefsManager.GetValue(PlayerPrefsKeys.SoundFxOn.Value(), true);
				return _soundFxEnabled.Value;
			}
		}
		
		// =====================================================================================

		private AudioClip GetAudioClipByPathAndName(string path, string name)
		{
			var fullPath = path + "/" + name;
			if (_fullPathToClipMap.ContainsKey(fullPath))
				return _fullPathToClipMap[fullPath];

			var audioClip = Resources.Load<AudioClip>(fullPath);
			if (audioClip == null)
				throw new ArgumentException("Ui clip with name " + name + " in path " + path + " does not exist");

			_fullPathToClipMap.Add(fullPath, audioClip);
			return audioClip;
		}
	}
}