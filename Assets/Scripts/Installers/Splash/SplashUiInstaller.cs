using SimpleUi;
using Ui.Splash.SplashScreen;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers.Splash
{
    [CreateAssetMenu(menuName = "Installers/SplashPrefabInstaller", fileName = "SplashPrefabInstaller")]
    public class SplashUiInstaller : ScriptableObjectInstaller
    {
        [Header("Canvas")]
        [SerializeField] private Canvas canvas;

        [FormerlySerializedAs("splashScreenView")] [Space] [Header("Views")] [SerializeField]
        private SplashView splashView;

        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;
            
            Container.BindUiView<SplashController, SplashView>(splashView, canvasTransform);
        }
    }
}