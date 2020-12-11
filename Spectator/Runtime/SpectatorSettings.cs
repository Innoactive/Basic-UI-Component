using Innoactive.Creator.Core.Runtime.Utils;
using UnityEngine;
#if ENABLE_LEGACY_INPUT_MANAGER
using Key = UnityEngine.KeyCode;
#else
using UnityEngine.InputSystem;
#endif

namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Settings to control the spectator.
    /// </summary>
    [CreateAssetMenu(fileName = "SpectatorControlSettings", menuName = "Innoactive/SpectatorSettings", order = 1)]
    public class SpectatorSettings : SettingsObject<SpectatorSettings>
    {
        private static SpectatorSettings settings;

        /// <summary>
        /// Hotkey to toggle UI overlay.
        /// </summary>
        public Key ToggleOverlay = Key.W;
    }
}
