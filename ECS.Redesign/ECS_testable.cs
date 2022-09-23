using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Redesign
{
    public class ECS_testable
    {
        const int defaultWindowTempThr = 20;
        private int _lastLoggedTemp;
        public int LastLoggedTemp { get { return _lastLoggedTemp; } }

        private int _windowTempTreshold;
        private int _threshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;

        public ECS_testable(int thr, ITempSensor ts, IHeater heat, IWindow win)
        {
            SetThreshold(thr);
            _windowTempTreshold = defaultWindowTempThr;
            _tempSensor = ts;
            _heater = heat;
            _window = win;
            _lastLoggedTemp = _tempSensor.GetTemp();
        }

        public void Regulate()
        {
            Console.WriteLine($"Temperature measured was {_lastLoggedTemp}");

            if (_lastLoggedTemp < _windowTempTreshold)
                _window.Close();
            else
            {
                _window.Open();
                _heater.TurnOff();
            }

            if (_lastLoggedTemp < _threshold)
            {
                if (!_window.IsOpen)
                {
                    _heater.TurnOn();
                }
            }
            else if (_lastLoggedTemp > _threshold)
            {
                _heater.TurnOff();
            }
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

        public void SetWindowTreshhold(int val)
        {
            _windowTempTreshold = val;
        }

       

        public bool RunSelfTest()
        {
            //return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
            return true;
        }
    }
}
