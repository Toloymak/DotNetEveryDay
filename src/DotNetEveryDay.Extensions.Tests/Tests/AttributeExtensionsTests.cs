using System.ComponentModel;
using DotNetEveryDay.Extensions.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace DotNetEveryDay.Extensions.Tests.Tests;

public class AttributeExtensionsTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    
    private const string SomeTestDescription = "SomeTestDescription";
    
    public AttributeExtensionsTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void GetAttribute_AttributeIsExist_ReturnAttribute()
    {
        var someResult = typeof(TypeWithField).GetAttribute<DescriptionAttribute>(nameof(TypeWithField.FieldWithAttribute));
        
        Assert.NotNull(someResult);
        Assert.Equal(SomeTestDescription, someResult.Description);
    }
    
    [Fact]
    public void GetAttribute_AttributeDoesntExist_ReturnNull()
    {
        var someResult = typeof(TypeWithField).GetAttribute<DescriptionAttribute>(nameof(TypeWithField.FieldWithNoAttribute));
        
        Assert.Null(someResult);
    }

    private record TypeWithField
    {
        [Description(SomeTestDescription)] public string? FieldWithAttribute {get; set; }
        
        public string? FieldWithNoAttribute {get; set; }
    }
}