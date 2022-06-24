using FormBuilder.Helpers;
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
        FormGroup result = null;

        // Act
        var action = () => result = (FormGroup)formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        Assert.That(
            result!.Controls[nameof(TestClass.RequiredProperty).FirstCharToLowerCase()].Validators.Count(),
            Is.EqualTo(1));
        Assert.That(
            result!.Controls[nameof(TestClass.RequiredProperty).FirstCharToLowerCase()].Validators[0].Type,
            Is.EqualTo(ValidatorType.Required));

        Assert.That(
            result!.Controls[nameof(TestClass.MinMaxLengthProperty).FirstCharToLowerCase()].Validators.Count(),
            Is.EqualTo(2));
        Assert.Contains(ValidatorType.MinLength,
            result!.Controls[nameof(TestClass.MinMaxLengthProperty).FirstCharToLowerCase()].Validators.Select(x => x.Type).ToList());
        Assert.Contains(ValidatorType.MaxLength,
            result!.Controls[nameof(TestClass.MinMaxLengthProperty).FirstCharToLowerCase()].Validators.Select(x => x.Type).ToList());
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
