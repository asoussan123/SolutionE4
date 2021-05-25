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
    /// Logique d'interaction pour frmInscription.xaml
    /// </summary>
    public partial class frmInscription : Window
    {
        xambibliothequeEntities gst;
        public frmInscription(xambibliothequeEntities unGst)
        {
            InitializeComponent();
            gst = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnInscription_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Veuillez saisir un login", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (txtMdp.Text == "")
                {
                    MessageBox.Show("Veuillez saisir un mot de passe", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (txtAdresse.Text == "")
                    {
                        MessageBox.Show("Veuillez saisir une adresse", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        utilisateur monUtilisateur = new utilisateur()
                        {
                            login = txtLogin.Text,
                            mdp = txtMdp.Text,
                            adresse = txtAdresse.Text,
                            statut = "client",
                        };
                        gst.utilisateur.Add(monUtilisateur);
                        gst.SaveChanges();
                        MessageBox.Show("Votre compte a bien été créé", "Compte créé", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
            }

        }
    }
}
