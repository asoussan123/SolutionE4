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

namespace ProjetE4
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        xambibliothequeEntities gst;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new xambibliothequeEntities();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "")
            {
                txtErreur.Text = "Veuillez saisir un login";
            }
            else
            {
                if (txtMdp.Text == "")
                {
                    txtErreur.Text = "Veuillez saisir un Mot de Passe";
                }
                else
                {
                    List<utilisateur> mesUtilisateursLogin = gst.utilisateur.ToList().FindAll(uti => uti.login == txtLogin.Text);
                    utilisateur monUtilisateur = mesUtilisateursLogin.Find(uti => uti.mdp == txtMdp.Text);
                    if (monUtilisateur == null)
                    {
                        MessageBox.Show("Identifiants Incorrects", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (monUtilisateur.statut == "admin")
                        {
                            frmAdmin frm = new frmAdmin(gst, monUtilisateur);
                            frm.Show();
                        }
                        if (monUtilisateur.statut == "client")
                        {
                            frmClient frm = new frmClient(gst, monUtilisateur);
                            frm.Show();
                        }
                    }
                }
            }

        }

        private void btnInscrire_Click(object sender, RoutedEventArgs e)
        {
            frmInscription frm = new frmInscription(gst);
            frm.Show();
        }
    }
}
