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

namespace Wpfzad1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtObwod_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBok_TextChanged(object sender, TextChangedEventArgs e)
        {
            //double bok;
            if (double.TryParse(txtBok.Text, out bok) && bok >=0)
            {
                txtPole.Text = (((bok - topt + bok + +bott) *bok)/2).ToString();
                txtObwod.Text = (bok * 4).ToString();
                lblKomunikat.Content = String.Empty;
            }
            else
            {
                lblKomunikat.Content = "Wpisz liczbę dodatnią";
                txtBok.Text = String.Empty;
                txtPole.Text = String.Empty;
                txtObwod.Text = String.Empty;
            }
        }

      

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        double topt = 0;
        double bott = 0;
        double bok;
        private void btnRysuj_Click(object sender, RoutedEventArgs e)
        {
          
            
            
            


            if (double.TryParse(txtBok.Text, out bok) && bok <= 50 && cmbKolory.SelectedIndex != 0)
            {

                rectanglel.Points.Clear();

                //double halfSize = bok / 2;
                Point topLeft = new Point(-bok - topt /2, -bok);
                Point topRight = new Point(bok + topt/2, -bok);
                Point bottomRight = new Point(bok - bott/2, bok );
                Point bottomLeft = new Point(-bok + bott/2, bok );

                rectanglel.Points.Add(topLeft);
                rectanglel.Points.Add(topRight);
                rectanglel.Points.Add(bottomRight);
                rectanglel.Points.Add(bottomLeft);

            
                SolidColorBrush color = (SolidColorBrush)new BrushConverter().ConvertFromString(cmbKolory.Text);
                rectanglel.Stroke = color;
                rectanglel.Fill = color;
                rectanglel.Opacity = (cbPrzezroczysty.IsChecked.Value) ? 0.5 : 1;
            }
            else
            {
                lblKomunikat.Content = "Brak danych lub zbyt duży bok";
            }
        }
        private void btnWyczysc_Click(object sender, RoutedEventArgs e)
        {
            txtBok.Text = String.Empty;
            txtPole.Text = String.Empty;
            txtObwod.Text = String.Empty;
            rectanglel.Points.Clear();

            lblKomunikat.Content = "Wpisz wymiar boku";


        }

        private void pokazbtn_Checked(object sender, RoutedEventArgs e)
        {
            rectanglel.Opacity = (cbPrzezroczysty.IsChecked.Value) ? 0.5 : 1;

        }

        private void ukryjbtn_Checked(object sender, RoutedEventArgs e)
        {
            rectanglel.Opacity = 0;
        }

        private void Tp_Click(object sender, RoutedEventArgs e)
        {
            if (bok + (topt) < 50 && bott < bok)
            {
                topt++;
                
            }
            else if (bott / 2 < bok)
            {
                bott++;
                
            }
            else
            {
                topt--;
                
            }
            btnRysuj_Click(sender,e);
            txtPole.Text = (((bok + topt/2 + bok - bott/2) * bok) / 2).ToString();

        }

        private void Tm_Click(object sender, RoutedEventArgs e)
        {
            if (bok + (-bott) <50 && -topt < bok)
            {
                bott--;
            
            }
            else if(-topt / 2<bok){
                topt--;
                
            }
            else
            {
                bott++;
                
            }
            btnRysuj_Click(sender,e);
            txtPole.Text = (((bok + topt/2 + bok - bott/2) * bok) / 2).ToString();
        }
    }
}
