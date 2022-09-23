using System;

namespace ECS.Unit.Test
{
    public class FakeHeater : ECS_Redesign.IHeater
    {
        private bool _isOn;
        public bool IsOn { get { return _isOn; } }
        public FakeHeater(bool active)
        {
            _isOn = active;
        }
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
