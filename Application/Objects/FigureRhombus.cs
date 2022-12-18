using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class FigureRhombus : Figure
    {
        public FigureRhombus(View view) : base(view)
        {
        }

        public override void Render()
        {
            // Background
            short? color = (short?)CurrentStyle["Color"];
            short? bgColor = (short?)CurrentStyle["BackgroundColor"];
            ushort bgChar = (ushort)CurrentStyle["BackgroundChar"];

            for (short x = 0; x < Size * 2 && x < Renderer.Width; x++)
            {
                var absX = x < Size ? x : 2 * Size - x;
                for (short y = (short)(Size - 1 - absX); y < (short)(Size - 1 + absX) && y < Renderer.Height; y+= 2)
                {
                    Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, bgChar);
                }
            }
        }
    }
}
