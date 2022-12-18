using System.Runtime.InteropServices;

namespace AzemitologaUzdevums.Engine.General.Draw
{
    [StructLayout(LayoutKind.Explicit)]
    public struct CharUnion
    {
        [FieldOffset(0)] public ushort UnicodeChar;
        [FieldOffset(0)] public byte AsciiChar;
    }
}
