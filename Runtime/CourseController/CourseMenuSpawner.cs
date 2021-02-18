using UnityEngine;

namespace Innoactive.Creator.UX
{
    public class CourseMenuSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject defaultPrefab;
        
        [SerializeField] 
        private bool useCustomPrefab;
        
        [SerializeField]
        private GameObject customPrefab;

        [SerializeField] 
        private bool keepOneMenu = true;

        private GameObject currentMenu;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            Debug.Log("Default: " + defaultPrefab);
            GameObject prefab;
            if (useCustomPrefab)
            {
                if (customPrefab == null)
                {
                    Debug.LogError("Custom prefab in Course Menu Spawner is not set.");
                    return;
                }

                prefab = customPrefab;
            }
            else
            {
                prefab = defaultPrefab;
            }

            currentMenu = Instantiate(prefab);
        }

        public void SetDefaultPrefab(GameObject prefab)
        {
            defaultPrefab = prefab;
        }
    }
}