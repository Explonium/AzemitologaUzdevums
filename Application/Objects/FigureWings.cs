using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class FigureWings : Figure
    {
        public int? Width { get; set; }
        public int? Height { get; set; }

        public FigureWings(View view) : base(view)
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

            var width = Width ?? (Size + 2);
            var height = Height ?? Size;

            for (short x = 0; x < width && x < Renderer.Width; x++)
            {
                for (short y = 0; y < height && y < Renderer.Height; y++)
                {
                    switch (x - width / 2)
                    {
                        case -1:
                            if (y < height / 2)
                            {
                                Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, '\\');
                            };
                            if (y > height / 2)
                            {
                                Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, '/');
                            };
                            break;
                        case 0:
                            if (y == height / 2)
                            {
                                Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, '@');
                            };
                            break;
                        case 1:
                            if (y < height / 2)
                            {
                                Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, '/');
                            };
                            if (y > height / 2)
                            {
                                Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, '\\');
                            };
                            break;
                        default:
                            if (y % 2 == 0)
                            {
                                Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, bgChar);
                            }
                            else
                            {
                                if (y != height / 2)
                                {
                                    Renderer.SetChar(Coord + new Coord(x, y), sColor, sBgColor, sBgChar);
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
