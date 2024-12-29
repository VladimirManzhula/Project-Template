using Reflex;
using ReflexUI.Runtime;
using ReflexUI.Runtime.Extensions;
using ReflexUI.Runtime.Interfaces;
using Ui.Splash.SplashScreen;
using Ui.Window;
using UnityEngine;

namespace Installers.Splash
{
    [CreateAssetMenu(
        menuName = "Installers/Splash/" + nameof(SplashUiPrefabsInstaller), 
        fileName = nameof(SplashUiPrefabsInstaller), order = 0
    )]
    public class SplashUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private SplashView splashView;

        public override void InstallBindings(ContainerBuilder builder)
        {
            var canvasObject = Instantiate(canvas);
            if (canvasObject.TryGetComponent(out CustomGraphicRaycaster raycaster))
                builder.AddSingleton(raycaster, typeof(IUiFilter));
            
            builder.AddSingleton<ISimpleWindowController>(container
                => new SimpleWindowController(container, canvasObject.transform));
            
            builder.AddUi<SplashController, SplashView>(splashView);
        }
    }
}