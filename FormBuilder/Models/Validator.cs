namespace FormBuilder.Models;

public class Validator
{
    public ValidatorType Type { get; internal set; }

    public object[] Options { get; set; }

    public Validator(ValidatorType type, object[] options)
    {
        Type = type;
        Options = options;
    }
}

public enum ValidatorType
{
    Required = 1,
    MinLength = 2,
    MaxLength = 3,
}
