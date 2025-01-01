using Ui.Menu.Menu;
using Ui.Window;

namespace Ui.Menu.Windows
{
    public class MenuWindow : AMenuWindow
    {
        public override string Name => nameof(MenuWindow);
        
        protected override void AddControllers()
        {
            AddController<MenuController>();
        }
    }
}