using FormBuilder.Models;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace FormBuilder.Tests;
internal class ValidatorsTests
{
    private IServiceProvider _services;

    [SetUp]
    public void SetUp()
    {
        var services = new ServiceCollection();

        services.AddFormBuilder();
        _services = services.BuildServiceProvider();
    }

    [Test]
    public void Buid_ModelWithValidators_ReturnsControlsWithValidators()
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create<TestClass>();
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        Assert.DoesNotThrow(() => action());
    }

    #region TestData

    class TestClass
    {
        [Required]
        public string RequiredProperty { get; set; }

        [MinLength(5)]
        [MaxLength(10)]
        public string MinMaxLengthProperty { get; set; }
    }

    #endregion
}
