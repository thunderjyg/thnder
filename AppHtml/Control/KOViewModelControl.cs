using System.Collections.Generic;
using System.Linq;

namespace AppHtml.Control
{
    //
    using System.Text;
    using DbFrame.Class;

    public class KOViewModelControl
    {
        public StringBuilder ScriptStr(params object[] Models)
        {
            var sb = new StringBuilder();
            foreach (var item in Models)
            {
                if (item is EntityClass)
                {
                    this.GetByModel((EntityClass)item, sb);
                }
                else
                {
                    this.GetByString(item.ToStr(), sb);
                }
            }
            return sb;
        }

        private StringBuilder Get(EntityClass Model, string[] More, StringBuilder sb)
        {
            this.GetByModel(Model, sb);

            if (More != null)
            {
                More.ToList().ForEach(item =>
                {
                    this.GetByString(item, sb);
                });
            }
            return sb;
        }

        private StringBuilder GetByModel(EntityClass Model, StringBuilder sb)
        {
            ReflexHelper.GetPropertyInfos(Model.GetType()).ToList().ForEach(item =>
            {
                sb.Append("this." + item.Name + "=ko.observable('');");
            });
            return sb;
        }

        private StringBuilder GetByString(string More, StringBuilder sb)
        {
            sb.Append("this." + More + "=ko.observable('');");
            return sb;
        }




    }
}