using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AzemitologaUzdevums.Application.Objects.Styles
{
    public class Style : Dictionary<string, dynamic>
    {
        public Style() : base()
        { }
        public Style(Dictionary<string, dynamic> obj) : base(obj)
        { }
        public Style(object obj) : base()
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                Add(prop.Name, prop.GetValue(obj, null));
            }
        }

        public static Style operator +(Style a, Style b)
        {
            var o = new Style(a);

            if(b != null)
            {
                foreach (var key in b.Keys)
                {
                    if (o.ContainsKey(key))
                    {
                        o[key] = b[key];
                    }
                    else
                    {
                        o.Add(key, b[key]);
                    }
                }
            }
            
            return o;
        }
    }
}
