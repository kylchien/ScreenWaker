using System;
using System.Threading;
using System.Runtime.InteropServices;

/*

[DllImport("User32.dll",
               EntryPoint = "mouse_event",
               CallingConvention = CallingConvention.Winapi)]
public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);

internal static extern void Mouse_Event(int dwFlags,
                                            int dx,
                                            int dy,
                                            int dwData,
                                            int dwExtraInfo);

[DllImport("User32.dll",
           EntryPoint = "GetSystemMetrics",
           CallingConvention = CallingConvention.Winapi)]
internal static extern int InternalGetSystemMetrics(int value);
*/

namespace ScreenWaker
{
    class Program
    {

        [DllImport("User32.dll",
                EntryPoint = "mouse_event",
                CallingConvention = CallingConvention.Winapi)]
        //static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
        internal static extern void Mouse_Event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("User32.dll",
                EntryPoint = "GetSystemMetrics",
                CallingConvention = CallingConvention.Winapi)]
        internal static extern int InternalGetSystemMetrics(int value);

        /*
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        LEFTDOWN = 0x00000002,
        LEFTUP = 0x00000004,
        MIDDLEDOWN = 0x00000020,
        MIDDLEUP = 0x00000040,
        MOVE = 0x00000001,
        ABSOLUTE = 0x00008000,
        RIGHTDOWN = 0x00000008,
        RIGHTUP = 0x00000010
        */


        static void Main(string[] args)
        {
            // Move mouse cursor to an absolute position to_x, to_y and make left button click:
            int to_x = 600;
            int to_y = 100;

            int screenWidth = InternalGetSystemMetrics(0);
            int screenHeight = InternalGetSystemMetrics(1);

            // Mickey X coordinate
            int mic_x = (int)System.Math.Round(to_x * 65536.0 / screenWidth);
            // Mickey Y coordinate
            int mic_y = (int)System.Math.Round(to_y * 65536.0 / screenHeight);

            // 0x0001 | 0x8000: Move + Absolute position
            //Mouse_Event(0x0001 | 0x8000, mic_x, mic_y, 0, 0);
            // 0x0002: Left button down
            //Mouse_Event(0x0002, mic_x, mic_y, 0, 0);
            // 0x0004: Left button up
            //Mouse_Event(0x0004, mic_x, mic_y, 0, 0);

            int duration = (1000 * 60) * 2;

            while (true)
            {
                Console.Out.WriteLine("100,600");
                Mouse_Event(0x0001 | 0x8000, mic_x, mic_y, 0, 0);
                Thread.Sleep(duration);
                Console.Out.WriteLine("600,100");
                Mouse_Event(0x0001 | 0x8000, mic_y, mic_x, 0, 0);
                Thread.Sleep(duration);

            }
        }

    }
}//namespace
