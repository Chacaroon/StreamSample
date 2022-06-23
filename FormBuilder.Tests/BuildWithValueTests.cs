using FormBuilder.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace FormBuilder.Tests;
internal class BuildWithValueTests
{
    static DateTime[] TestDateTimes = new[] { new DateTime(2022, 01, 01) };
    static Guid[] TestGuids = new[] { Guid.Parse("6781b663-2e17-4e22-bb97-cae44772eb7b") };
    static object[] TestObjects = new[] { new object() };

    static TestClass[] TestClasses = new[] { new TestClass() { NestedProperty = 5 } };
    static TestStruct[] TestStructs = new[] { new TestStruct() { NestedProperty = 5 } };

    static int[][] TestIntCollections = new[] { new[] { 5 } };
    static ITestDataStructure[][] TestClassCollections = new[]
    {
        new[] { new TestClass { NestedProperty = 5 } as ITestDataStructure }
    };

    private IServiceProvider _services;

    [SetUp]
    public void SetUp()
    {
        var services = new ServiceCollection();

        services.AddFormBuilder();
        _services = services.BuildServiceProvider();
    }

    [TestCase(5)]
    [TestCase(true)]
    [TestCase("test string")]
    [TestCaseSource(nameof(TestDateTimes))]
    [TestCaseSource(nameof(TestGuids))]
    [TestCaseSource(nameof(TestObjects))]
    public void Build_PrimitiveType_ReturnsFormControlWithValue(object value)
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create(value);
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        // TODO: Check if result is FormControl
        // TODO: Check if result.Value == value
    }

    [TestCaseSource(nameof(TestClasses))]
    [TestCaseSource(nameof(TestStructs))]
    public void Build_ComplexType_ReturnsFormGroupWithValue(ITestDataStructure value)
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create(value);
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        // TODO: Check if result is FormGroup
        // TODO: Check if result["nestedProperty"].Value == value
    }

    [TestCaseSource(nameof(TestIntCollections))]
    public void Build_CollectionTypeWithPrimitive_ReturnsFormArrayWithValue(int[] value)
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create(value);
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        // TODO: Check if result is FormArray
        // TODO: Check if result[0] is FormControl
        // TODO: Check if result[0].Value == value[0]
    }

    [TestCaseSource(nameof(TestClassCollections))]
    public void Build_CollectionTypeWithClass_ReturnsFormArrayWithValue(ITestDataStructure[] value)
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create(value);
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        // TODO: Check if result is FormArray
        // TODO: Check if result[0] is FormGroup
        // TODO: Check if result[0]["nestedProperty"].Value == value[0].NestedProperty
    }

    #region TestData

    class TestClass : ITestDataStructure
    {
        public int NestedProperty { get; set; }
    }

    struct TestStruct : ITestDataStructure
    {
        public int NestedProperty { get; set; }
    }

    public interface ITestDataStructure
    {
        int NestedProperty { get; set; }
    }

    #endregion

}
