using SimpleUi.Abstracts;
using TMPro;
using UnityEngine;

namespace Ui.Splash.SplashScreen
{
    public class SplashView : UiView
    {
        public TMP_Text textVersion;
        public TMP_Text id;

        protected override void Awake()
        {
            textVersion.text = "v" + Application.version;
            id.text = "ID: " + SystemInfo.deviceUniqueIdentifier;
        }
    }
}