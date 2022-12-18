using AzemitologaUzdevums.Application.Objects.Styles;
using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class FigureTwoRectangles : Figure
    {
        FigureRectangle LeftRectangle { get; set; }
        FigureRectangleOutline LeftRectangleO { get; set; }
        FigureRectangle RightRectangle { get; set; }
        FigureRectangleOutline RightRectangleO { get; set; }
        public FigureTwoRectangles(View view) : base(view)
        {
            LeftRectangle = new FigureRectangle(view);
            RightRectangle = new FigureRectangle(view);
            LeftRectangleO = new FigureRectangleOutline(view);
            RightRectangleO = new FigureRectangleOutline(view);
        }

        public override void Update()
        {
            base.Update();
            var innerStyle = Style + new Style(new
            {
                BackgroundColor = CurrentStyle["SecondaryBackgroundColor"],
                Color = CurrentStyle["SecondaryColor"],
                BackgroundChar = CurrentStyle["SecondaryBackgroundChar"]
            });

            LeftRectangle.Style = innerStyle;
            RightRectangle.Style = innerStyle;
            LeftRectangleO.Style = Style;
            RightRectangleO.Style = Style;

            LeftRectangle.Update();
            RightRectangle.Update();
            LeftRectangleO.Update();
            RightRectangleO.Update();
        }

        public override void Render()
        {
            // Background
            short? color = (short?)CurrentStyle["Color"];
            short? bgColor = (short?)CurrentStyle["BackgroundColor"];

            LeftRectangle.Size = Size;
            LeftRectangle.Width = Size * 2;
            LeftRectangle.Coord = Coord;

            RightRectangle.Size = Size;
            RightRectangle.Width = Size * 2; LeftRectangle.Size = Size;
            RightRectangle.Coord = Coord + new Coord(Size * 3, 0);

            LeftRectangleO.Size = Size;
            LeftRectangleO.Width = Size * 2;
            LeftRectangleO.Coord = Coord;

            RightRectangleO.Size = Size;
            RightRectangleO.Width = Size * 2;
            RightRectangleO.Coord = Coord + new Coord(Size * 3, 0);

            for (short x = 0; x < Size; x++)
            {
                Renderer.SetChar(Coord + new Coord(x + Size * 2, (Size - 1) / 2), color, bgColor, '|');
            }

            LeftRectangle.Render();
            RightRectangle.Render();
            LeftRectangleO.Render();
            RightRectangleO.Render();
        }
    }
}
