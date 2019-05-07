using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for NewAccount.xaml
    /// </summary>
    public partial class NewAccount : Window
    {
        List<string> SummerInterests = new List<string>() { "Free Camps", "Quality Camps", "Family Fun", "Worth The Money Camps" };
        ObservableCollection<MomAccount> momCollection = new ObservableCollection<MomAccount>();
        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<MomAccount>));

        public NewAccount()
        {
            InitializeComponent();
            InterestChoice.ItemsSource = SummerInterests;
        }






        //This button verifies and sends information to the other window
        private void NewAccountCreated(object sender, RoutedEventArgs e)
        {
            if (ValidFunc())
            {
                MomAccount Mom = new MomAccount();
                Mom.Age = int.Parse(ageentry.Text.ToString());
                Mom.FirstNm = firstnameentry.Text;
                Mom.LastNm = lastnameentry.Text;
                Mom.Interest = InterestChoice.SelectedItem.ToString();
                Mom.KidCnt = int.Parse(kidcountentry.Text);
                momCollection.Add(Mom);
                MainWindow mw = new MainWindow(momCollection);

                //NewAccount na = new NewAccount(momCollection);
            }
        }

        private bool ValidFunc()
        {

            bool firstNameValid = string.IsNullOrWhiteSpace(firstnameentry.Text) ? false : ValidateForLetters(firstnameentry.Text);
            firstnameentry.Background = firstNameValid ? Brushes.White : Brushes.Yellow;

            bool lastNameValid = string.IsNullOrWhiteSpace(lastnameentry.Text) ? false : ValidateForLetters(lastnameentry.Text);
            lastnameentry.Background = firstNameValid ? Brushes.White : Brushes.Yellow;

            bool ageValid = string.IsNullOrWhiteSpace(ageentry.Text) ? false : ValidateForIntegers(ageentry.Text);
            ageentry.Background = ageValid ? Brushes.White : Brushes.Yellow;



            return (firstNameValid && lastNameValid && ageValid);


        }
    

    private bool ValidateForLetters(string tester)
    {
        return tester.Where(x => char.IsLetter(x)).Count() == tester.Length;
    }
    private bool ValidateForIntegers(string num)
    {
        return num.Where(x => char.IsDigit(x)).Count() == num.Length;
    }
}
}







    

