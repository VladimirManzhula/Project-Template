using UnityEngine;

namespace PdUtils.PdAudio
{
    public interface IPdAudio
    {
        void PlayMusic();
        
        void StopMusic();

        void PauseMusic();
        
        void UnpauseMusic();

        void PlayFxLoop(string clip, float volumeScale = 1f);
        
        void PlayFxLoop(AudioClip clip, float volumeScale = 1f);
        
        void PlayFx(string clip, float volumeScale = 1f);
        
        void PlayFx(AudioClip clip, float volumeScale = 1f);
        
        void PlayUi(string clip, float volumeScale = 1f);
        
        void PlayUiLoop(string clip, float volumeScale = 1f);
        
        void PlayUiLoop(AudioClip clip, float volumeScale = 1f);

        void StopFxAndUi();

        void SetMusicVolume(float val);
        void SetFxAndUiVolume(float val);
    }
}