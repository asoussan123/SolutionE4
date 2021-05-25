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
    /// Logique d'interaction pour frmAdmin.xaml
    /// </summary>
    public partial class frmAdmin : Window
    {
        xambibliothequeEntities gst;
        utilisateur monUtilisateur;
        public frmAdmin(xambibliothequeEntities unGst, utilisateur unUtilisateur)
        {
            InitializeComponent();
            gst = unGst;
            monUtilisateur = unUtilisateur;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBonjour.Text = "Content de vous revoir " + monUtilisateur.login;
            lstLivres.ItemsSource = gst.livre.ToList();
            cboGenre.ItemsSource = gst.genrelivre.ToList();
            cboTheme.ItemsSource = gst.themelivre.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            livre monLivre = new livre()
            {
                titre = txtTitre.Text,
                auteur = txtAuteur.Text,
                image = txtImage.Text,
                genrelivre = cboGenre.SelectedItem as genrelivre,
                themelivre = cboTheme.SelectedItem as themelivre,
                quantite = Convert.ToInt32(txtQuantite.Text),
            };
            gst.livre.Add(monLivre);
            gst.SaveChanges();
            lstLivres.ItemsSource = null;
            lstLivres.ItemsSource = gst.livre.ToList();
        }
    }
}
