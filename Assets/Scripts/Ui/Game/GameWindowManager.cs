using Reflex.Interfaces;
using Ui.Menu.Windows;
using Ui.Window;

namespace Ui.Game
{
    public class GameWindowManager : IInitializable, INonLazy
    {
        private readonly IMenuWindowController _menuWindowController;

        public GameWindowManager(
            IMenuWindowController menuWindowController
        )
        {
            _menuWindowController = menuWindowController;
        }

        public void Initialize()
        {
            
        }
    }
}