using System;
using System.ComponentModel;
using DotNetEveryDay.Extensions.Extensions;
using FluentAssertions;
using Xunit;

namespace DotNetEveryDay.Extensions.Tests.Tests;

public class AttributeExtensionsTests
{
    private const string SomeTestDescription = "SomeTestDescription";

    [Fact]
    public void GetAttribute_AttributeIsExist_ReturnAttribute()
    {
        var actualResult = typeof(TypeWithField).GetPropertyAttribute<DescriptionAttribute>(nameof(TypeWithField.FieldWithAttribute));
        
        Assert.NotNull(actualResult);
        Assert.Equal(SomeTestDescription, actualResult!.Description);
    }
    
    [Fact]
    public void GetAttribute_AttributeDoesntExist_ReturnNull()
    {
        var actualResult = typeof(TypeWithField).GetPropertyAttribute<DescriptionAttribute>(nameof(TypeWithField.FieldWithNoAttribute));
        
        Assert.Null(actualResult);
    }
    
    [Fact]
    public void GetAttribute_FieldDoesntExist_ReturnNull()
    {
        var actualResult = typeof(TypeWithField).GetPropertyAttribute<DescriptionAttribute>("FakeName");
        
        Assert.Null(actualResult);
    }

    [Fact]
    public void GetAttribute_TypeIsNull_ThrowException()
    {
        // ReSharper disable once ConvertToLocalFunction
        var getPropertyAction = () => ((Type) null!).GetPropertyAttribute<DescriptionAttribute>("FakeName");
        
        Assert.Throws<ArgumentNullException>(getPropertyAction);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GetAttribute_PropertyNameIsNullOrEmpty_ReturnNull(string propertyName)
    {
        var actualResult = typeof(TypeWithField).GetPropertyAttribute<DescriptionAttribute>(propertyName);

        actualResult.Should().BeNull();
    }

    private record TypeWithField
    {
        [Description(SomeTestDescription)]
        public string? FieldWithAttribute {get; set; }
        
        public string? FieldWithNoAttribute {get; set; }
    }
}