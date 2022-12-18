using System.Collections.Generic;
using System.Linq;

namespace AzemitologaUzdevums.Engine.Core
{
    public abstract class E_Application
    {
        public Core Core { get; set; }
        public List<View> ViewStack { get; set; }
        public List<View> ViewsToAdd { get; set; }
        public List<View> ViewsToRemove { get; set; }

        public E_Application()
        {
            ViewStack = new List<View>();
            ViewsToAdd = new List<View>();
            ViewsToRemove = new List<View>();
        }

        public void AddView(View view)
        {
            ViewsToAdd.Add(view);
        }

        public void RemoveView(View view)
        {
            ViewsToRemove.Add(view);
        }

        public void Update()
        {
            ViewStack.Last().Update();
        }

        public void Render()
        {
            ViewStack.Last().Render();
        }

        public void ProcessViews()
        {
            if (ViewsToAdd.Count > 0)
            {
                foreach (var view in ViewsToAdd)
                {
                    ViewStack.Add(view);
                }

                ViewsToAdd = new List<View>();
            }

            if (ViewsToRemove.Count > 0)
            {
                foreach (var view in ViewsToRemove)
                {
                    ViewStack.Remove(view);
                }

                ViewsToAdd = new List<View>();
            }

            //var activeView = ViewStack.Last();

            //while (ViewStack.Count > 0 && activeView.IsClosing)
            //{
            //    ViewStack.Remove();
            //    activeView = ViewStack.LastOrDefault();
            //}
        }
    }
}
