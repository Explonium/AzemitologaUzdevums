using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class FigureRectangle : Figure
    {
        public int? Width { get; set; }
        public int? Height { get; set; }

        public FigureRectangle(View view) : base(view)
        {
        }

        public override void Render()
        {
            // Background
            short? color = (short?)CurrentStyle["Color"];
            short? bgColor = (short?)CurrentStyle["BackgroundColor"];
            ushort bgChar = (ushort)CurrentStyle["BackgroundChar"];

            Renderer.DrawRectangle(Coord, new Coord(Width ?? Size, Height ?? Size), color, bgColor, bgChar);
        }
    }
}
