using Databases.Debug;
using Databases.Debug.Impls;
using Reflex;
using UnityEngine;

namespace Installers.Project
{
    [CreateAssetMenu(
        menuName = "Installers/Project/" + nameof(ProjectDatabaseInstaller), 
        fileName = nameof(ProjectDatabaseInstaller), order = 0
    )]
    public class ProjectDatabaseInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private DebugSettingsDatabase debugSettingsDatabase;
        
        public override void InstallBindings(ContainerBuilder builder)
        {
            builder.AddSingleton(debugSettingsDatabase, typeof(IDebugSettingsDatabase));
        }
    }
}