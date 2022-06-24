using FormBuilder.Helpers;
using FormBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Strategies;
internal class FormGroupStrategy : BaseStrategy
{
    private readonly StrategyResolver _strategyResolver;

    public FormGroupStrategy(StrategyResolver strategyResolver)
    {
        _strategyResolver = strategyResolver;
    }

    public override bool IsStrategyApplicable(Type type, StrategyResolverOptions strategyResolverOptions)
    {
        return FormControlTypeResolver.IsFormGroup(type) && !strategyResolverOptions.IsFormValue;
    }

    public override AbstractControl Process(Type type)
    {
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var controls = properties.ToDictionary(
            x => x.Name.FirstCharToLowerCase(),
            x => _strategyResolver.Resolve(x)!.Process(x.PropertyType));

        return new FormGroup()
        {
            Controls = controls
        };
    }
}
