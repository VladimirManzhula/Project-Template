using Reflex;
using ReflexUI.Runtime;
using ReflexUI.Runtime.Extensions;
using ReflexUI.Runtime.Interfaces;
using Ui.Game.Menu;
using Ui.Window;
using UnityEngine;

namespace Installers.Game
{
    [CreateAssetMenu(
        menuName = "Installers/Game/" + nameof(GameUiPrefabsInstaller),
        fileName = nameof(GameUiPrefabsInstaller), order = 0
    )]
    public class GameUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private MenuView menuView;

        public override void InstallBindings(ContainerBuilder builder)
        {
            var canvasObject = Instantiate(canvas);
            if (canvasObject.TryGetComponent(out CustomGraphicRaycaster raycaster))
                builder.AddSingleton(raycaster, typeof(IUiFilter));
            
            builder.AddSingleton<ISimpleWindowController>(canvasObject
                => new SimpleWindowController(canvasObject, canvas.transform));
            
            builder.AddUi<MenuController, MenuView>(menuView);
        }
    }
}