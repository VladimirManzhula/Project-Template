using Ui.Project.Windows;
using Ui.Window;
using UnityEngine.SceneManagement;

namespace Core.Services.Scenes.Impls
{
    public class SceneService : ISceneService
    {
        private readonly ISimpleWindowController _simpleWindowController;

        public SceneService(ISimpleWindowController simpleWindowController)
        {
            _simpleWindowController = simpleWindowController;
        }

        public void LoadScene(ScenePlace scenePlace) => SceneManager.LoadScene(scenePlace.Value);
        
        public void Loading()
        {
            _simpleWindowController.Open<LoadingWindow>();
        }
    }
}