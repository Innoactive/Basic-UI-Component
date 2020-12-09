using System;
using UnityEngine;

namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Controller for a spectator to toggle UI visibility.
    /// </summary>
    public class SpectatorController : MonoBehaviour
    {
        /// <summary>
        /// Event fired when UI visibility is toggled.
        /// </summary>
        public event EventHandler ToggleUIOverlayVisibility;

        protected virtual void Update()
        {
            HandleInput();
        }

        /// <summary>
        /// Handles user input.
        /// </summary>
        protected virtual void HandleInput()
        {
            if (Input.GetKeyDown(SpectatorSettings.Instance.ToggleOverlay))
            {
                ToggleUIOverlayVisibility?.Invoke(this, new EventArgs());
            }
        }
    }
}
