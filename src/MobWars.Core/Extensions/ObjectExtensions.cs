namespace MobWars.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool Exists(this object target)
        {
            return !target.IsNull();
        }

        public static bool IsNull(this object target)
        {
            return target == null;
        }
    }
}