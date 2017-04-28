using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTask.Enum;
using Xamarin.Forms;

namespace WTask.Shared
{
    public class EnumConverter
    {
        public static List<string> Converter()
        {
            var list = new List<string>();

            list.Add(PriorityItem.Hight.ToString());
            list.Add(PriorityItem.Low.ToString());
            list.Add(PriorityItem.Major.ToString());
            list.Add(PriorityItem.Medium.ToString());
            list.Add(PriorityItem.None.ToString());

            return list;
        }
    }
}
