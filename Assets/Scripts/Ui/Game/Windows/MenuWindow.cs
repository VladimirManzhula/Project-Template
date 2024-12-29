using Ui.Game.Menu;
using Ui.Window;

namespace Ui.Game.Windows
{
    public class MenuWindow : AWindow
    {
        public override string Name => nameof(MenuWindow);
        
        protected override void AddControllers()
        {
            AddController<MenuController>();
        }
    }
}