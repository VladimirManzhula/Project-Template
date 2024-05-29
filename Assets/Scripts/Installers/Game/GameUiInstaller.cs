using SimpleUi;
using Ui.Game.Hud;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/GameUiInstaller", fileName = "GameUiInstaller")]
    public class GameUiInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [FormerlySerializedAs("hudView")] [SerializeField] private MenuView menuView;
        

        public override void InstallBindings()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasInstance.transform;
            
            Container.BindUiView<MenuController, MenuView>(menuView, canvasTransform);
        }
    }
}