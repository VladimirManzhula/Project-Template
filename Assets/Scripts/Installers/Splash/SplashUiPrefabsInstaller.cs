using SimpleUi;
using Ui.Splash.SplashScreen;
using UnityEngine;
using Zenject;

namespace Installers.Splash
{
    [CreateAssetMenu(menuName = "Installers/SplashUiPrefabsInstaller", fileName = "SplashUiPrefabsInstaller")]
    public class SplashUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private SplashView splashView;

        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;
            
            Container.BindUiView<SplashController, SplashView>(splashView, canvasTransform);
        }
    }
}