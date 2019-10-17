using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamecaro
{
    class nguoichoi
    {
        private string name;
public string Name { get => name; set => name = value; }
        public Image Bieutuong { get => bieutuong; set => bieutuong = value; }

        private Image bieutuong;
        public nguoichoi(string name,Image bieutuong)
        {
            this.Name = name;
            this.Bieutuong = bieutuong;
        }
    }
}
