using FormBuilder.Models;

namespace FormBuilder.Tests;

public class BuildWithTypeTests
{
    [TestCase(typeof(int))]
    [TestCase(typeof(bool))]
    [TestCase(typeof(string))]
    [TestCase(typeof(DateTime))]
    [TestCase(typeof(Guid))]
    [TestCase(typeof(object))]
    public void Build_PrimitiveType_ReturnsFormControl(Type type)
    {
        // Arrange
        var formBuilder  = FormBuilder.Create(type);
        AbstractControl result; 

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
    }

    [TestCase(typeof(TestClass))]
    [TestCase(typeof(TestStruct))]
    public void Build_ComplexType_ReturnsFormGroup(Type type)
    {
        // Arrange
        var formBuilder = FormBuilder.Create(type);
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
    }

    [TestCase(typeof(IEnumerable<int>))]
    [TestCase(typeof(int[]))]
    [TestCase(typeof(TestClass[]))]
    public void Build_CollectionType_ReturnsFormArray(Type type)
    {
        // Arrange
        var formBuilder = FormBuilder.Create(type);
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
    }

    #region TestData

    class TestClass
    {
        public NestedTestClass NestedTestClass { get; set; }
    }

    class NestedTestClass
    {
    }

    struct TestStruct
    {
        public NestedTestStruct NestedTestStruct { get; set; }
    }

    struct NestedTestStruct
    {
    }

    #endregion
}
