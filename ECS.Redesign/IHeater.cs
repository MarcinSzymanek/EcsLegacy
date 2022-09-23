using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Redesign
{
    public interface IHeater
    {
        public void TurnOn();
        public void TurnOff();
        public bool IsOn { get; }
    }
}
