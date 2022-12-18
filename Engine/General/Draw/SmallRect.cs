using System.Runtime.InteropServices;

namespace AzemitologaUzdevums.Engine.General.Draw
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SmallRect
    {
        public short Left;
        public short Top;
        public short Right;
        public short Bottom;

        public int SequenceOf(Coord coord)
        {
            return coord.Y * Right + coord.X;
        }
    }
}
