using APIFP.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace APIFPTest
{
    [TestClass]
    public class GeoCodingTest
    {
        [TestMethod]
        public void GecodeToPosition()
        {
            var position = APIFP.Helpers.GooglePoints.Decode("yvh~Hgi`\\lggfAjyi~M");

            Assert.IsInstanceOfType(position, typeof(IEnumerable<Position>));
        }
    }
}
