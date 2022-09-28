using System;
using System.Collections.Generic;
using System.Text;

namespace ECS.Unit.Test
{
    public class FakeTempSensor : ECS_Redesign.ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

    }
}
