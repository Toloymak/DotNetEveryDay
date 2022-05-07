using DotNetEveryDay.Extensions.Extensions;
using FluentAssertions;
using Xunit;

namespace DotNetEveryDay.Extensions.Tests.Tests;

public class StringExtensions
{
    [Theory]
    [InlineData("", true)]
    [InlineData(null, true)]
    [InlineData(" ", false)]
    [InlineData("TestString", false)]
    public void IsNullOrEmpty(string sourceString, bool expectedResult)
    {
        var actualResult = sourceString.IsNullOrEmpty();

        actualResult.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("", true)]
    [InlineData(null, true)]
    [InlineData(" ", true)]
    [InlineData("TestString", false)]
    public void IsNullOrWhiteSpace(string sourceString, bool expectedResult)
    {
        var actualResult = sourceString.IsNullOrWhiteSpace();

        actualResult.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData(" ", " ")]
    [InlineData("TestString", "TestString")]
    [InlineData("testString", "TestString")]
    [InlineData("test String", "Test String")]
    [InlineData("test string", "Test string")]
    [InlineData("Test string", "Test string")]
    public void ToTitleCase(string sourceString, string resultString)
    {
        var actualResult = sourceString.ToTitleCase();

        actualResult.Should().BeEquivalentTo(resultString);
    }
    
    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData(" ", " ")]
    [InlineData("TestString", "teststring")]
    [InlineData("testString", "teststring")]
    [InlineData("test String", "test string")]
    [InlineData("test string", "test string")]
    [InlineData("Test string", "test string")]
    public void ToLowerCase(string sourceString, string resultString)
    {
        var actualResult = sourceString.ToLowerCase();

        actualResult.Should().BeEquivalentTo(resultString);
    }
    
    [Theory]
    [InlineData("", "")]
    [InlineData(null, null)]
    [InlineData(" ", " ")]
    [InlineData("TestString", "testString")]
    [InlineData("testString", "testString")]
    [InlineData("test String", "test String")]
    [InlineData("test string", "test string")]
    public void ToLowerStart(string sourceString, string resultString)
    {
        var actualResult = sourceString.ToLowerStart();

        actualResult.Should().BeEquivalentTo(resultString);
    }
}