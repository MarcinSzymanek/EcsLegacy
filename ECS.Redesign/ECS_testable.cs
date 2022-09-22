using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Redesign
{
    internal class ECS_testable
    {
        private int _threshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;

        public ECS_testable(int thr, ITempSensor ts, IHeater heat)
        {
            SetThreshold(thr);
            _tempSensor = ts;
            _heater = heat;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
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
