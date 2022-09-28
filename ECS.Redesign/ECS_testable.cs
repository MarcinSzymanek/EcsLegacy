using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Redesign
{
    public class ECS_testable
    {
        const int defaultWindowTempThr = 20;
        const int defaultHeaterThreshhold = 15;
        private int _lastLoggedTemp;
        public int LastLoggedTemp { get { return _lastLoggedTemp; } }

        private int _windowThreshold;
        private int _heaterThreshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;

        public ECS_testable(ITempSensor ts, IHeater heat, IWindow win)
        {
            SetHeaterThreshold(defaultHeaterThreshhold);
            SetWindowThreshold(defaultWindowTempThr);
            _tempSensor = ts;
            _heater = heat;
            _window = win;
            _lastLoggedTemp = _tempSensor.GetTemp();
        }

        public void Regulate()
        {
            Console.WriteLine($"Temperature measured was {_lastLoggedTemp}");

            if (_lastLoggedTemp < _windowThreshold)
                _window.Close();
            else
            {
                _window.Open();
                _heater.TurnOff();
            }

            if (_lastLoggedTemp < _heaterThreshold)
            {
                if (!_window.IsOpen)
                {
                    _heater.TurnOn();
                }
            }
            else if (_lastLoggedTemp > _heaterThreshold)
            {
                _heater.TurnOff();
            }
        }
        public void LogTemp()
        {
            _lastLoggedTemp = _tempSensor.GetTemp();
        }

        public void SetHeaterThreshold(int thr)
        {
            _heaterThreshold = thr;
        }

        public int GetThreshold()
        {
            return _heaterThreshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public void SetWindowThreshold(int val)
        {
            _windowThreshold = val;
        }

       

        public bool RunSelfTest()
        {
            //return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
            return true;
        }
    }
}
