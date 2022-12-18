using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class FigureRectangleOutline : Figure
    {
        public int? Width { get; set; }
        public int? Height { get; set; }

        public FigureRectangleOutline(View view) : base(view)
        {
        }

        public override void Render()
        {
            // Background
            short? color = (short?)CurrentStyle["Color"];
            short? bgColor = (short?)CurrentStyle["BackgroundColor"];
            ushort bgChar = (ushort)CurrentStyle["BackgroundChar"];

            for (int x = 0; x < (Width ?? Size) && x < Renderer.Width; x++)
            {
                Renderer.SetChar(Coord + new Coord(x, 0), color, bgColor, bgChar);
                Renderer.SetChar(Coord + new Coord(x, ((Height ?? Size) - 1)), color, bgColor, bgChar);
            }
            for (int y = 0; y < (Height ?? Size) && y < Renderer.Height; y++)
            {
                Renderer.SetChar(Coord + new Coord(0, y), color, bgColor, bgChar);
                Renderer.SetChar(Coord + new Coord((Width ?? Size) - 1, y), color, bgColor, bgChar);
            }
        }
    }
}
