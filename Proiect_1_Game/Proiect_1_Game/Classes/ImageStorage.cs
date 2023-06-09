using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proiect_1_Game
{
    public class ImageStorage
    {
        private static List<string> catJpg;
        private static int index;
        public List<string> CatJpg 
        {
            get { return catJpg; }
            set { catJpg = value; }
        }

        public int Index 
        {
            get { return index; }
            set { index = value; } 
        }

        public ImageStorage()
        {
            index = 0;
            catJpg = new List<string>();
            catJpg.Add("images/ProfilePics/Coco.jpg");
            catJpg.Add("images/ProfilePics/Fanica.jpg");
            catJpg.Add("images/ProfilePics/CosticaFulger.jpg");
            catJpg.Add("images/ProfilePics/GicuLicuricu.jpg");
            catJpg.Add("images/ProfilePics/IonutDiamantu.jpg");
            catJpg.Add("images/ProfilePics/4doresmorehoes.jpg");
            catJpg.Add("images/ProfilePics/Gigel.jpg");
        }
    }
}
