using Reflex.Interfaces;
using Ui.Menu.Windows;
using Ui.Project.Windows;
using Ui.Window;

namespace Ui.Menu
{
    public class MenuWindowManager : IInitializable, INonLazy
    {
        private readonly ISimpleWindowController _simpleWindowController;

        public MenuWindowManager(
            ISimpleWindowController simpleWindowController
        )
        {
            _simpleWindowController = simpleWindowController;
        }

        public void Initialize()
        {
            _simpleWindowController.Open<MenuWindow>();
        }
    }
}