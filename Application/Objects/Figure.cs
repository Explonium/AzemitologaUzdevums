using AzemitologaUzdevums.Application.Objects.Styles;
using AzemitologaUzdevums.Engine.Core;

namespace AzemitologaUzdevums.Application.Objects
{
    public abstract class Figure : E_Object
    {
        public int Size { get; set; } = 10;
        public Style Style { get; set; }
        protected Style BaseStyle { get; set; } = new Style(new BaseFigureStyle());
        protected Style CurrentStyle { get; set; }

        public Figure(View view) : base()
        {
            View = view;
        }

        public override void Update()
        {
            CurrentStyle = BaseStyle + Style;
        }
    }
}
