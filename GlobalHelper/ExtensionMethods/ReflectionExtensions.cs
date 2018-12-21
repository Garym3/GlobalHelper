using System.Collections.Generic;
using System.Reflection;

namespace GlobalHelper.ExtensionMethods
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Retrieves the values of an object alongside their respective property and pushes them in a dictionary
        /// </summary>
        /// <param name="anObject">The object</param>
        /// <param name="flags">Flags</param>
        /// <returns>A dictionary containing the values of the obejct and theire respective property</returns>
        public static IDictionary<string, object> ToDictionaryProperties(this object anObject, BindingFlags flags)
        {
            if (anObject == null) return new Dictionary<string, object>();
            var type = anObject.GetType();
            var properties = type.GetProperties(flags);
            var dict = new Dictionary<string, object>();

            foreach (var prp in properties)
            {
                var value = prp.GetValue(anObject, new object[] { });
                dict.Add(prp.Name, value);
            }

            return dict;
        }
    }
}
