using Core.Constants;
using SimpleUi;
using Ui.Game.Hud;

namespace Ui.Game.Windows
{
    public class MenuWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.Game.menu);
        
        protected override void AddControllers()
        {
            AddController<MenuController>();
        }
    }
}