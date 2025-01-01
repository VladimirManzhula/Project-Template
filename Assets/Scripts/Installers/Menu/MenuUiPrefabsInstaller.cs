using Reflex;
using ReflexUI.Runtime;
using ReflexUI.Runtime.Extensions;
using ReflexUI.Runtime.Interfaces;
using Ui.Menu.Menu;
using Ui.Window;
using UnityEngine;

namespace Installers.Menu
{
    [CreateAssetMenu(
        menuName = "Installers/Menu/" + nameof(MenuUiPrefabsInstaller),
        fileName = nameof(MenuUiPrefabsInstaller), order = 0
    )]
    public class MenuUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private MenuView menuView;

        public override void InstallBindings(ContainerBuilder builder)
        {
            var canvasObject = Instantiate(canvas);
            if (canvasObject.TryGetComponent(out CustomGraphicRaycaster raycaster))
                builder.AddSingleton(raycaster, typeof(IUiFilter));
            
            builder.AddSingleton<IMenuWindowController>(container
                => new MenuWindowController(container, canvasObject.transform));
            
            builder.AddUi<MenuController, MenuView>(menuView);
        }
    }
}