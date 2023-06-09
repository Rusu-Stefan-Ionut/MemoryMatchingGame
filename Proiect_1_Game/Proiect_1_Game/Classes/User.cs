using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Proiect_1_Game
{
    [Serializable]
    public class User
    {
        private string m_name;
        private string profilePic;

        GameBoard m_gameBoard;
        private int m_playedGames;
        private int m_wonGames;
        private int m_level;
        public User() { }
        public User(string name, string profilePic, int playedGames=0, int wonGames=0, int level=0)
        {
            Name = name;
            ProfilePic = profilePic;
            PlayedGames = playedGames;
            WonGames = wonGames;
            Level = level;
        }

        [XmlAttribute]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        [XmlElement]
        public int WonGames
        {
            get { return m_wonGames; }
            set { m_wonGames = value; }
        }

        [XmlElement]
        public int PlayedGames
        {
            get { return m_playedGames; }
            set { m_playedGames = value; }
        }

        [XmlElement]
        public string ProfilePic
        {
            get { return profilePic; }
            set { profilePic = value; }
        }

        [XmlElement]
        public GameBoard GameBoard
        {
            get { return m_gameBoard; }
            set { m_gameBoard = value; }
        }

        [XmlElement]
        public int Level
        {
            get { return m_level; }
            set { m_level = value; }
        }
    }
}
