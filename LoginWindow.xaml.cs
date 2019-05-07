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
using System.Xml.Serialization;

namespace SingleMomSummer
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    { 


        ObservableCollection<MomAccount> momCollection = new ObservableCollection<MomAccount>();
        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<MomAccount>));

    
        public LoginWindow(ObservableCollection<MomAccount> mommalogin)
        {
            InitializeComponent();
            momCollection=mommalogin;
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            ValidateLogin(Username.Text);
        }
        private bool ValidateLogin(string tester)
        {
            MomAccount mom = momCollection.FirstOrDefault(x => x.Username == Username.Text && x.Password == Password.Password);
            if (mom == null)
            {
                Username.Background = Brushes.Coral;
                Password.Background = Brushes.Coral;
                MessageBox.Show("User or password is incorrect");
                ClearAll();
                return false;
            }
            string test = Username.Text;
            AccountView AV = new AccountView(test, mom, momCollection);
            AV.ShowDialog();
            this.Close();
            return true;
        }
        void ClearAll()
        {
            Username.Clear();
            Password.Clear();
            Username.Background = Brushes.White;
            Password.Background = Brushes.White;
        }
    }
}
