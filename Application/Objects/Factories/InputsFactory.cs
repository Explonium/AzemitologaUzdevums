using AzemitologaUzdevums.Application.Objects.Styles;
using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;
using System;

namespace AzemitologaUzdevums.Application.Objects.Factories
{
    public class InputsFactory
    {
        public static Input StandartInput(View view, Coord pos, string label = "", Action onPress = null, Action onHover = null)
        {
            var input = new Input
            {
                View = view,
                Coord = pos,
                Style = new Style(new
                {
                    Width = 15,
                    Height = 1,
                    Text = label,
                    TextColor = 7,
                    TextPosition = new Coord(-20, 0)
                }),
                OnPress = onPress,
                OnHover = onHover,
                ZIndex = 100
            };

            return input;
        }
    }
}
