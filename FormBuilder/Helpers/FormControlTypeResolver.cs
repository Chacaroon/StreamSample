using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Helpers;
internal static class FormControlTypeResolver
{
    private static Type[] PrimitiveTypes = new[]
    {
        typeof(string),
        typeof(Guid),
        typeof(DateTime),
        typeof(object)
    };

    internal static bool IsFormControl(Type type)
    {
        return type.IsPrimitive
            || type.IsEnum
            || PrimitiveTypes.Contains(type);
    }
    internal static bool IsFormArray(Type type)
    {
        return type.IsAssignableTo(typeof(IEnumerable));
    }

    internal static bool IsFormGroup(Type type)
    {
        return !IsFormControl(type) && !IsFormArray(type);
    }
}
