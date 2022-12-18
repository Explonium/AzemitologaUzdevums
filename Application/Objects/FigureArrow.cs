using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class FigureArrow : Figure
    {
        public int? Width { get; set; }
        public int? Height { get; set; }

        public FigureArrow(View view) : base(view)
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

            var halfSize = Width / 2 ?? Size / 2;
            var width = Width ?? Size + halfSize * 2;
            var height = Height ?? Size + halfSize * 2;
            var halfHeight = height / 2;

            if (width > 0 && height > 0)
            {
                Renderer.DrawRectangle(Coord, new Coord(width, height), sColor, sBgColor, sBgChar);

                var p1 = Coord + new Coord(halfSize, 0);
                var p2 = Coord + new Coord(width - halfSize - 1, 0);
                var p3 = Coord + new Coord(halfSize, halfHeight);
                var p4 = Coord + new Coord(width - halfSize - 1, halfHeight);
                var p5 = Coord + new Coord(0, halfHeight);
                var p6 = Coord + new Coord(width - 1, halfHeight);
                var p7 = Coord + new Coord((width - 1) / 2, height - 1);
                var p8 = Coord + new Coord(width / 2, height - 1);

                Renderer.DrawLineFree(p1, p2, color, bgColor, bgChar);
                Renderer.DrawLineFree(p1, p3, color, bgColor, bgChar);
                Renderer.DrawLineFree(p2, p4, color, bgColor, bgChar);
                Renderer.DrawLineFree(p3, p5, color, bgColor, bgChar);
                Renderer.DrawLineFree(p4, p6, color, bgColor, bgChar);
                Renderer.DrawLineFree(p5, p7, color, bgColor, bgChar);
                Renderer.DrawLineFree(p6, p8, color, bgColor, bgChar);
            }
        }
    }
}
