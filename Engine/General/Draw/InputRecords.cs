using System.Runtime.InteropServices;

namespace AzemitologaUzdevums.Engine.General.Draw
{
    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT_RECORD
    {
        public const ushort KEY_EVENT = 0x0001,
            MOUSE_EVENT = 0x0002,
            WINDOW_BUFFER_SIZE_EVENT = 0x0004; //more

        [FieldOffset(0)]
        public ushort EventType;
        [FieldOffset(4)]
        public KEY_EVENT_RECORD KeyEvent;
        [FieldOffset(4)]
        public MOUSE_EVENT_RECORD MouseEvent;
        [FieldOffset(4)]
        public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
        /*
        and:
         MENU_EVENT_RECORD MenuEvent;
         FOCUS_EVENT_RECORD FocusEvent;
         */
    }

    public struct MOUSE_EVENT_RECORD
    {
        public Coord dwMousePosition;

        public const uint FROM_LEFT_1ST_BUTTON_PRESSED = 0x0001,
            FROM_LEFT_2ND_BUTTON_PRESSED = 0x0004,
            FROM_LEFT_3RD_BUTTON_PRESSED = 0x0008,
            FROM_LEFT_4TH_BUTTON_PRESSED = 0x0010,
            RIGHTMOST_BUTTON_PRESSED = 0x0002;
        public uint dwButtonState;

        public const int CAPSLOCK_ON = 0x0080,
            ENHANCED_KEY = 0x0100,
            LEFT_ALT_PRESSED = 0x0002,
            LEFT_CTRL_PRESSED = 0x0008,
            NUMLOCK_ON = 0x0020,
            RIGHT_ALT_PRESSED = 0x0001,
            RIGHT_CTRL_PRESSED = 0x0004,
            SCROLLLOCK_ON = 0x0040,
            SHIFT_PRESSED = 0x0010;
        public uint dwControlKeyState;

        public const int DOUBLE_CLICK = 0x0002,
            MOUSE_HWHEELED = 0x0008,
            MOUSE_MOVED = 0x0001,
            MOUSE_WHEELED = 0x0004;
        public uint dwEventFlags;
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct KEY_EVENT_RECORD
    {
        [FieldOffset(0)]
        public bool bKeyDown;
        [FieldOffset(4)]
        public ushort wRepeatCount;
        [FieldOffset(6)]
        public ushort wVirtualKeyCode;
        [FieldOffset(8)]
        public ushort wVirtualScanCode;
        [FieldOffset(10)]
        public char UnicodeChar;
        [FieldOffset(10)]
        public byte AsciiChar;

        public const int CAPSLOCK_ON = 0x0080,
            ENHANCED_KEY = 0x0100,
            LEFT_ALT_PRESSED = 0x0002,
            LEFT_CTRL_PRESSED = 0x0008,
            NUMLOCK_ON = 0x0020,
            RIGHT_ALT_PRESSED = 0x0001,
            RIGHT_CTRL_PRESSED = 0x0004,
            SCROLLLOCK_ON = 0x0040,
            SHIFT_PRESSED = 0x0010;
        [FieldOffset(12)]
        public uint dwControlKeyState;
    }

    public struct WINDOW_BUFFER_SIZE_RECORD
    {
        public Coord dwSize;
    }

    public class HandleMode
    {
        public const uint STD_INPUT_HANDLE = unchecked((uint)-10);
        public const uint STD_OUTPUT_HANDLE = unchecked((uint)-11);
        public const uint STD_ERROR_HANDLE = unchecked((uint)-12);
    }
}
