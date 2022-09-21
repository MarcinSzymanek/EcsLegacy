using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Redesign
{
    internal class FakeTempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }
    }
}
