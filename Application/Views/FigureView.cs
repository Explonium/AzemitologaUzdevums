using AzemitologaUzdevums.Application.Objects;
using AzemitologaUzdevums.Application.Objects.Factories;
using AzemitologaUzdevums.Application.Objects.Styles;
using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Views
{
    public class FigureView : View
    {
        public Figure Figure { get; set; }
        public Input Input { get; set; }
        public FigureView(Figure figure) : base()
        {
            Figure = figure;
            Input = InputsFactory.StandartInput(this, new Coord(21, 3), "Ievadiet izmēru:");

            AddObject(Figure);

            AddObject(
                ButtonFactory.StandartButton(this, new Coord(1, 1), "Back",
                onPress: () =>
                {
                    Application.RemoveView(this);
                }));

            AddObject(Input);
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
