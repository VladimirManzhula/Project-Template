using Core.Services.Scenes;
using Reflex.Interfaces;
using ReflexUI.Runtime.Abstracts;
using UniRx;

namespace Ui.Menu.Menu
{
    public class MenuController : UiController<MenuView>, IInitializable
    {
        private readonly ISceneService _sceneService;

        public MenuController(
            ISceneService sceneService
        )
        {
            _sceneService = sceneService;
        }

        public void Initialize()
        {
            View.StartGameButton.OnClickAsObservable().Subscribe(OnStartGame).AddTo(View);
        }

        private void OnStartGame(Unit _)
        {
            _sceneService.LoadScene(ScenePlace.Game);
        }
    }
}