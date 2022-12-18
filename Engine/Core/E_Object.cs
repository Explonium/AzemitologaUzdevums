using AzemitologaUzdevums.Engine.General;
using AzemitologaUzdevums.Engine.General.Draw;

namespace AzemitologaUzdevums.Engine.Core
{
    public abstract class E_Object
    {
        public Coord Coord { get; set; }
        public View View { get; set; }
        public int ZIndex { get; set; } = 0;
        public Input Input { get => View.Application.Core.Input; }
        public Renderer Renderer { get => View.Application.Core.Renderer; }
        public double DeltaTime { get => View.Application.Core.DeltaTime; }

        public abstract void Update();
        public abstract void Render();
    }
}
