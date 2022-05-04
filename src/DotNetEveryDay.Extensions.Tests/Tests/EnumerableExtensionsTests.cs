using System.Collections.Generic;
using IdentityServer4.Helpers.Extensions;
using Xunit;

namespace DotNetEveryDay.Extensions.Tests.Tests;

public class EnumerableExtensionsTests
{
    [Fact]
    public void HasDuplicates_Has_ReturnTrue()
    {
        var collection = new[] {1, 2, 3, 3};
        var result = collection.HasDuplicates(i => i);
        Assert.True(result);
    }
        
    [Fact]
    public void HasDuplicates_DoesNotHave_ReturnFalse()
    {
        var collection = new[] {1, 2, 3};
        var result = collection.HasDuplicates(i => i);
        Assert.False(result);
    }
        
    [Fact]
    public void HasDuplicates_EmptyCollection_ReturnFalse()
    {
        var collection = new int[] {};
        var result = collection.HasDuplicates(i => i);
        Assert.False(result);
    }
        
    [Fact]
    public void HasDuplicates_NullCollection_ReturnFalse()
    {
        var collection = (IEnumerable<int>?)null;
        var result = collection.HasDuplicates(i => i);
        Assert.False(result);
    }
        
    [Fact]
    public void IsNullOrEmpty_NullCollection_ReturnTrue()
    {
        var collection = (IEnumerable<int>?)null;
        var result = collection.IsNullOrEmpty();
        Assert.True(result);
    }
        
    [Fact]
    public void IsNullOrEmpty_EmptyCollection_ReturnTrue()
    {
        var collection = new int[] {};
        var result = collection.IsNullOrEmpty();
        Assert.True(result);
    }
        
    [Fact]
    public void IsNullOrEmpty_NotEmptyCollection_ReturnFalse()
    {
        var collection = new [] {1, 2};
        var result = collection.IsNullOrEmpty();
        Assert.False(result);
    }
}