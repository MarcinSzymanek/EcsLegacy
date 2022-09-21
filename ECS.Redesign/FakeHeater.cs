using System;

namespace ECS.Redesign
{
    public class FakeHeater : IHeater
    {
        private bool _isOn;
        public bool IsOn { get { return _isOn; } }
        public void TurnOn()
        {
            if (!_isOn) 
            {
                _isOn = true;
            }
            System.Console.WriteLine("Heater is on");
        }

        public void TurnOff()
        {
            if (_isOn)
            {
                _isOn = false;
            }
            System.Console.WriteLine("Heater is off");
        }
    }
}
