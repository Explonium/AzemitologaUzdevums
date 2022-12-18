using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class FigureTriangleUp : Figure
    {
        public int? Width { get; set; }
        public int? Height { get; set; }

        public FigureTriangleUp(View view) : base(view)
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

            var width = Width ?? (Size + 1) * 4;
            var height = Height ?? Size;

            for(int y = 0; y < height; y++)
            {
                for(int x = (width - 1) / 2 - (y * 2); x < width / 2 + (y * 2); x+= 2)
                {
                    Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, bgChar);
                }
            }
        }
    }
}
