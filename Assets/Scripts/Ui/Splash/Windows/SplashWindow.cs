using Core.Constants;
using SimpleUi;
using Ui.Splash.SplashScreen;

namespace Ui.Splash.Windows
{
    public class SplashWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.Splash.SplashScreen);
        
        protected override void AddControllers()
        {
            AddController<SplashController>();
        }
    }
}