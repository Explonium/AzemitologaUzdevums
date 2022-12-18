using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects.Styles
{
    public class BaseButtonStyle
    {
        public short Width { get; set; } = 0;
        public short Height { get; set; } = 0;
        public Coord TextPosition { get; set; } = new Coord();
        public string Text { get; set; } = "";
        public short? BackgroundColor { get; set; } = null;
        public short? Color { get; set; } = null;
        public ushort BackgroundChar { get; set; } = ' ';
        public short? TextColor { get; set; } = null;
        public short? TextBackroundColor { get; set; } = null;
    }
}
