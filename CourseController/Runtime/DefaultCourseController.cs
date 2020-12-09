using System;
using System.Collections.Generic;

namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Default course controller.
    /// </summary>
    public class DefaultCourseController : BaseCourseController
    {
        public override string Name { get; } = "Default";
        
        protected override string PrefabName { get; } = "DefaultCourseController";
        
        public override int Priority { get; } = 50;

        public override List<Type> GetRequiredSetupComponents()
        {
            return new List<Type> { typeof(SpectatorController) };
        }
    }
}