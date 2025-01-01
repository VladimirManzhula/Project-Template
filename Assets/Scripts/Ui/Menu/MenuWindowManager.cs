using Reflex.Interfaces;
using Ui.Menu.Windows;
using Ui.Window;

namespace Ui.Menu
{
    public class MenuWindowManager : IInitializable, INonLazy
    {
        private readonly IMenuWindowController _menuWindowController;

        public MenuWindowManager(
            IMenuWindowController menuWindowController
        )
        {
            _menuWindowController = menuWindowController;
        }

        public void Initialize()
        {
            _menuWindowController.Open<MenuWindow>();
        }
    }
}