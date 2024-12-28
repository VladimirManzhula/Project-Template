using Core.Constants;
using Ui.Game.Menu;
using Ui.Window;

namespace Ui.Game.Windows
{
    public class MenuWindow : AWindow
    {
        public override string Name => nameof(WindowNames.EMenuType.Menu);
        
        protected override void AddControllers()
        {
            AddController<MenuController>();
        }
    }
}