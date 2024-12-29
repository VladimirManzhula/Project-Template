using UnityEngine;

namespace PdUtils.PdAudio
{

    public interface IPdAudioSources
    {
        AudioSource MusicAudioSource { get; }
        AudioSource UiAndFxAudioSource { get; }  
    }
    
    public class PdAudioSources : MonoBehaviour, IPdAudioSources
    {
        public AudioSource musicAudioSource;
        public AudioSource uiAndFxAudioSource;
        public bool dontDestroyOnLoad;

        private void Awake()
        {
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);   
            }
        }

        public AudioSource MusicAudioSource => musicAudioSource;
        public AudioSource UiAndFxAudioSource => uiAndFxAudioSource;
    }
}