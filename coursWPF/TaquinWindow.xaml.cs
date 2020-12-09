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

namespace coursWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TaquinWindow : Window
    {
        private int taille = 3;
        private string stringWin = "";
        private TextBox dField;

        private char[] tab;
        public TaquinWindow()
        {
            InitializeComponent();
            MakeRowsAndCols();
            MakeDField();
            GenerateCharTab();            
            MakeShuffleButton();           
            MakeGrid();
        }

        private void GenerateCharTab()
        {
            int nb;         
            if(Int32.TryParse(dField.Text, out nb))
            {
                taille = nb;
            }
            else
            {
                taille = 3;
            }
            tab = new char[taille * taille - 1];
            char c = 'A';
            for(int i=0; i < tab.Length; i++)
            {
                tab[i] = c;
                stringWin += c;
                c++;
            }
            stringWin += '#';
        }

        #region methode rendu
        private void MakeRowsAndCols()
        {
            //Création des lignes et des colonnes
            for (int i = 1; i <= taille; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            grid.RowDefinitions.Add(new RowDefinition());
        }

        private void MakeDField()
        {
            dField = new TextBox();
            grid.Children.Add(dField);
            Grid.SetColumn(dField, 0);
            Grid.SetRow(dField,0);
        }
        private void MakeShuffleButton()
        {
            Button b = new Button()
            {
                Content = "Melanger"
            };
            b.Click += ShuffleClick;
            grid.Children.Add(b);
            Grid.SetColumn(b,taille-1);
            Grid.SetRow(b,0);
        }     
        private void MakeGrid()
        {
            int k = 0;
            for(int i=1; i< taille+1; i++)
            {
                for(int j= 0; j < taille; j++)
                {
                    if(!(j == taille-1 && i == taille))
                    {
                        Button b = new Button()
                        {
                            Content = tab[k]
                        };
                        b.Click += ClickButton;
                        grid.Children.Add(b);
                        Grid.SetRow(b, i);
                        Grid.SetColumn(b, j);
                        k++;
                    }
                }
            }
        }
        #endregion

        #region methode event
        private void ShuffleClick(object sender, RoutedEventArgs e)
        {
            GenerateCharTab();
            Random r = new Random();
            for(int i=0; i < tab.Length; i++)
            {
                int tmpIndex = r.Next(0, tab.Length);
                char tmpChar = tab[i];
                tab[i] = tab[tmpIndex];
                tab[tmpIndex] = tmpChar;
            }
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
            MakeRowsAndCols();
            MakeShuffleButton();
            MakeDField();
            MakeGrid();
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                int x = Grid.GetRow(b);
                int y = Grid.GetColumn(b);
                if(y < taille - 1 && TestMove(x, y + 1))
                {
                    Grid.SetColumn(b, y + 1);
                }
                else if(y > 0 && TestMove(x, y - 1))
                {
                    Grid.SetColumn(b, y - 1);
                }
                else if(x < taille && TestMove(x + 1, y))
                {
                    Grid.SetRow(b, x + 1);
                }
                else if(x > 1 && TestMove(x - 1, y))
                {
                    Grid.SetRow(b, x - 1);
                }
                if(TestWin())
                {
                    MessageBox.Show("Bravo ! ");
                }
            }
        }
        #endregion
        private bool TestMove(int x, int y)
        {
            UIElement element = grid.Children.Cast<UIElement>()
                .FirstOrDefault(e => Grid.GetColumn(e) == y && Grid.GetRow(e) == x);
            return element == null;
        }

        private bool TestWin()
        {
            string tmpString = "";
            for(int i=1; i < taille+1; i++)
            {
                for(int j = 0; j < taille; j++)
                {
                    UIElement element = grid.Children.Cast<UIElement>()
                    .FirstOrDefault(e => Grid.GetColumn(e) == j && Grid.GetRow(e) == i);
                    if(element == null)
                    {
                        tmpString += "#";
                    }
                    else
                    {
                        if(element is Button b)
                        {
                            tmpString += b.Content.ToString();
                        }
                    }
                }
            }
            return stringWin == tmpString;
        }
        
    }
}
