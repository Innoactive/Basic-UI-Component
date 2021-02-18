using System;
using System.Collections.Generic;
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
            if (PrefabName == null)
            {
                return null;
            }
            return Resources.Load<GameObject>($"Prefabs/{PrefabName}");
        }

        /// <inheritdoc />
        public virtual List<Type> GetRequiredSetupComponents() 
        {
            return new List<Type>();
        }

        /// <summary>
        /// Handles post-setup logic.
        /// Should be called after all components are added and object is initialized.
        /// </summary>
        /// <param name="courseControllerObject"></param>
        public virtual void SetupDone(GameObject courseControllerObject)
        {
            // do nothing
        }
    }
}