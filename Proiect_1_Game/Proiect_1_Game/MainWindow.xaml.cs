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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proiect_1_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerializationActions actions;
        public MainWindow()
        {
            InitializeComponent();

            ObjectToSerialize dataCtx = this.DataContext as ObjectToSerialize;
            actions = new SerializationActions(dataCtx.Users);
            actions.DeserializeObject();

            Closing+=MyWindow_Closing;
            this.ProfilePicBox.Source = new BitmapImage(new Uri("images/ProfilePics/Tree.png", UriKind.Relative));
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {

            if (this.usersGrid.SelectedItem != null)
            {
                User selectedUser = (User)this.usersGrid.SelectedItem;
                GameSelection gameSelection = new GameSelection(selectedUser);
                gameSelection.Show();
            }
            else
            {
                MessageBox.Show("Ejti natarau!");
            }
        }
        private void NewPlayer_Click(object sender, RoutedEventArgs e)
        {
            CreateUserWindow newUserPage = new CreateUserWindow();
            newUserPage.DataContext = this.DataContext;
            newUserPage.Show();
        }

        private void MyWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            actions.SerializeObject(this.DataContext as ObjectToSerialize);
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeletePlayer_Click(object sender, RoutedEventArgs e)
        {
            ObjectToSerialize dataCtx = this.DataContext as ObjectToSerialize;
            if (this.usersGrid.SelectedItem != null)
            {
                dataCtx.Users.Remove((User)usersGrid.SelectedItem);
            }
            else
            {
                MessageBox.Show("N-ai selectat nimic!");
            }
        }

        private void usersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (usersGrid.SelectedItem != null)
            {
                User selectedUser = usersGrid.SelectedItem as User;
                if (selectedUser.ProfilePic != null)
                {
                    //ProfilePicBox.Source = new BitmapImage(new Uri(selectedUser.ProfilePic));
                }
            }
        }
    }
}
