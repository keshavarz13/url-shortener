using Xunit;
using RA;
using System.Collections.Generic;

namespace shortener.test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("LongUrl", "http://google.com");
            new RestAssured()
                .Given()
                    .Name("standard long url test1")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(values)
                .When()
                    .Post("http://localhost:5000/urls")
                .Then()
                    .TestStatus("status test1", x => x == 200)
                    .Assert("status test1");
        }

        [Fact]
        public void Test2()
        {
            var body = new
            {
                LongUrl = "goo gle"
            };

            new RestAssured()
             .Given()
                .Header("Content-Type", "application/json")
                .Body(body)
            .When()
                .Post("localhost:5000/urls")
            .Then()
                .TestStatus("test status", s => s == 400)
                .Assert("test status");
        }

        [Fact]
        public void Test3()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("LongUrl", "aut.ac.ir");
            new RestAssured()
                .Given()
                    .Name("standard long url test1")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(values)
                .When()
                    .Post("http://localhost:5000/urls")
                .Then()
                    .TestStatus("status test3", x => x == 200)
                    .Assert("status test3");
        }

        [Fact]
        public void Test4()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("LongUrl", "http://10.1.1.270");
            new RestAssured()
                .Given()
                    .Name("standard long url test1")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(values)
                .When()
                    .Post("http://localhost:5000/urls")
                .Then()
                    .TestStatus("status test4", x => x == 200)
                    .Assert("status test4");
        }

    }
}
