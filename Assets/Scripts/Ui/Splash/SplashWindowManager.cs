using Reflex.Interfaces;
using Ui.Splash.Windows;
using Ui.Window;

namespace Ui.Splash
{
    public class SplashWindowManager : IInitializable, INonLazy
    {
        private readonly ISimpleWindowController _windowController;

        public SplashWindowManager(
            ISimpleWindowController windowController
        )
        {
            _windowController = windowController;
        }

        public void Initialize()
        {
            _windowController.Open<SplashWindow>();
        }
    }
}