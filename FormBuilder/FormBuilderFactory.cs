using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder;
public class FormBuilderFactory
{
    public FormBuilder Create<T>()
    {
        return new FormBuilder();
    }

    public FormBuilder Create<T>(T value)
    {
        return new FormBuilder();
    }

    public FormBuilder Create(object value)
    {
        return new FormBuilder();
    }

    public FormBuilder Create(object value, Type type)
    {
        return new FormBuilder();
    }
}
