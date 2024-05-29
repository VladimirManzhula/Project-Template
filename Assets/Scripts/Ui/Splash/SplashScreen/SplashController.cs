using System;
using Core.Services.Scenes;
using SimpleUi.Abstracts;
using UniRx;
using Zenject;

namespace Ui.Splash.SplashScreen
{
    public class SplashController : UiController<SplashView>, IInitializable, IDisposable
    {
        private readonly ISceneService _sceneService;
        private IDisposable _timerDisposable = Disposable.Empty;

        public SplashController(
            ISceneService sceneService
        )
        {
            _sceneService = sceneService;
        }

        public void Initialize() => _timerDisposable = Observable.Timer(TimeSpan.FromSeconds(2)).Subscribe(OnTimerFinished);

        public void Dispose() => _timerDisposable?.Dispose();

        private void OnTimerFinished(long l) => _sceneService.LoadScene(ScenePlace.Game);
    }
}