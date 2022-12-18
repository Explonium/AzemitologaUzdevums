using System.Runtime.InteropServices;

namespace AzemitologaUzdevums.Engine.General.Draw
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Coord
    {
        public short X;
        public short Y;

        public Coord(short X = 0, short Y = 0)
        {
            this.X = X;
            this.Y = Y;
        }
        
        public Coord(int X = 0, int Y = 0) : this((short)X, (short)Y)
        { }

        public static Coord operator +(Coord a, Coord b)
        {
            return new Coord { X = (short)(a.X + b.X), Y = (short)(a.Y + b.Y) };
        }
        
        public static Coord operator -(Coord a, Coord b)
        {
            return new Coord { X = (short)(a.X - b.X), Y = (short)(a.Y - b.Y) };
        }
    }
}
