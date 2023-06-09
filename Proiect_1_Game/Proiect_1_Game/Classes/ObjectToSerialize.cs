using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Proiect_1_Game
{
    [Serializable]
    public class ObjectToSerialize
    {
        [XmlArray]
        public ObservableCollection<User> Users { get; set; }

        public ObjectToSerialize()
        {
            Users = new ObservableCollection<User>();
        }
    }
}
