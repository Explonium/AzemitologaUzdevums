using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class FigureRectangleCross : Figure
    {
        public FigureRectangleCross(View view) : base(view)
        {
        }

        public override void Render()
        {
            // Background
            short? color = (short?)CurrentStyle["Color"];
            short? bgColor = (short?)CurrentStyle["BackgroundColor"];
            ushort bgChar = (ushort)CurrentStyle["BackgroundChar"];

            short? sColor = (short?)CurrentStyle["SecondaryColor"];
            short? sBgColor = (short?)CurrentStyle["SecondaryBackgroundColor"];
            ushort sBgChar = (ushort)CurrentStyle["SecondaryBackgroundChar"];

            for (short x = 0; x < Size * 2 + 1 && x < Renderer.Width; x++)
            {
                for (short y = 0; y < Size * 2 + 1 && y < Renderer.Height; y++)
                {
                    Renderer.SetChar(Coord + new Coord(x, y), sColor, sBgColor, sBgChar);
                }

                Renderer.SetChar(Coord + new Coord(x, x), color, bgColor, bgChar);
                Renderer.SetChar(Coord + new Coord(x, (short)(Size * 2 - x)), color, bgColor, bgChar);
            }
        }
    }
}
