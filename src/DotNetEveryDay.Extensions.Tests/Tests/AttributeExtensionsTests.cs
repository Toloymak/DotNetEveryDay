using System;
using System.ComponentModel;
using DotNetEveryDay.Extensions.Extensions;
using Xunit;

namespace DotNetEveryDay.Extensions.Tests.Tests;

public class AttributeExtensionsTests
{
    private const string SomeTestDescription = "SomeTestDescription";

    [Fact]
    public void GetAttribute_AttributeIsExist_ReturnAttribute()
    {
        var someResult = typeof(TypeWithField).GetPropertyAttribute<DescriptionAttribute>(nameof(TypeWithField.FieldWithAttribute));
        
        Assert.NotNull(someResult);
        Assert.Equal(SomeTestDescription, someResult!.Description);
    }
    
    [Fact]
    public void GetAttribute_AttributeDoesntExist_ReturnNull()
    {
        var someResult = typeof(TypeWithField).GetPropertyAttribute<DescriptionAttribute>(nameof(TypeWithField.FieldWithNoAttribute));
        
        Assert.Null(someResult);
    }
    
    [Fact]
    public void GetAttribute_FieldDoesntExist_ReturnNull()
    {
        var someResult = typeof(TypeWithField).GetPropertyAttribute<DescriptionAttribute>("FakeName");
        
        Assert.Null(someResult);
    }

    [Fact]
    public void GetAttribute_TypeIsNull_ThrowException()
    {
        // ReSharper disable once ConvertToLocalFunction
        var getPropertyAction = () => ((Type) null!).GetPropertyAttribute<DescriptionAttribute>("FakeName");
        
        Assert.Throws<ArgumentNullException>(getPropertyAction);
    }
    

    private record TypeWithField
    {
        [Description(SomeTestDescription)] public string? FieldWithAttribute {get; set; }
        
        public string? FieldWithNoAttribute {get; set; }
    }
}