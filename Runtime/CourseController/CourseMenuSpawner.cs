using UnityEngine;

namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Spawns a course menu in the scene.
    /// </summary>
    public class CourseMenuSpawner : MonoBehaviour
    {
        [Tooltip("Default menu prefab")]
        [SerializeField]
        private GameObject defaultPrefab;
        
        [Tooltip("Use a custom menu prefab instead of default")]
        [SerializeField] 
        private bool useCustomPrefab;
        
        [Tooltip("Custom menu prefab")]
        [SerializeField]
        private GameObject customPrefab;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            GameObject prefab;
            if (useCustomPrefab)
            {
                if (customPrefab == null)
                {
                    Debug.LogError("Custom prefab in CourseMenuSpawner is not set.");
                    return;
                }

                prefab = customPrefab;
            }
            else
            {
                prefab = defaultPrefab;
            }

            Instantiate(prefab);
        }

        public void SetDefaultPrefab(GameObject prefab)
        {
            defaultPrefab = prefab;
        }
    }
}