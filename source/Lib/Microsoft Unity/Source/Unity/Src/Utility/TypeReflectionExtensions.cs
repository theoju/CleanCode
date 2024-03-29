﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Practices.Unity.Utility
{
    /// <summary>
    /// Provices extensions mentions to Type due to the introduction of TypeInfo class for Windows 8 Metro-style applications.
    /// </summary>
    public static class TypeReflectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="constructorParameters"></param>
        /// <returns></returns>
        public static ConstructorInfo GetConstructor(this Type type, params Type[] constructorParameters)
        {
            return  type.GetTypeInfo().DeclaredConstructors
                .First(c => ParametersMatch(c.GetParameters(), constructorParameters));
        }

        /// <summary>
        /// Returns the non-static declared methods of a type or its base types.
        /// </summary>
        /// <param name="type">The type to inspect</param>
        /// <returns>An enumerable of the <see cref="MethodInfo"/> objects.</returns>
        public static IEnumerable<MethodInfo> GetMethodsHierarchical(this Type type)
        {
            if (type == null) return Enumerable.Empty<MethodInfo>();

            if (typeof(object).Equals(type))
                return type.GetTypeInfo().DeclaredMethods.Where(m => !m.IsStatic);

            return type.GetTypeInfo().DeclaredMethods.Where(m => !m.IsStatic)
                                                .Concat(GetMethodsHierarchical(type.GetTypeInfo().BaseType));
        }

        /// <summary>
        /// Returns the non-static method of a type or its based type.
        /// </summary>
        /// <param name="type">The type to inspect</param>
        /// <param name="methodName">The method name to seek.</param>
        /// <param name="closedParameters">The (closed) parameter type signature of the method.</param>
        /// <returns>The discovered <see cref="MethodInfo"/></returns>
        public static MethodInfo GetMethodHierarchical(this Type type, string methodName, Type[] closedParameters)
        {
            return type.GetMethodsHierarchical().First(
                    m => m.Name.Equals(methodName) &&
                        ParametersMatch(m.GetParameters(), closedParameters));

        }

        /// <summary>
        /// Returns the declared properties of a type or its base types.
        /// </summary>
        /// <param name="type">The type to inspect</param>
        /// <returns>An enumerable of the <see cref="PropertyInfo"/> objects.</returns>
        public static IEnumerable<PropertyInfo> GetPropertiesHierarchical(this Type type)
        {
            if (type == null) return Enumerable.Empty<PropertyInfo>();

            if (typeof(object).Equals(type))
                return type.GetTypeInfo().DeclaredProperties;

            return type.GetTypeInfo().DeclaredProperties
                                      .Concat(GetPropertiesHierarchical(type.GetTypeInfo().BaseType));
        }

        /// <summary>
        /// Deterines if the types in a parameter set ordinally matches the set of supplied types.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="closedConstructorParameterTypes"></param>
        /// <returns></returns>
        public static bool ParametersMatch(ParameterInfo[] parameters, System.Type[] closedConstructorParameterTypes)
        {
            Microsoft.Practices.Unity.Utility.Guard.ArgumentNotNull(parameters, "parameters");
            Microsoft.Practices.Unity.Utility.Guard.ArgumentNotNull(closedConstructorParameterTypes, "closedConstructorParameterTypes");

            if (parameters.Length != closedConstructorParameterTypes.Length) return false;

            for (int i = 0; i < parameters.Length; i++)
            {
                if (!parameters[i].ParameterType.Equals(closedConstructorParameterTypes[i]))
                    return false;
            }

            return true;
        }
    }
}
