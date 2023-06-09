using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for GameSelection.xaml
    /// </summary>
    public partial class GameSelection : Window
    {
        User currentUser;
        public GameSelection(User selectedUser)
        {
            InitializeComponent();
            DataContext= selectedUser;
            currentUser= selectedUser;
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            GameBoard newGameBoard;
            if (HeightBox.Text == "" || WidthBox.Text == "")
            {
                newGameBoard = new GameBoard();
            }
            else
            {
                newGameBoard = new GameBoard(int.Parse(HeightBox.Text), int.Parse(WidthBox.Text));
            }
            currentUser.GameBoard = newGameBoard;
            currentUser.PlayedGames++;
            Game game = new Game(currentUser);
            game.Show();
        }

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            GameBoard tempBoard=new GameBoard();
            if (currentUser.Level==0 && currentUser.GameBoard==null)
            {
                MessageBox.Show("No previous game was saved");
            }
            else
            {
                Game game = new Game(currentUser);
                game.Show();
            }
        }

        private void HeightBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
