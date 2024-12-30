using Ui.Project.Loading;
using Ui.Window;

namespace Ui.Project.Windows
{
    public class LoadingWindow : AProjectWindow
    {
        public override string Name => nameof(LoadingWindow);

        protected override void AddControllers()
        {
            AddController<LoadingController>();
        }
    }
}