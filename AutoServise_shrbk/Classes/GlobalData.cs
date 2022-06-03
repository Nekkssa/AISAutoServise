using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoServise_shrbk.Classes
{
    internal class GlobalData
    {
        public static EF.Client GetClient { get; set; }
        public static EF.Employee GetEmployee { get; set; }
        public static EF.Service GetService { get; set; }
    }
}
