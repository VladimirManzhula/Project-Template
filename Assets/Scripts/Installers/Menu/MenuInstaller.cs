using Reflex;
using Ui.Menu;
using Ui.Menu.Windows;
using UnityEngine;

namespace Installers.Menu
{
    public class MenuInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            BindManagers(builder);
            BindWindows(builder);
        }

        private void BindManagers(ContainerBuilder builder)
        {
            builder.AddSingleton<MenuWindowManager>();
        }

        private void BindWindows(ContainerBuilder builder)
        {
            builder.AddSingleton<MenuWindow>();
        }
    }
}