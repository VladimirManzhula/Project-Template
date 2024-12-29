using Reflex;
using ReflexUI.Runtime;
using ReflexUI.Runtime.Extensions;
using ReflexUI.Runtime.Interfaces;
using Ui.Project.Loading;
using Ui.Window;
using UnityEngine;

namespace Installers.Project
{
    [CreateAssetMenu(
        menuName = "Installers/Project/" + nameof(ProjectUiPrefabsInstaller), 
        fileName = nameof(ProjectUiPrefabsInstaller), order = 0
    )]
    public class ProjectUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private LoadingView loadingView;

        public override void InstallBindings(ContainerBuilder builder)
        {
            var canvasObject = Instantiate(canvas);
            if (canvasObject.TryGetComponent(out CustomGraphicRaycaster raycaster))
                builder.AddSingleton(raycaster, typeof(IUiFilter));
            
            builder.AddSingleton<ISimpleWindowController>(container
                => new SimpleWindowController(container, canvasObject.transform));
            
            builder.AddUi<LoadingController, LoadingView>(loadingView);
        }
    }
}