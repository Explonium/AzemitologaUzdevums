using AzemitologaUzdevums.Application.Objects;
using AzemitologaUzdevums.Application.Objects.Factories;
using AzemitologaUzdevums.Application.Objects.Styles;
using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Views
{
    public class StartView : View
    {
        public StartView() : base() 
        {
            AddObject(ButtonFactory.StandartButton(this, new Coord(1, 1), "Exercize #1",
                onPress: () =>
                {
                    Application.AddView(new FigureView(FiguresFactory.StandartFigure(new Coord(1, 5), new FigureRectangle(this)))
                    {
                        Application = Application
                    });
                }));

            AddObject(ButtonFactory.StandartButton(this, new Coord(1, 2), "Exercize #2",
                onPress: () =>
                {
                    Application.AddView(new FigureView(FiguresFactory.StandartFigure(new Coord(1, 5), new FigureRectangleOutline(this)))
                    {
                        Application = Application
                    });
                }));

            AddObject(ButtonFactory.StandartButton(this, new Coord(1, 3), "Exercize #3",
                onPress: () =>
                {
                    Application.AddView(new FigureView(FiguresFactory.StandartFigure(new Coord(1, 5), new FigureRectangleCross(this)))
                    {
                        Application = Application
                    });
                }));

            AddObject(ButtonFactory.StandartButton(this, new Coord(1, 4), "Exercize #4",
                onPress: () =>
                {
                    Application.AddView(new FigureView(FiguresFactory.StandartFigure(new Coord(1, 5), new FigureRhombus(this)))
                    {
                        Application = Application
                    });
                }));
            AddObject(ButtonFactory.StandartButton(this, new Coord(1, 5), "Exercize #5",
                onPress: () =>
                {
                    Application.AddView(new FigureView(FiguresFactory.StandartFigure(new Coord(1, 5), new FigureTwoRectangles(this)))
                    {
                        Application = Application
                    });
                }));
            AddObject(ButtonFactory.StandartButton(this, new Coord(1, 6), "Exercize #6",
                onPress: () =>
                {
                    Application.AddView(new FigureView(FiguresFactory.StandartFigure(new Coord(1, 5), new FigureWings(this)))
                    {
                        Application = Application
                    });
                }));
            AddObject(ButtonFactory.StandartButton(this, new Coord(1, 7), "Exercize #7",
                onPress: () =>
                {
                    Application.AddView(new FigureView(FiguresFactory.StandartFigure(new Coord(1, 5), new FigureArrow(this)))
                    {
                        Application = Application
                    });
                }));
            AddObject(ButtonFactory.StandartButton(this, new Coord(1, 8), "Exercize #8",
                onPress: () =>
                {
                    Application.AddView(new FigureViewTask8()
                    {
                        Application = Application
                    });
                }));
        }
    }
}
