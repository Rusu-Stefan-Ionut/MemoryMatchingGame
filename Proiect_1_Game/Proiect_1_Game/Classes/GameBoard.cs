using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Xml.Serialization;

namespace Proiect_1_Game
{
    [Serializable]
    public class GameBoard
    {
        private ObservableCollection<ObservableCollection<Tile>> m_gameTiles;

        private int m_height;
        private int m_width;
        private int m_matchedCount;

        [XmlArray("collection")]
        [XmlArrayItem("Tile")]
        public ObservableCollection<ObservableCollection<Tile>> GameTiles
        {
            get { return m_gameTiles; }
            set { m_gameTiles = value; }
        }

        [XmlElement]
        public int Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        [XmlElement]
        public int Width
        {
            get { return m_width; }
            set { m_width = value; }
        }

        [XmlElement]
        public int MatchedCount
        {
            set { m_matchedCount = value; }
            get { return m_matchedCount; }
        }

        GameBoard() { }
        public GameBoard(int height = 6, int width = 6)
        {
            Height = height;
            Width = width;
            MatchedCount = 0;
            GameTiles = new ObservableCollection<ObservableCollection<Tile>>();
            for (int i = 0; i < Height ; i++)
            {
                var tempColection = new ObservableCollection<Tile>();
                for (int j = 0; j < Width/2 ; j++)
                {
                    Tile newTile = new Tile("images/TilePics/img (" + (i * Height + j + 1).ToString() + ").jpg");
                    Tile newTile2 = new Tile("images/TilePics/img (" + (i * Height + j + 1).ToString() + ").jpg");
                    tempColection.Add(newTile);
                    tempColection.Add(newTile2);
                }  
                GameTiles.Add(tempColection);
            }
            int variable = Height * Width / 2+1;
            if (Width % 2==1)
            {
                for (int i=0; i<Height; i++)
                {
                    var tempColection = GameTiles[i];
                    Tile newTile = new Tile("images/TilePics/img (" + (variable + (i/2) * Height + 1).ToString() + ").jpg");
                        tempColection.Add(newTile);
                }
            }
            ShuffleTiles();
        }

        private void ShuffleTiles()
        {
            //Randomizing slide indexes
            var rnd = new Random();
            //Shuffle memory slides
            for (int i = 0; i < Height*Width; i++)
            {
                int coll1 = rnd.Next(Height);
                int coll2 = rnd.Next(Height); 
                int elem1 = rnd.Next(Width);
                int elem2 = rnd.Next(Width);
                ObservableCollection<Tile> tempColl1 = GameTiles[coll1];
                ObservableCollection<Tile> tempColl2 = GameTiles[coll2];
                Tile tempTile = tempColl2[elem2];
                tempColl2[elem2] = tempColl1[elem1];
                tempColl1[elem1] = tempTile; 
            }
        }

        public void CheckMatch(Tile tile1, Tile tile2)
        {
            if (tile1.FrontFace == tile2.FrontFace)
            {
                tile1.IsMatched = true;
                tile2.IsMatched = true;
                tile1.IsVisible = Visibility.Hidden;
                tile2.IsVisible = Visibility.Hidden;
                MatchedCount += 2;
            }
        }

        public bool CheckWin()
        {
            if (MatchedCount == Height*Width)
            {
                MessageBox.Show("You have won!");
                return true;
            }
            else if( Height*Width%2==1 && MatchedCount == Height * Width -1)
            {
                MessageBox.Show("You have won!");
                return true;
            }
            return false;
        }

    }
}
