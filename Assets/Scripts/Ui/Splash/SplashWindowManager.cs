using Reflex.Interfaces;
using Ui.Splash.Windows;
using Ui.Window;

namespace Ui.Splash
{
    public class SplashWindowManager : IInitializable, INonLazy
    {
        private readonly IMenuWindowController _menuWindowController;

        public SplashWindowManager(
            IMenuWindowController menuWindowController
        )
        {
            _menuWindowController = menuWindowController;
        }

        public void Initialize()
        {
            _menuWindowController.Open<SplashWindow>();
        }
    }
}