using FormBuilder.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace FormBuilder.Tests;
internal class BuildWithValueTests
{
    static DateTime[] TestDateTimes = new[] { new DateTime(2022, 01, 01) };
    static Guid[] TestGuids = new[] { Guid.Parse("6781b663-2e17-4e22-bb97-cae44772eb7b") };
    static object[] TestObjects = new[] { new object() };

    static TestClass[] TestClasses = new[] { new TestClass() };
    static TestStruct[] TestStructs = new[] { new TestStruct() };

    static object[][] TestIntCollections = new[] { new[] { 5 as object } };
    static object[][] TestClassCollections = new[] { new[] { new TestClass() as object } };


    [TestCase(5)]
    [TestCase(true)]
    [TestCase("test string")]
    [TestCaseSource(nameof(TestDateTimes))]
    [TestCaseSource(nameof(TestGuids))]
    [TestCaseSource(nameof(TestObjects))]
    public void Build_PrimitiveType_ReturnsFormControlWithValue(object value)
    {
        // Arrange
        var formBuilder = FormBuilder.Create(value);
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
    }

    [TestCaseSource(nameof(TestClasses))]
    [TestCaseSource(nameof(TestStructs))]
    public void Build_ComplexType_ReturnsFormGroupWithValue(object value)
    {
        // Arrange
        var formBuilder = FormBuilder.Create(value);
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
    }

    [TestCaseSource(nameof(TestIntCollections))]
    [TestCaseSource(nameof(TestClassCollections))]
    public void Build_CollectionType_ReturnsFormArrayWithValue(object[] type)
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
