using Reflex;
using Ui.Game;
using UnityEngine;

namespace Installers.Game
{
    public class GameInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder builder)
        {
            BindManagers(builder);
        }

        private void BindManagers(ContainerBuilder builder)
        {
            builder.AddSingleton<GameWindowManager>();
        }
    }
}