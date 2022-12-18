using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects
{
    public class Input : Text
    {
        public string Text { get; set; } = string.Empty;

        public override void Update()
        {
            base.Update();
            for (int key = 0; key < 256; key++)
            {
                if (Input.IsKeyDown(key))
                {
                    if (key >= 32)
                    {
                        Text += (char)key;
                    }

                    if (key == 8 && Text.Length > 0)
                    {
                        Text = Text.Remove(Text.Length - 1);
                    }
                }
            }
        }

        public override void Render()
        {
            base.Render();

            // Text
            short? tColor = (short?)CurrentStyle["TextColor"];
            short? tBgColor = (short?)CurrentStyle["TextBackroundColor"];

            for (int x = 0; x < Text.Length; x++)
            {
                Renderer.SetChar(Coord + new Coord(x, 0), tColor, tBgColor, c: Text[x]);
            }
        }
    }
}
