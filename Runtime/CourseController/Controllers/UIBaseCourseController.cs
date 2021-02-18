using System;
using System.Collections.Generic;
using UnityEngine;

namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Base course controller which also takes care that a course menu is spawned.
    /// </summary>
    public abstract class UIBaseCourseController : BaseCourseController
    {
        public abstract string CourseMenuPrefabName { get; }
        
        /// <summary>
        /// Gets a course controller menu game object.
        /// </summary>
        public virtual GameObject GetCourseMenuPrefab()
        {
            return Resources.Load<GameObject>($"Prefabs/{CourseMenuPrefabName}");
        }

        /// <inheritdoc />
        public override List<Type> GetRequiredSetupComponents()
        {
            return new List<Type> {typeof(CourseMenuSpawner)};
        }

        /// <inheritdoc />
        public override void SetupDone(GameObject courseControllerObject)
        {
            courseControllerObject.GetComponent<CourseMenuSpawner>().SetDefaultPrefab(GetCourseMenuPrefab());
        }
    }
}