using System;
using System.Collections.Generic;
using UnityEngine;

namespace Innoactive.Creator.UX
{
    public abstract class UIBaseCourseController : BaseCourseController
    {
        public abstract string CourseMenuPrefabName { get; }
        
        /// <inheritdoc />
        public virtual GameObject GetCourseMenuPrefab()
        {
            return Resources.Load<GameObject>($"Prefabs/{CourseMenuPrefabName}");
        }

        /// <inheritdoc />
        public override List<Type> GetRequiredSetupComponents()
        {
            return new List<Type> {typeof(CourseMenuSpawner)};
        }

        public override void SetupDone(GameObject courseControllerObject)
        {
            courseControllerObject.GetComponent<CourseMenuSpawner>().SetDefaultPrefab(GetCourseMenuPrefab());
        }
    }
}