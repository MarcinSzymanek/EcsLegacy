using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS_Redesign;

namespace ECS.Unit.Test
{
    internal class FakeWindow : IWindow
    {
        bool _isOpen = true;
        public bool IsOpen { get { return _isOpen; } }
        public void Open()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                Console.WriteLine("Opening window");
            }
        }
        public void Close()
        {
            if (_isOpen)
            {
                _isOpen = false;
                Console.WriteLine("Closing window");
            }
        }
    }
}
