using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Base course controller which instantiates a defined prefab.
    /// </summary>
    public abstract class BaseCourseController : ICourseController
    {
        public abstract string Name { get; }

        public abstract int Priority { get; }

        protected abstract string PrefabName { get; }

        public virtual GameObject GetCourseControllerPrefab()
        {
            string filter = $"{PrefabName} t:Prefab";
            string[] prefabsGUIDs = AssetDatabase.FindAssets(filter, null);

            if (prefabsGUIDs.Any() == false)
            {
                throw new FileNotFoundException($"No prefabs found that match \"{PrefabName}\".");
            }

            string assetPath = AssetDatabase.GUIDToAssetPath(prefabsGUIDs.First());
            return AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
        }

        public virtual List<Type> GetRequiredSetupComponents() 
        {
            return new List<Type>();
        }
    }
}