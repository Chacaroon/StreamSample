using FormBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Strategies;
public abstract class BaseStrategy
{
    internal object Value { get; private set; }

    internal Validator[] Validators { get; private set; }

    public abstract bool IsStrategyApplicable(Type type, StrategyResolverOptions strategyOptions);

    public abstract AbstractControl Process(Type type);

    public BaseStrategy AddValue(object value)
    {
        Value = value;

        return this;
    }

    public BaseStrategy AddValidators(Validator[] validators)
    {
        Validators = validators;

        return this;
    }


}
