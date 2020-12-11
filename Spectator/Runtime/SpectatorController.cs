using System;
using UnityEngine;
using UnityEngine.InputSystem;

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
            if (IsKeyPressed(SpectatorSettings.Instance.ToggleOverlay))
            {
                ToggleUIOverlayVisibility?.Invoke(this, new EventArgs());
            }
        }
        
        /// <summary>
        /// Is the given <paramref name="key"/> pressed.
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True, if key is pressed.</returns>
        /// <remarks>Use this for the new input system.</remarks>
        protected bool IsKeyPressed(Key key)
        {
            return Keyboard.current[key].wasPressedThisFrame;
        }
        
        /// <summary>
        /// Is the given <paramref name="key"/> pressed.
        /// </summary>
        /// <param name="key">Key to check</param>
        /// <returns>True, if key is pressed.</returns>
        /// <remarks>Use this for the old input system.</remarks>
        protected bool IsKeyPressed(KeyCode key)
        {
            return Input.GetKeyDown(key);
        }
    }
}
