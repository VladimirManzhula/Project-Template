using Ui.Project.Windows;
using Ui.Window;
using UnityEngine.SceneManagement;

namespace Core.Services.Scenes.Impls
{
    public class SceneService : ISceneService
    {
        private readonly IProjectWindowController _projectWindowController;

        public SceneService(IProjectWindowController projectWindowController)
        {
            _projectWindowController = projectWindowController;
        }

        public void LoadScene(ScenePlace scenePlace) => SceneManager.LoadScene(scenePlace.Value);
        
        public void Loading()
        {
            _projectWindowController.Open<LoadingWindow>();
        }
    }
}