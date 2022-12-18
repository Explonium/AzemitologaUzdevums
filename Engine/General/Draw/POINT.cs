namespace AzemitologaUzdevums.Engine.General.Draw
{
    public struct POINT
    {
        public int X;
        public int Y;

        public Coord AsCoord { get => new Coord { X = (short)X, Y = (short)Y }; }
    }
}
