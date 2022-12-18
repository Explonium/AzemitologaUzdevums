using AzemitologaUzdevums.Engine.General;
using System;

namespace AzemitologaUzdevums.Engine.Core
{
    public class Core
    {
        public bool IsRunning { get; set; }
        public DateTime CurrentFrame { get; set; }
        public DateTime PrevFrame { get; set; }
        public double DeltaTime { get; set; }
        public double AccumulatedFrameTime { get; set; }

        public E_Application Application { get; set; }
        public Input Input { get; set; }
        public Renderer Renderer { get; set; }

        public double MaxFramerate { get; set; } = 60.0;


        public Core(E_Application application, short width = 120, short height = 60)
        {
            Input = new Input();
            Renderer = new Renderer(width, height);

            Application = application;
            application.Core= this;
        }

        public void Start()
        {
            IsRunning = true;
            CurrentFrame = DateTime.Now;
            PrevFrame = DateTime.Now;

            while (IsRunning)
            {
                Run();
            }
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Run()
        {
            if (Application.ViewStack.Count == 0)
            {
                Stop();
                return;
            }

            var elapsedTime = (DateTime.Now.Ticks - PrevFrame.Ticks) / 10000000.0;
            var frameTime = 1.0 / MaxFramerate;

            if ((elapsedTime + AccumulatedFrameTime) > frameTime)
            {
                AccumulatedFrameTime += elapsedTime - frameTime;
                if (AccumulatedFrameTime > frameTime)
                {
                    AccumulatedFrameTime = frameTime;
                }

                Renderer.Clear();

                RecalculateDeltaTime();

                Input.Update();

                Application.Update();
                Application.Render();
                Application.ProcessViews();

                Renderer.Render();
            }
        }

        public void RecalculateDeltaTime()
        {
            PrevFrame = CurrentFrame;
            CurrentFrame = DateTime.Now;

            DeltaTime = (CurrentFrame.Ticks - PrevFrame.Ticks) / 10000000.0;
        }
    }
}
