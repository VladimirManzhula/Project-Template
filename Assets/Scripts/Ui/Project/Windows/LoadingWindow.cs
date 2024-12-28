using Core.Constants;
using Ui.Project.Loading;
using Ui.Window;

namespace Ui.Project.Windows
{
    public class LoadingWindow : AWindow
    {
        public override string Name => nameof(WindowNames.EProjectType.Loading);

        protected override void AddControllers()
        {
            AddController<LoadingController>();
        }
    }
}