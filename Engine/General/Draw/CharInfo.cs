using System.Runtime.InteropServices;
using static AzemitologaUzdevums.Engine.Core.Renderer;

namespace AzemitologaUzdevums.Engine.General.Draw
{
    [StructLayout(LayoutKind.Explicit)]
    public struct CharInfo
    {
        [FieldOffset(0)] public CharUnion Char;
        [FieldOffset(2)] public short Attributes;
    }
}
