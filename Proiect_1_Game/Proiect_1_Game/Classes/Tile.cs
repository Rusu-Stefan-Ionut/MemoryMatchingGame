using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml.Serialization;

namespace Proiect_1_Game
{
    [Serializable]
    public class Tile : INotifyPropertyChanged
    {
        private string frontFace;
        private string backFace;
        private string currentImage;

        private bool isShowingFrontFace;
        private bool isMatched;

        private Visibility isVisible;

        [XmlElement]
        public string FrontFace
        {
            get { return frontFace; }
            set
            {
                frontFace = value;
                NotifyPropertyChanged(nameof(FrontFace));
            }
        }

        [XmlElement]
        public string BackFace
        {
            get { return backFace; }
            set
            {
                backFace = value;
                NotifyPropertyChanged(nameof(BackFace));
            }
        }

        [XmlElement]
        public bool IsShowingFrontFace
        {
            get { return isShowingFrontFace; }
            set
            {
                isShowingFrontFace = value;
                CurrentImage = isShowingFrontFace ? FrontFace : BackFace;
                NotifyPropertyChanged(nameof(IsShowingFrontFace));
                NotifyPropertyChanged(nameof(CurrentImage));
            }
        }

        [XmlElement]
        public bool IsMatched
        {
            get { return isMatched; }
            set
            {
                isMatched = value;
                isVisible = IsMatched ? Visibility.Visible : Visibility.Hidden;
                NotifyPropertyChanged(nameof(isVisible));
                NotifyPropertyChanged(nameof(IsMatched));
            }
        }

        //  [XmlElement]
        public string CurrentImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                NotifyPropertyChanged(nameof(CurrentImage));
            }
        }

        public Visibility IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; NotifyPropertyChanged(nameof(IsVisible)); }
        }


        Tile() { }

        public Tile(string frontFace)
        {
            FrontFace = frontFace;
            BackFace = "images/TilePics/DefaultBack.jpg";
            isShowingFrontFace = false;
            isMatched = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
