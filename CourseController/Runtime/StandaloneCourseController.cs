namespace Innoactive.Creator.UX
{
    /// <summary>
    /// Course controller for standalone devices like the Oculus Quest.
    /// </summary>
    public class StandaloneCourseController : BaseCourseController
    {
        public override string Name { get; } = "Standalone";
        public override int Priority { get; } = 25;
        protected override string PrefabName { get; } = "StandaloneCourseController";
    }
}