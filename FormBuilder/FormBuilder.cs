using FormBuilder.Models;
using FormBuilder.Strategies;

namespace FormBuilder;

public class FormBuilder
{
    private readonly Type _type;
    private readonly BaseStrategy? _baseStrategy;

    internal FormBuilder(Type type, Strategies.BaseStrategy? baseStrategy)
    {
        _type = type;
        _baseStrategy = baseStrategy;
    }

    public AbstractControl Build()
    {
        if (_baseStrategy == null)
        {
            throw new NotImplementedException(_type.Name);
        }

        return _baseStrategy.Process(_type);
    }
}



