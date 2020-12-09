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
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            //CreateGrid();
        }

        private void CreateGrid()
        {
            //Création de la grille
            Grid grid = new Grid();
            for (int i = 1; i <= 4; i++)
            {
                //On ajoute 4 Lignes
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(i, GridUnitType.Star) });

                //on ajoute 4 Colonnes
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(i, GridUnitType.Star) });
            }

            for (int i = 0; i < 4; i++)
            {
                Button b = new Button()
                {
                    Content = i,
                    Background = new SolidColorBrush(Color.FromRgb(0, 0, 0)),
                };
                //b.Click += Click_b1;
                b.MouseDoubleClick += Click_b1;
                grid.Children.Add(b);
                Grid.SetRow(b, i);
                Grid.SetColumn(b, i);
            }
            Content = grid;
        }

        private void Click_b1(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                //if(e.RoutedEvent.Name == "Click")
                //{
                //    MessageBox.Show("Click " + b.Content.ToString());
                //}
                //else if (e.RoutedEvent.Name == "MouseDoubleClick")
                //{
                //    MessageBox.Show("Double click " + b.Content.ToString());
                //}
                MessageBox.Show(monTexte.Text);
            }
        }
    }
}
