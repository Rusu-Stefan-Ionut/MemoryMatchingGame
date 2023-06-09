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
    class SerializationActions
    {
        public ObservableCollection<User> users;
        
        public SerializationActions(ObservableCollection<User> other)
        {
            this.users = other;
        }

        public void SerializeObject(ObjectToSerialize entity)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(ObjectToSerialize));
            FileStream fileStr = new FileStream("DateOut.xml", FileMode.Create);
            xmlser.Serialize(fileStr, entity);
            fileStr.Dispose();
        }

        public void DeserializeObject()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(ObjectToSerialize));
            FileStream file = new FileStream("DateOut.xml", FileMode.Open);
            //se pierde referinta la colectie prin reinitializarea ei cu un alt obiect
            //this.cars = (xmlser.Deserialize(file) as ObjectToSerialize).Cars;
            //din acest motiv repopulez colectia this.cars cu elementele colectiei obtinute prin deserializare
            var elem_salvate = (xmlser.Deserialize(file) as ObjectToSerialize).Users;
            users.Clear();
            foreach (var user in elem_salvate)
            {
                users.Add(user);
            }
            file.Dispose();
        }
    }
}
