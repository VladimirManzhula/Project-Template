using Core.Constants;
using SimpleUi;
using Ui.Project.Loading;

namespace Ui.Project.Windows
{
    public class LoadingWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.EProjectType.Loading);

        protected override void AddControllers()
        {
            AddController<LoadingController>();
        }
    }
}