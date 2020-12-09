﻿using System;
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
        /// <inheritdoc />
        public abstract string Name { get; }

        /// <inheritdoc />
        public abstract int Priority { get; }

        /// <summary>
        /// Name of the course controller prefab.
        /// </summary>
        protected abstract string PrefabName { get; }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public virtual List<Type> GetRequiredSetupComponents() 
        {
            return new List<Type>();
        }
    }
}