using Core.Constants;
using SimpleUi;
using Ui.Project.Loading;

namespace Project.Windows
{
    public class LoadingWindow : WindowBase
    {
        public override string Name => nameof(WindowNames.EProject.Loading);

        protected override void AddControllers()
        {
            AddController<LoadingController>();
        }
    }
}