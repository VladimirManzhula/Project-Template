using Ui.Menu.Menu;
using Ui.Window;

namespace Ui.Menu.Windows
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