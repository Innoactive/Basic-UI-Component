﻿namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Course controller for standalone devices like the Oculus Quest.
    /// </summary>
    public class StandaloneCourseController : UIBaseCourseController
    {
        /// <inheritdoc />
        public override string Name { get; } = "Standalone";
        
        /// <inheritdoc />
        public override int Priority { get; } = 25;
        
        /// <inheritdoc />
        protected override string PrefabName { get; } = "StandaloneCourseController";
        
        /// <inheritdoc />
        public override string CourseMenuPrefabName { get; } = "StandaloneCourseControllerMenu";
    }
}