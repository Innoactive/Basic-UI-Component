﻿using System;
using System.Collections.Generic;
using Innoactive.Creator.Core.Configuration;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Default course controller.
    /// </summary>
    public class DefaultCourseController : UIBaseCourseController
    {
        /// <inheritdoc />
        public override string Name { get; } = "Default";

        /// <inheritdoc />
        protected override string PrefabName { get; } = "DefaultCourseController";

        /// <inheritdoc />
        public override int Priority { get; } = 50;

        /// <inheritdoc />
        public override string CourseMenuPrefabName { get; } = "CourseControllerMenu";

        /// <inheritdoc />
        public override List<Type> GetRequiredSetupComponents()
        {
            List<Type> requiredSetupComponents = base.GetRequiredSetupComponents();
            requiredSetupComponents.Add(typeof(SpectatorController));
            requiredSetupComponents.Add(typeof(PlayerInput));
            return requiredSetupComponents;
        }
    }
}
