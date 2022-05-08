using System.Linq;
using AutoFixture;
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
    [InlineData("T", "t")]
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
        var actualResult = sourceString.ToLowerStartOp();

        actualResult.Should().BeEquivalentTo(resultString);
    }
    
    [Fact]
    public void ToLowerCase_LongStringWithNoOptimisation_ReturnLowCase()
    {
        var inputChars = new Fixture().CreateMany<char>(2000).ToArray();
        inputChars[0] = 'T';
        var inputString = new string(inputChars);
        // Just to check that test data is OK
        inputString![0].Should().Be('T');

        inputChars[0] = 't';
        var expectedString = new string(inputChars);
        expectedString![0].Should().Be('t');
        
        
        var resultString = inputString.ToLowerStartOp();

        resultString.Should().BeEquivalentTo(expectedString);
    }
}