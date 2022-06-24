using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder;
public class FormBuilderFactory
{
    private readonly StrategyResolver _strategyResolver;

    public FormBuilderFactory(StrategyResolver strategyResolver)
    {
        _strategyResolver = strategyResolver;
    }

    public FormBuilder Create<T>()
    {
        return CreateInternal(typeof(T));
    }

    public FormBuilder Create<T>(T value)
    {
        return CreateInternal(typeof(T));
    }

    public FormBuilder Create(Type type)
    {
        return CreateInternal(type);
    }

    public FormBuilder Create(object value, Type type)
    {
        return CreateInternal(type, value);
    }

    private FormBuilder CreateInternal(Type type, object? value = null)
    {
        return new FormBuilder(type, _strategyResolver.Resolve(type));
    }
}
