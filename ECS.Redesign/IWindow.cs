using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Redesign
{
    public interface IWindow
    {
        bool IsOpen { get; }
        public void Open();
        public void Close();
    }
}
