using FormBuilder.Models;
using System.ComponentModel.DataAnnotations;

namespace FormBuilder.Tests;
internal class ValidatorsTests
{
    public void Buid_ModelWithValidators_ReturnsControlsWithValidators()
    {
        // Arrange
        var formBuilder = FormBuilder.Create<TestClass>();
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
