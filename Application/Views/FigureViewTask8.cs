using AzemitologaUzdevums.Application.Objects;
using AzemitologaUzdevums.Application.Objects.Factories;
using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Views
{
    public class FigureViewTask8 : View
    {
        public Button TypeA { get; set; }
        public Button TypeB { get; set; }
        public Button TypeC { get; set; }
        public Button TypeD { get; set; }
        public Figure Figure { get; set; }
        public Input Input { get; set; }
        public FigureViewTask8() : base()
        {
            Figure = FiguresFactory.StandartFigure(new Coord(1, 5), new FigureTriangleUp(this));
            Input = InputsFactory.StandartInput(this, new Coord(21, 3), "Ievadiet izmēru:");

            TypeA = ButtonFactory.StandartButton(this, new Coord(30, 1), "Tips a",
                onPress: () =>
                {
                    RemoveObject(Figure);
                    Figure = FiguresFactory.StandartFigure(new Coord(1, 5), new FigureTriangleUp(this));
                    AddObject(Figure);
                });
            TypeB = ButtonFactory.StandartButton(this, new Coord(30, 2), "Tips b",
                onPress: () =>
                {
                    RemoveObject(Figure);
                    Figure = FiguresFactory.StandartFigure(new Coord(1, 5), new FigureTriangleDown(this));
                    AddObject(Figure);
                });
            TypeC = ButtonFactory.StandartButton(this, new Coord(30, 3), "Tips c",
                onPress: () =>
                {
                    RemoveObject(Figure);
                    FiguresFactory.StandartFigure(new Coord(1, 5), Figure = new FigureRhombusFilled(this));
                    AddObject(Figure);
                });
            TypeD = ButtonFactory.StandartButton(this, new Coord(30, 4), "Tips d",
                onPress: () =>
                {
                    RemoveObject(Figure);
                    Figure = FiguresFactory.StandartFigure(new Coord(1, 5), new FigureRhombusExcluded(this));
                    AddObject(Figure);
                });

            AddObject(
                ButtonFactory.StandartButton(this, new Coord(1, 1), "Back",
                onPress: () =>
                {
                    Application.RemoveView(this);
                }));

            AddObject(Figure);
            AddObject(Input);
            AddObject(TypeA);
            AddObject(TypeB);
            AddObject(TypeC);
            AddObject(TypeD);
        }

        public override void Update()
        {
            base.Update();

            int size = 0;
            int.TryParse(Input.Text, out size);
            Figure.Size = size;
        }
    }
}
