using Innoactive.Creator.Unity;
using Innoactive.Creator.UX;
using UnityEditor;
using UnityEngine;

namespace Innoactive.CreatorEditor.UX
{
    /// <summary>
    /// Will be called on OnSceneSetup to add the course controller menu.
    /// </summary>
    public class CourseControllerSceneSetup : SceneSetup
    {
        /// <inheritdoc />
        public override int Priority { get; } = 20;
        
        /// <inheritdoc />
        public override string Key { get; } = "CourseControllerSetup";
        
        /// <inheritdoc />
        public override void Setup()
        {
            GameObject courseController = SetupPrefab("[COURSE_CONTROLLER]");
            if (courseController != null)
            {
                courseController.GetOrAddComponent<CourseControllerSetup>().ResetToDefault();
            }

            if (courseController == null)
            {
                courseController = GameObject.Find("[COURSE_CONTROLLER]");
            }
            Selection.activeGameObject = courseController;
        }
    }
}