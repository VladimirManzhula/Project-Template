using Ui.Splash.SplashScreen;
using Ui.Window;

namespace Ui.Splash.Windows
{
    public class SplashWindow : AWindow
    {
        public override string Name => nameof(SplashWindow);

        protected override void AddControllers()
        {
            AddController<SplashController>();
        }
    }
}