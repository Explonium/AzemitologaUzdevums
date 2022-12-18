using AzemitologaUzdevums.Application.Objects.Styles;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects.Factories
{
    public class FiguresFactory
    {
        public static Figure StandartFigure(Coord pos, Figure figure)
        {
            figure.Coord = pos;
            figure.Style =
                new Style(new
                {
                    Color = 15,
                    BackgroundChar = '*',
                    SecondaryColor = 7,
                    SecondaryBackgroundChar = '.'
                });

            return figure;
        }
    }
}
