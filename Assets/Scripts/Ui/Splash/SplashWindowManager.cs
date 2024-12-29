using Reflex.Interfaces;
using Ui.Splash.Windows;
using Ui.Window;

namespace Ui.Splash
{
    public class SplashWindowManager : IInitializable, INonLazy
    {
        private readonly ISimpleWindowController _simpleWindowController;

        public SplashWindowManager(
            ISimpleWindowController simpleWindowController
        )
        {
            _simpleWindowController = simpleWindowController;
        }

        public void Initialize()
        {
            _simpleWindowController.Open<SplashWindow>();
        }
    }
}