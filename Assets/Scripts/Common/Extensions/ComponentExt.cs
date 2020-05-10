using System;

namespace Common.Extensions
{
    public static class ComponentExt
    {
        public static T Ref<T>(this T component) where T : UnityEngine.Object
        {
            return component == null ? null : component;
        }

        public static void DoIfNotNull<T>(this T component, Action<T> action) where T : UnityEngine.Object
        {
            if (component != null)
            {
                action.Invoke(component);
            }
        }
    }
}