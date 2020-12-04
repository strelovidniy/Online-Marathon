using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sprint_11.Task_03
{
    public static class ReflectionExt
    {
        public static readonly List<Access_Modifier> AccessModifiers = new List<Access_Modifier>
        {
            Access_Modifier.Private,
            Access_Modifier.Protected,
            Access_Modifier.ProtectedInternal,
            Access_Modifier.Internal,
            Access_Modifier.Public
        };

        public static Access_Modifier AccessModifier(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.SetMethod == null)
            {
                return propertyInfo.GetMethod.AccessModifier();
            }
            if (propertyInfo.GetMethod == null)
            {
                return propertyInfo.SetMethod.AccessModifier();
            }

            return AccessModifiers[Math.Max(AccessModifiers.IndexOf(propertyInfo.GetMethod.AccessModifier()),
                AccessModifiers.IndexOf(propertyInfo.SetMethod.AccessModifier()))];
        }

        public static Access_Modifier AccessModifier(this MethodInfo methodInfo)
        {
            if (methodInfo.IsPrivate)
            {
                return Access_Modifier.Private;
            }
            if (methodInfo.IsFamily)
            {
                return Access_Modifier.Protected;
            }
            if (methodInfo.IsFamilyOrAssembly)
            {
                return Access_Modifier.ProtectedInternal;
            }
            if (methodInfo.IsAssembly)
            {
                return Access_Modifier.Internal;
            }
            if (methodInfo.IsPublic)
            {
                return Access_Modifier.Public;
            }
            throw new ArgumentException("Did not find access modifier", "methodInfo");
        }
    }
}
