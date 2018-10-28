using APIFP;
using APIFP.Exceptions;
using APIFP.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIFPTest
{
    [TestClass]
    public class ApiTest
    {

        FP api = FP.Current;

        [TestMethod]
        public async Task GetWeatherTest_WithApi_ReturnJson()
        {

            api.Init();
            var wheather = await api.GetWheaterAsync("SBCF");

            Assert.IsInstanceOfType(wheather, typeof(MetarResponse));
        }

        [TestMethod]
        public  async Task CreateFP_ReturnJson()
        {
            api.Init();

            var fp = new GenerateFP
            {
                FromIcao = "SBCF",
                ToIcao = "SBGR"
            };
            var result = await api.GenerateRouteAsync(fp);

            Assert.IsInstanceOfType(result,typeof(GenerateResponseFP));
        }

        [TestMethod]
        public async Task CreateFP_WithoutKey_ReturnError()
        {
            await Assert.ThrowsExceptionAsync<BadRequestException>(async () =>
            {
                var fp = new GenerateFP
                {
                    FromIcao = "SBCF",
                    ToIcao = "SBGR"
                };
                api.Init("batata");
                var result = await api.GenerateRouteAsync(fp);
            });
        }

        [TestMethod]
        public async Task GetAirport_WithKey_ReturnAiport()
        {
            var result = await api.GetAiportAsync("SBCF");

            Assert.IsInstanceOfType(result, typeof(Aiport)); 
        }

        [TestMethod]
        public async Task GetUserFPs_ReturnUserFps()
        {
            var result = await api.GetUserPlansAsync("jesopas");

            Assert.IsInstanceOfType(result, typeof(List<UserFp>));
        }
        
    }
}
