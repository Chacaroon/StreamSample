using FormBuilder.Attributes;
using FormBuilder.Models;
using FormBuilder.Strategies;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Validator = FormBuilder.Models.Validator;

namespace FormBuilder;
public class StrategyResolver
{
    private Lazy<IEnumerable<BaseStrategy>> _baseStrategies;

    public StrategyResolver(IServiceProvider services)
    {
        _baseStrategies = new Lazy<IEnumerable<BaseStrategy>>(services.GetServices<BaseStrategy>);
    }

    public BaseStrategy? Resolve(Type type)
    {
        var isFormValue = (type.GetCustomAttribute<FormValueAttribute>(true))
            != null;

        var strategyOptions = new StrategyResolverOptions()
        {
            IsFormValue = isFormValue
        };

        return _baseStrategies.Value.FirstOrDefault(x => 
            x.IsStrategyApplicable(type, strategyOptions));
    }

    public BaseStrategy? Resolve(PropertyInfo propertyInfo)
    {
        var isFormValue = (propertyInfo.GetCustomAttribute<FormValueAttribute>(true) 
            ?? propertyInfo.PropertyType.GetCustomAttribute<FormValueAttribute>(true))
            != null;

        var strategyOptions = new StrategyResolverOptions()
        {
            IsFormValue = isFormValue
        };

        return _baseStrategies.Value
            .First(x => 
                x.IsStrategyApplicable(propertyInfo.PropertyType, strategyOptions))
            .AddValidators(GetValidators(propertyInfo));
    }

    private Validator[] GetValidators(PropertyInfo propertyInfo)
    {
        var validatorProcessors = new Dictionary<Type, Func<ValidationAttribute, Validator>>
        {
            {
                typeof(RequiredAttribute),
                (_) => new Validator(ValidatorType.Required, Array.Empty<object>())
            },
            {
                typeof(MinLengthAttribute),
                (x) => 
                    new Validator(ValidatorType.MinLength, 
                        new[] { ((MinLengthAttribute)x).Length as object })
            },
            {
                typeof(MaxLengthAttribute),
                (x) =>
                    new Validator(ValidatorType.MaxLength,
                        new[] { ((MaxLengthAttribute)x).Length as object })
            }
        };

        var validators = propertyInfo.GetCustomAttributes()
            .Where(x => validatorProcessors.ContainsKey(x.GetType()))
            .Cast<ValidationAttribute>()
            .Select(x => validatorProcessors[x.GetType()](x))
            .ToArray();

        return validators;
    }
}
