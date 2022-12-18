using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Application.Objects.Styles
{
    public class BaseFigureStyle
    {
        public short? BackgroundColor { get; set; } = null;
        public short? Color { get; set; } = null;
        public ushort BackgroundChar { get; set; } = ' ';
        public short? SecondaryBackgroundColor { get; set; } = null;
        public short? SecondaryColor { get; set; } = null;
        public ushort SecondaryBackgroundChar { get; set; } = ' ';
    }
}
