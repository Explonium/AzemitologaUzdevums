using AzemitologaUzdevums.Engine.General.Draw;
using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Threading;

namespace AzemitologaUzdevums.Engine.General
{
    public class Input
    {
        private bool[] KeyboardInputs { get; set; }
        private bool[] PrevKeyboardInputs { get; set; }
        private const int KEYBOARD_KEYS = 256;
        private const int KEY_PRESSED = 0x8000;
        private Coord MousePos { get; set; }
        private IntPtr HandleIn { get; set; }
        private Thread InputProcessor { get; set; }
        private bool IsRunning { get; set; } = true;

        private const uint ENABLE_MOUSE_INPUT = 0x0010,
            ENABLE_QUICK_EDIT_MODE = 0x0040,
            ENABLE_EXTENDED_FLAGS = 0x0080,
            ENABLE_ECHO_INPUT = 0x0004,
            ENABLE_WINDOW_INPUT = 0x0008;

        public Input()
        {
            HandleIn = GetStdHandle(HandleMode.STD_INPUT_HANDLE);

            uint mode = 0;
            GetConsoleMode(HandleIn, ref mode);
            mode &= ~ENABLE_QUICK_EDIT_MODE; //disable
            mode |= ENABLE_WINDOW_INPUT; //enable (if you want)
            mode |= ENABLE_MOUSE_INPUT; //enable
            SetConsoleMode(HandleIn, mode);

            MousePos = new Coord();
            KeyboardInputs = new bool[KEYBOARD_KEYS];
            PrevKeyboardInputs = new bool[KEYBOARD_KEYS];

            for (int i = 0; i < KEYBOARD_KEYS; i++)
            {
                KeyboardInputs[i] = false;
                PrevKeyboardInputs[i] = false;
            }

            InputProcessor = new Thread(() =>
            {
                while (IsRunning)
                {
                    uint numRead = 0;
                    INPUT_RECORD[] record = new INPUT_RECORD[2];
                    record[0] = new INPUT_RECORD();
                    ReadConsoleInput(HandleIn, record, 2, ref numRead);

                    switch (record[0].EventType)
                    {
                        case INPUT_RECORD.MOUSE_EVENT:
                            MousePos = record[0].MouseEvent.dwMousePosition;
                            break;;
                    }
                }
            });

            InputProcessor.Start();
        }

        ~Input()
        {
            IsRunning = false;
        }

        public void Update()
        {
            PrevKeyboardInputs = KeyboardInputs;
            KeyboardInputs = new bool[KEYBOARD_KEYS];

            for (int i = 0; i < KEYBOARD_KEYS; i++)
            {
                KeyboardInputs[i] = Convert.ToBoolean(GetKeyState(i) & KEY_PRESSED);
            }
        }

        public bool IsKeyPressed(int key)
        {
            return KeyboardInputs[key];
        }

        public bool IsKeyDown(int key)
        {
            return KeyboardInputs[key] && !PrevKeyboardInputs[key];
        }

        public bool IsKeyUp(int key)
        {
            return !KeyboardInputs[key] && PrevKeyboardInputs[key];
        }

        public Coord GetMousePos()
        {
            return MousePos;
        }

        [DllImport("USER32.dll")]
        static extern short GetKeyState(int key);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetStdHandle(uint nStdHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool ReadConsoleInput(IntPtr hConsoleInput, [Out] INPUT_RECORD[] lpBuffer, uint nLength, ref uint lpNumberOfEventsRead);

        [DllImport("kernel32.dll")]
        public static extern bool GetConsoleMode(IntPtr hConsoleInput, ref uint lpMode);

        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleMode(IntPtr hConsoleInput, uint dwMode);
    }
}
