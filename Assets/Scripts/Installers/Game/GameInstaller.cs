using Reflex;
using Ui.Game;
using Ui.Game.Windows;
using UnityEngine;

namespace Installers.Game
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            BindManagers(builder);
            BindWindows(builder);
        }

        private void BindManagers(ContainerBuilder builder)
        {
            builder.AddSingleton<GameWindowManager>();
        }

        private void BindWindows(ContainerBuilder builder)
        {
            builder.AddSingleton<MenuWindow>();
        }
    }
}