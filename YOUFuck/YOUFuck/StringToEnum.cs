using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOUFuck
{
    internal static class StringToEnum
    {
        internal static T Convert<T>(string stringToConvert)
        {
            if(!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("'" + typeof(T).Name + "' is not a valid enum type.");
            }
            return (T)Enum.Parse(typeof(T), stringToConvert);
        }
    }
}
