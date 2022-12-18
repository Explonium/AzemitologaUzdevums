using AzemitologaUzdevums.Application.Objects.Styles;
using AzemitologaUzdevums.Engine.Core;
using AzemitologaUzdevums.Engine.General;
using AzemitologaUzdevums.Engine.General.Draw;
using System;

namespace AzemitologaUzdevums.Application.Objects
{
    public class Text : E_Object
    {
        public Action OnPress { get; set; }
        public Action OnHover { get; set; }
        public Style Style { get; set; }
        public Style HoverStyle { get; set; }
        public Style PressedStyle { get; set; }
        protected Style BaseStyle { get; set; } = new Style(new BaseButtonStyle());
        protected Style CurrentStyle { get; set; }

        public Text() : base()
        {
            CurrentStyle = BaseStyle;
        }

        public override void Update()
        {
            // Positioning
            short width = (short)CurrentStyle["Width"];
            short height = (short)CurrentStyle["Height"];

            var mousePos = Input.GetMousePos();

            if (mousePos.X >= Coord.X && mousePos.Y >= Coord.Y && mousePos.X < Coord.X + width && mousePos.Y < Coord.Y + height)
            {
                OnHover?.Invoke();
                CurrentStyle = BaseStyle + Style + HoverStyle;

                if (Input.IsKeyPressed(VirtualKeys.VK_LBUTTON))
                {
                    CurrentStyle = CurrentStyle + PressedStyle;
                }

                if (Input.IsKeyUp(VirtualKeys.VK_LBUTTON))
                {
                    OnPress?.Invoke();
                }
            } 
            else
            {
                CurrentStyle = BaseStyle + Style;
            }

        }

        public override void Render()
        {
            // Positioning
            short width = (short)CurrentStyle["Width"];
            short height = (short)CurrentStyle["Height"];

            // Background
            short? color = (short?)CurrentStyle["Color"];
            short? bgColor = (short?)CurrentStyle["BackgroundColor"];
            ushort bgChar = (ushort)CurrentStyle["BackgroundChar"];

            // Text
            short? tColor = (short?)CurrentStyle["TextColor"];
            short? tBgColor = (short?)CurrentStyle["TextBackroundColor"];
            string text = (string)CurrentStyle["Text"];
            Coord textPos = (Coord)CurrentStyle["TextPosition"];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Renderer.SetChar(Coord + new Coord(x, y), color, bgColor, bgChar);
                }
            }

            for (int x = 0; x < text.Length; x++)
            {
                Renderer.SetChar(Coord + new Coord(x, 0) + textPos, tColor, tBgColor, c: text[x]);
            }
        }
    }
}
