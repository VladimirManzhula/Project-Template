using Core.Constants;
using SimpleUi;
using Ui.Splash.SplashScreen;

namespace Ui.Splash.Windows
{
    public class SplashWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.ESplash.Splash);
        
        protected override void AddControllers()
        {
            AddController<SplashController>();
        }
    }
}