using AzemitologaUzdevums.Application.Objects.Styles;
using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General.Draw;
using System;

namespace AzemitologaUzdevums.Application.Objects.Factories
{
    public class ButtonFactory
    {
        public static Button StandartButton(View view, Coord pos, string text, Action onPress = null, Action onHover = null)
        {
            var button = new Button
            {
                View = view,
                Coord = pos,
                Style = new Style(new
                {
                    Width = 15,
                    Height = 1,
                    Text = "   " + text,
                    TextColor = 7
                }),
                HoverStyle = new Style(new
                {
                    Text = "-> " + text
                }),
                PressedStyle = new Style(new
                {
                    TextColor = 0,
                    BackgroundColor = 7
                }),
                OnPress = onPress,
                OnHover = onHover,
                ZIndex = 100
            };

            return button;
        }
    }
}
