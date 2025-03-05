using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattressHeatmap
{
    public class Logger
    {
        public delegate void EventHandler_String(string value);

        public event EventHandler_String MessageReceived_Event;

        public void Log(string message)
        {
            MessageReceived_Event?.Invoke(message);
        }
    }
}
