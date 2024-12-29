using Core.Services.Scenes;
using Core.Services.Scenes.Impls;
using Reflex;
using Ui.Project.Windows;
using UnityEngine;

namespace Installers.Project
{
    public class ProjectInstallers : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            SetSettings();
            BindServices(builder);
            BindWindows(builder);
        }

        private void SetSettings()
        {
            Application.targetFrameRate = 60;
        }

        private void BindServices(ContainerBuilder builder)
        {
            builder.AddSingleton<SceneService, ISceneService>();
        }

        private void BindWindows(ContainerBuilder builder)
        {
            builder.AddSingleton<LoadingWindow>();
        }
    }
}