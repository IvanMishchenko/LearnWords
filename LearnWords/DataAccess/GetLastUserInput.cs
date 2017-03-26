using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace LearnWords.DataAccess
{
    public static class GetLastUserInput
    {
        private struct Lastinputinfo
        {
            public uint CbSize;
            public uint DwTime;
           
        }
        private static Lastinputinfo lastInPutNfo;
        static GetLastUserInput()
        {
            lastInPutNfo = new Lastinputinfo();
            lastInPutNfo.CbSize = (uint)Marshal.SizeOf(lastInPutNfo);
        }
        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref Lastinputinfo plii);

      
        // Idle time in ticks
        public static bool GetIdleTickCount()
        {
            var result = false;
            var time=((uint)Environment.TickCount - GetLastInputTime());
       //Console.WriteLine(time);
       result = (time < 600000) ? true : false;
            //600000ms=>10min
            return result;
        }
       
        // Last input time in ticks
        private static uint GetLastInputTime()
        {
            if (!GetLastInputInfo(ref lastInPutNfo))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            return lastInPutNfo.DwTime;
        }

    
    }
}
