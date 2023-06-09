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
using System.Windows.Threading;

namespace Proiect_1_Game
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    
    public partial class Game : Window
    {
        private Button firstClickedButton = null;
        private Tile firstClickedTile = null;
        private bool twoNotMathced = false;
        private int clicked = 0;
        User currentUser = null;
        public Game(User theUser)
        {
            InitializeComponent();
            currentUser = theUser;
            DataContext = theUser.GameBoard;
            ProfileImage.Source = new BitmapImage(new Uri(theUser.ProfilePic));
            PlayedGamesLbl.DataContext= theUser;
            LevelLbl.DataContext = theUser;
            WonGamesLbl.DataContext = theUser;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var gameBoard = currentUser.GameBoard as GameBoard;

            if (clicked < 2)
            { 
                if (twoNotMathced == true)
                {
                    firstClickedTile = null;
                    firstClickedButton = null;
                    twoNotMathced = false;
                }
            
                Button clickedButton = (Button)sender;
                Tile clickedTile = (Tile)clickedButton.DataContext;

                // Ignore clicks on tiles that are already matched or showing their front face
                if (clickedTile.IsShowingFrontFace || clickedTile.IsMatched)
                {
                    return;
                }

                // Show the front face of the clicked tile
                clickedTile.IsShowingFrontFace = true;

                if (firstClickedTile == null)
                {
                    // This is the first clicked tile
                    firstClickedTile = clickedTile;
                    firstClickedButton = clickedButton;
                    clicked++;
                }
                else if (firstClickedTile != clickedTile && firstClickedTile!=null)
                {
                    clicked++;
                    // This is the second clicked tile
                    if (firstClickedTile.FrontFace == clickedTile.FrontFace)
                    {
                        // The two clicked tiles match, mark them as matched
                        

                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromSeconds(0.5);
                        timer.Tick += (s, args) =>
                        {
                            gameBoard.CheckMatch(firstClickedTile, clickedTile);
                            isGameWon(gameBoard);
                            clicked = 0;
                            timer.Stop();
                        };
                        timer.Start();
                    }
                    else
                    {
                        // The two clicked tiles don't match, hide their front faces after a short delay
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromSeconds(0.5);
                        timer.Tick += (s, args) =>
                        {
                            firstClickedTile.IsShowingFrontFace = false;
                            clickedTile.IsShowingFrontFace = false;
                            clicked = 0;
                            timer.Stop();
                        };
                        timer.Start();
                    }

                    // Reset the first clicked tile
                    twoNotMathced = true;
                }
            }
        }

        private void isGameWon(GameBoard gameBoard)
        {
            if (gameBoard.CheckWin() == true)
            {
                currentUser.Level++;
                if (currentUser.Level == 3)
                {
                    currentUser.WonGames++;
                    currentUser.Level = 0;

                    MessageBoxResult result = MessageBox.Show("Do you want to continue?", "Confirmation", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.No)
                    {
                        this.Close();
                        return;
                    }

                    currentUser.PlayedGames++;
                }
                int height = gameBoard.Height;
                int width = gameBoard.Width;
                GameBoard newGameBoard=new GameBoard(height, width);
                this.DataContext=newGameBoard;
                currentUser.GameBoard = newGameBoard;
                Game newGame=new Game(currentUser);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}