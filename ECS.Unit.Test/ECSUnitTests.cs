using ECS_Redesign;

namespace ECS.Unit.Test
{
    public class ECSUnitTests
    {

        ECS_testable _ecsUnit;
        FakeHeater _heaterUnit;
        FakeWindow _windowUnit;
        FakeTempSensor _tempSensorUnit;
        const bool defaultHeaterState = true;
        [SetUp]
        public void Setup()
        {
            _heaterUnit = new FakeHeater(defaultHeaterState);
            _tempSensorUnit = new FakeTempSensor();
            _windowUnit = new FakeWindow();
            _ecsUnit = new ECS_testable(
                 _tempSensorUnit, _heaterUnit, _windowUnit
                );
        }

        [Test]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(0)]
        public void TestLoggedTemp_MoreThenThreshold_HeaterOff(int a)
        {
            _ecsUnit.SetHeaterThreshold(a);

            while(_ecsUnit.LastLoggedTemp <= a)
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
            _ecsUnit.SetHeaterThreshold(a);

            while (_ecsUnit.LastLoggedTemp > a)
            {
                _ecsUnit.LogTemp();
            }
            _ecsUnit.Regulate();
            Assert.IsTrue(_heaterUnit.IsOn);
        }

        [Test]
        [TestCase(20)]
        [TestCase(0)]
        public void Test_WindowOpen_HeaterOff(int a)
        {
            _ecsUnit.SetWindowThreshold(a);

            while (_ecsUnit.LastLoggedTemp <= a)
            {
                _ecsUnit.LogTemp();
            }
            _ecsUnit.Regulate();
            Assert.IsTrue(!_heaterUnit.IsOn && _windowUnit.IsOpen);
        }

        [Test]
        [TestCase(20)]
        [TestCase(0)]
        public void Test_TempLow_WindowClosed(int a)
        {
            _ecsUnit.SetWindowThreshold(a);

            while (_ecsUnit.LastLoggedTemp >= a)
            {
                _ecsUnit.LogTemp();
            }
            _ecsUnit.Regulate();
            Assert.IsTrue(!_windowUnit.IsOpen);
        }
    }
}