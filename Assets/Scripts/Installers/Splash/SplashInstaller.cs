using Reflex;
using Ui.Splash;
using Ui.Splash.Windows;
using UnityEngine;

namespace Installers.Splash
{
    public class SplashInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            BindManagers(builder);
            BindWindows(builder);
        }

        private void BindManagers(ContainerBuilder builder)
        {
            builder.AddSingleton<SplashWindowManager>();
        }

        private void BindWindows(ContainerBuilder builder)
        {
            builder.AddSingleton<SplashWindow>();
        }
    }
}