using AzemitologaUzdevums.Application.Views;
using AzemitologaUzdevums.Engine.Core;

namespace AzemitologaUzdevums.Application
{
    public class App : E_Application
    {
        public App() : base()
        {
            ViewStack.Add(new StartView { Application = this });
        }
    }
}
