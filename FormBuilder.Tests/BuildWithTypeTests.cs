using FormBuilder.Helpers;
using FormBuilder.Models;
using Microsoft.Extensions.DependencyInjection;

namespace FormBuilder.Tests;

public class BuildWithTypeTests
{
    private IServiceProvider _services;

    [SetUp]
    public void SetUp()
    {
        var services = new ServiceCollection();

        services.AddFormBuilder();
        _services = services.BuildServiceProvider();
    }

    [TestCase(typeof(int))]
    [TestCase(typeof(bool))]
    [TestCase(typeof(string))]
    [TestCase(typeof(DateTime))]
    [TestCase(typeof(Guid))]
    [TestCase(typeof(object))]
    public void Build_PrimitiveType_ReturnsFormControl(Type type)
    {
        // Arrange
        var formBuilder  = _services.GetRequiredService<FormBuilderFactory>().Create(type);
        AbstractControl? result = null; 

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        Assert.IsInstanceOf<FormControl>(result);
    }

    [TestCase(typeof(TestClass))]
    [TestCase(typeof(TestStruct))]
    public void Build_ComplexType_ReturnsFormGroup(Type type)
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create(type);
        AbstractControl? result = null;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        Assert.IsInstanceOf(typeof(FormGroup), result);
        Assert.IsInstanceOf(
            typeof(FormGroup),
            ((FormGroup) result).Controls[nameof(TestClass.NestedGroup).FirstCharToLowerCase()]);
        Assert.IsInstanceOf(
            typeof(FormControl),
            ((FormGroup)result).Controls[nameof(TestClass.NestedControl).FirstCharToLowerCase()]);
        Assert.IsInstanceOf(
            typeof(FormArray),
            ((FormGroup)result).Controls[nameof(TestClass.NestedArray).FirstCharToLowerCase()]);
    }

    [TestCase(typeof(IEnumerable<int>))]
    [TestCase(typeof(int[]))]
    [TestCase(typeof(TestClass[]))]
    public void Build_CollectionType_ReturnsFormArray(Type type)
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create(type);
        AbstractControl result = null;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        Assert.IsInstanceOf(typeof(FormArray), result);
    }

    #region TestData

    class TestClass
    {
        public int NestedControl { get; set; }

        public NestedTestClass NestedGroup { get; set; }

        public IEnumerable<int> NestedArray { get; set; }
    }

    class NestedTestClass
    {
    }

    struct TestStruct
    {
        public int NestedControl { get; set; }

        public NestedTestStruct NestedGroup { get; set; }

        public IEnumerable<int> NestedArray { get; set; }
    }

    struct NestedTestStruct
    {
    }
    #endregion
}
