using System.Collections.Generic;
using System.Linq;

namespace AzemitologaUzdevums.Engine.Core
{
    public class View
    {
        public E_Application Application { get; set; }
        public List<E_Object> Objects { get; set; }
        public List<E_Object> ObjectsToAdd { get; set; }
        public List<E_Object> ObjectsToRemove { get; set; }
        public bool IsClosing { get; set; } = false;

        public View()
        {
            Objects = new List<E_Object>();
            ObjectsToAdd = new List<E_Object>();
            ObjectsToRemove = new List<E_Object>();
        }

        public void Close()
        {
            IsClosing = true;
        }

        public void AddObject(E_Object obj)
        {
            ObjectsToAdd.Add(obj);
        }

        public void RemoveObject(E_Object obj)
        {
            ObjectsToRemove.Add(obj);
        }

        public virtual void Update()
        {
            if (ObjectsToAdd.Count > 0)
            {
                Objects.AddRange(ObjectsToAdd);
                ObjectsToAdd = new List<E_Object>();
            }

            if (ObjectsToRemove.Count > 0)
            {
                foreach (var obj in ObjectsToRemove)
                {
                    Objects.Remove(obj);
                }

                ObjectsToRemove = new List<E_Object>();
            }

            foreach (var obj in Objects)
            {
                obj.Update();
            }

        }

        public virtual void Render()
        {
            foreach (var obj in Objects.OrderBy(x => x.ZIndex).ToList())
            {
                obj.Render();
            }
        }
    }
}
