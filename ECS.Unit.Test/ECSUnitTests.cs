using ECS_Redesign;

namespace ECS.Unit.Test
{
    public class ECSUnitTests
    {

        ECS_testable _ecsUnit;
        FakeHeater _heaterUnit;
        FakeTempSensor _tempSensorUnit;
        const int defaultThreshhold = 18;
        const bool defaultHeaterState = true;
        [SetUp]
        public void Setup()
        {
            _heaterUnit = new FakeHeater(defaultHeaterState);
            _tempSensorUnit = new FakeTempSensor();
            _ecsUnit = new ECS_testable(defaultThreshhold, _tempSensorUnit, _heaterUnit);
        }

        [Test]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(0)]
        public void TestLoggedTemp_MoreThenThreshold_HeaterOff(int a)
        {
            _ecsUnit.SetThreshold(a);

            while(_ecsUnit.LastLoggedTemp < a)
            {
                _ecsUnit.LogTemp();
            }
            _ecsUnit.Regulate();
            Assert.IsFalse(_heaterUnit.IsOn);
        }

        [Test]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(0)]
        public void TestLoggedTemp_LessThenThreshold_HeaterOn(int a)
        {
            _ecsUnit.SetThreshold(a);

            while (_ecsUnit.LastLoggedTemp > a)
            {
                _ecsUnit.LogTemp();
            }
            _ecsUnit.Regulate();
            Assert.IsTrue(_heaterUnit.IsOn);
        }
    }
}