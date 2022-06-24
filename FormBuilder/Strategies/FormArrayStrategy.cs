using FormBuilder.Helpers;
using FormBuilder.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Strategies;
internal class FormArrayStrategy : BaseStrategy
{
    private readonly StrategyResolver _strategyResolver;

    public FormArrayStrategy(StrategyResolver strategyResolver)
    {
        _strategyResolver = strategyResolver;
    }

    public override bool IsStrategyApplicable(Type type, StrategyResolverOptions strategyResolverOptions)
    {
        return FormControlTypeResolver.IsFormArray(type) && !strategyResolverOptions.IsFormValue;
    }

    public override AbstractControl Process(Type type)
    {
        var collectionItemType = GetCollectionItemType(type);

        var values = ((IEnumerable)Value)?.Cast<object>() ?? Array.Empty<object>();

        var controls = values.Select(x => _strategyResolver
            .Resolve(collectionItemType)!
            .AddValue(x)
            .Process(collectionItemType));

        return new FormArray
        {
            Controls = controls,
            ControlSchema = _strategyResolver.Resolve(collectionItemType)!.Process(collectionItemType)
        };
    }

    private Type GetCollectionItemType(Type type)
    {
        var interfaces = type.GetInterfaces().Concat(new[] { type });

        var enumerableInterfaceType = interfaces.FirstOrDefault(x =>
            x.IsGenericType
            && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));

        var collectionItemType = enumerableInterfaceType?
            .GetGenericArguments()
            .Single();

        return collectionItemType ?? typeof(object);
    }
}
