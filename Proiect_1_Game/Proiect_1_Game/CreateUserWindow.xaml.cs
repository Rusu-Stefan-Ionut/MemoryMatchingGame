using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proiect_1_Game
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        ImageStorage imageStorage=new ImageStorage();
        public CreateUserWindow()
        {
            InitializeComponent();
            ImageBox.Source = new BitmapImage(new Uri(imageStorage.CatJpg[imageStorage.Index], UriKind.Relative));
        }

        private void SageataStanga_Click(object sender, RoutedEventArgs e)
        {
            if (imageStorage.Index > 0)
            {
                imageStorage.Index--;
            }
            else
            {
                imageStorage.Index = imageStorage.CatJpg.Count - 1;
            }
            ImageBox.Source = new BitmapImage(new Uri(imageStorage.CatJpg[imageStorage.Index], UriKind.Relative));
        }

        private void SageataDreapta_Click(object sender, RoutedEventArgs e)
        {
            if (imageStorage.Index < imageStorage.CatJpg.Count - 1)
            {
                imageStorage.Index++;
            }
            else
            {
                imageStorage.Index = 0;
            }
            ImageBox.Source = new BitmapImage(new Uri(imageStorage.CatJpg[imageStorage.Index], UriKind.Relative));
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NameTextBox.Text != "")
            {
                ObjectToSerialize dataCtx = this.DataContext as ObjectToSerialize;
                dataCtx.Users.Add(new User { Name = this.NameTextBox.Text, ProfilePic = this.ImageBox.Source.ToString()});
                this.Close();
            }
            else
            {
                MessageBox.Show("Pune un nume pls");
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
