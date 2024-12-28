using Reflex.Interfaces;
using Ui.Game.Windows;
using Ui.Window;

namespace Ui.Game
{
    public class GameWindowManager : IInitializable, INonLazy
    {
        private readonly ISimpleWindowController _simpleWindowController;

        public GameWindowManager(
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