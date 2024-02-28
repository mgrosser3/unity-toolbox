using NUnit.Framework;

namespace mgrosser3
{
    public class UnitConverterTest
    {
        [Test]
        public void InchesToCentimetersTests()
        {
            // 1'' == 2.54 cm
            Assert.AreEqual(2.54f, mgrosser3.UnitConverter.InchesToCentimeters(1), 1e-4);

            // 14'' == 35.56 cm
            Assert.AreEqual(35.56f, mgrosser3.UnitConverter.InchesToCentimeters(14), 1e-4);

            // 32'' == 81.28 cm
            Assert.AreEqual(81.28f, mgrosser3.UnitConverter.InchesToCentimeters(32), 1e-4);
        }

        [Test]
        public void CentimetersToInchesTests()
        {
            // 1 cm == 1.0/2.54 ~> 0.3937007874''
            Assert.AreEqual(1.0f/2.54f, mgrosser3.UnitConverter.CentimetersToInches(1), 1e-4);

            // 35.56 cm == 14''
            Assert.AreEqual(14, mgrosser3.UnitConverter.CentimetersToInches(35.56f), 1e-4);

            // 81.28 cm == 32''
            Assert.AreEqual(32, mgrosser3.UnitConverter.CentimetersToInches(81.28f), 1e-4);
        }
    }
}