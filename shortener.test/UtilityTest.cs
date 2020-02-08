using Xunit;
using shortener.Service.Utilities;

namespace MyFirstUnitTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest1()
        {
            Assert.Equal(true, UrlValidator.validator("http://google.com"));
        }

        [Fact]
        public void FailingTest1()
        {
            Assert.Equal(false, UrlValidator.validator("http://googl e.com"));
        }

        [Fact]
        public void PassingTest2()
        {
            Assert.Equal(true, UrlValidator.validator("http://1.1.1.1"));
        }

        [Fact]
        public void FailingTest2()
        {
            Assert.Equal(false, UrlValidator.validator("http://dfskjhkjdsa..dfs"));
        }

        [Fact]
        public void PassingTest3()
        {
            Assert.Equal(true, UrlValidator.validator("http://ali-nazari.com"));
        }

        [Fact]
        public void FailingTest3()
        {
            Assert.Equal(false, UrlValidator.validator("http://googl//e.com"));
        }
    }
}