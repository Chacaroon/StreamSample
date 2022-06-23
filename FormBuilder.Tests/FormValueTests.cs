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
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Arrange
        Assert.DoesNotThrow(() => action());
        // TODO: Check if result is FormControl
    }

    [Test]
    public void Build_ModelWithFormValueProperty_FormControl()
    {
        // Arrange
        var formBuilder = _services.GetRequiredService<FormBuilderFactory>().Create<ModelWithFormValueProperty>();
        AbstractControl result;

        // Act
        var action = () => result = formBuilder.Build();

        // Arrange
        Assert.DoesNotThrow(() => action());
        // TODO: Check if result is FormGroup
        // TODO: Check if result["value"] is FormControl
    }

    #region TestData 

    // TODO: [FormValue]
    class ModelWithFormValueAttribute
    {
        public string Value { get; set; }
    }

    class ModelWithFormValueProperty
    {
        // TODO: [FormValue]
        public IEnumerable<string> Value { get; set; }
    }

    #endregion
}
