using FormBuilder.Models;

namespace FormBuilder;

public class FormBuilder
{
    private FormBuilder()
    {
    }

    public static FormBuilder Create<T>()
    {
        return new FormBuilder();
    }

    public static FormBuilder Create<T>(T value)
    {
        return new FormBuilder();
    }

    public static FormBuilder Create(object value)
    {
        return new FormBuilder();
    }

    public static FormBuilder Create(object value, Type type)
    {
        return new FormBuilder();
    }

    public AbstractControl Build()
    {
        throw new NotImplementedException();
    }
}



