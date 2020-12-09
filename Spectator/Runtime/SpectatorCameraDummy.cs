using UnityEngine;

namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Dummy object which can be used to set viewpoints into the scene.
    /// Will remove its camera component on runtime start and can be used in combination with <see cref="SpectatorCamera"/>.
    /// </summary>
    [ExecuteInEditMode]
    public class SpectatorCameraDummy : MonoBehaviour
    {
        [SerializeField]
        private string cameraName = "Spectator Camera";

        public string CameraName => cameraName;

        public void Awake()
        {
            if (gameObject.GetComponent<Camera>() == null)
            {
                if (Application.isEditor && Application.isPlaying == false)
                {
                    gameObject.AddComponent<Camera>();
                }
            }
            else
            {
                if (Application.isPlaying)
                {
                    Destroy(gameObject.GetComponent<Camera>());
                }
            }
        }
    }
}