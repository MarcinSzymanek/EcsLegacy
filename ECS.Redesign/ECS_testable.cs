using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Redesign
{
    public class ECS_testable
    {
        private int _lastLoggedTemp;
        public int LastLoggedTemp { get { return _lastLoggedTemp; } }

        private int _threshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;

        public ECS_testable(int thr, ITempSensor ts, IHeater heat)
        {
            SetThreshold(thr);
            _tempSensor = ts;
            _heater = heat;
            _lastLoggedTemp = _tempSensor.GetTemp();
        }

        public void Regulate()
        {
            Console.WriteLine($"Temperature measured was {_lastLoggedTemp}");
            if (_lastLoggedTemp < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
        }

        public void LogTemp()
        {
            _lastLoggedTemp = _tempSensor.GetTemp();
        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            //return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
            return true;
        }
    }
}
