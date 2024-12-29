using UnityEngine;

namespace Databases.Debug.Impls
{
    [CreateAssetMenu(
        menuName = "Databases/" + nameof(DebugSettingsDatabase),
        fileName = nameof(DebugSettingsDatabase), order = 0
    )]
    public class DebugSettingsDatabase : ScriptableObject, IDebugSettingsDatabase
    {
    }
}