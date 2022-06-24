using FormBuilder.Attributes;
using FormBuilder.Helpers;
using FormBuilder.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormBuilder.Tests;
internal class FormValueTests
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
    public void Build_ModelWithFormValueAttribute_FormControl()
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create<ModelWithFormValueAttribute>();
        AbstractControl result = null;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        Assert.IsInstanceOf<FormControl>(result);
    }

    [Test]
    public void Build_ModelWithFormValueProperty_FormControl()
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create<ModelWithFormValueProperty>();
        AbstractControl result = null;

        // Act
        var action = () => result = formBuilder.Build();

        // Assert
        Assert.DoesNotThrow(() => action());
        Assert.IsInstanceOf<FormGroup>(result);
        Assert.IsInstanceOf<FormControl>(((FormGroup)result)
            .Controls[nameof(ModelWithFormValueProperty.Value).FirstCharToLowerCase()]);
    }

    #region TestData 

    [FormValue]
    class ModelWithFormValueAttribute
    {
        public string Value { get; set; }
    }

    class ModelWithFormValueProperty
    {
        [FormValue]
        public IEnumerable<string> Value { get; set; }
    }

    #endregion
}
