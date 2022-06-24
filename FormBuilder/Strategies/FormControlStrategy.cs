using FormBuilder.Helpers;
using FormBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Strategies;
internal class FormControlStrategy : BaseStrategy
{
    public override bool IsStrategyApplicable(Type type, StrategyResolverOptions strategyResolverOptions)
    {
        return FormControlTypeResolver.IsFormControl(type) || strategyResolverOptions.IsFormValue;
    }

    public override AbstractControl Process(Type type)
    {
        return new FormControl()
        {
            Value = Value,
            Validators = Validators
        };
    }
}
