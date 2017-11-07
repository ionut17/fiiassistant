using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.RestClients;

namespace IntegrationTests.Server
{
    [TestClass]
    public class GivenRestClient
    {
        public static RestClient Sut;
        public static string UrlTest;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            Sut = new RestClient();
            UrlTest = "http://localhost:2000/test";
        }

        [TestMethod]
        public void When_Getting_Then_ResponseShouldBeGet()
        {
            //arrange
            //act
            var result = Sut.Get(UrlTest).Result;
            //assert
            result.Should().Be("test_get");
        }

        [TestMethod]
        public void When_Posting_Then_ResponseShouldBePost()
        {
            //arrange
            //act
            var result = Sut.Post(UrlTest, null).Result;
            //assert
            result.Should().Be("test_post");
        }

        [TestMethod]
        public void When_Putting_Then_ResponseShouldBePut()
        {
            //arrange
            //act
            var result = Sut.Put(UrlTest, null).Result;
            //assert
            result.Should().Be("test_put");
        }

        [TestMethod]
        public void When_Deleting_Then_ResponseShouldBeDelete()
        {
            //arrange
            //act
            var result = Sut.Delete(UrlTest).Result;
            //assert
            result.Should().Be("test_delete");
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Sut = null;
            UrlTest = null;
        }
    }
}