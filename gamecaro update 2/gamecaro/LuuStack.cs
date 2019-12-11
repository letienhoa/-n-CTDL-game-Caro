using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamecaro
{
    public class LuuStack
    {
        public Point point {get;set;}
        public int luuluotchoi { get; set; }
        public LuuStack()
        {

        }
        public LuuStack(Point a ,int Luuluotchoi)
        {
            this.point=a;
            this.luuluotchoi=Luuluotchoi;
        }

    }
}
