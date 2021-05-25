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

namespace ProjetE4
{
    /// <summary>
    /// Logique d'interaction pour frmProfil.xaml
    /// </summary>
    public partial class frmProfil : Window
    {
        xambibliothequeEntities gst;
        utilisateur monUtilisateur;
        public frmProfil(xambibliothequeEntities unGst, utilisateur unUtilisateur)
        {
            InitializeComponent();
            gst = unGst;
            monUtilisateur = unUtilisateur;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBonjour.Text = "Profil de " + monUtilisateur.login;
            lstReservations.ItemsSource = gst.reserver.ToList().FindAll(re => re.utilisateur.Id == monUtilisateur.Id);

        }

        private void btnProfil_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRemettre_Click(object sender, RoutedEventArgs e)
        {
            if (lstReservations.SelectedItem != null)
            {
                reserver laReservation = gst.reserver.ToList().Find(re => re.livre == (lstReservations.SelectedItem as reserver).livre && re.utilisateur == (lstReservations.SelectedItem as reserver).utilisateur);
                gst.reserver.Remove(laReservation);
                gst.SaveChanges();
                MessageBox.Show("Vous avez bien rendu le livre", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                lstReservations.ItemsSource = null;
                lstReservations.ItemsSource = gst.reserver.ToList().FindAll(re => re.utilisateur.Id == monUtilisateur.Id);
            }
        }

        private void lstReservations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstReservations.SelectedItem != null)
            {
                if (DateTime.Compare((lstReservations.SelectedItem as reserver).dateRemise, DateTime.Now) < 0)
                {
                    imgAction.Source = new BitmapImage(new Uri("/Image/Retard.png", UriKind.RelativeOrAbsolute));
                }

            }

        }
    }
}

