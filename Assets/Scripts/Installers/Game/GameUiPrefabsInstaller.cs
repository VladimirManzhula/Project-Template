using SimpleUi;
using Ui.Game.Menu;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(
        menuName = "Installers/Game/GameUiPrefabsInstaller", 
        fileName = nameof(GameUiPrefabsInstaller), order = 0
    )]
    public class GameUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private MenuView menuView;

        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;
            
            Container.BindUiView<MenuController, MenuView>(menuView, canvasTransform);
        }
    }
}