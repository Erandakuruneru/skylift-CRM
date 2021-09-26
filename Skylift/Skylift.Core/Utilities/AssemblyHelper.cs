// <copyright file="AssemblyHelper.cs" company="Mazarin (Pvt) Ltd.">
// Copyright (c) Mazarin (Pvt) Ltd.. All Rights Reserved.
// .
// </copyright>

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Skylift.Core.Utilities
{
    /// <summary>
    /// Assembly Helper
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Gets the full name of the method.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>name</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMethodFullName(string className)
        {
            var st = new StackTrace(new StackFrame(1));
            return className + "." + st.GetFrame(0).GetMethod().Name;
        }
    }
}
