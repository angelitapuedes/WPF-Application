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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SingleMomSummer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        ObservableCollection<MomAccount> mom = new ObservableCollection<MomAccount>();
        XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<MomAccount>));

        public MainWindow()
        {
            InitializeComponent();
        }
        //Second time around
        public MainWindow(ObservableCollection<MomAccount> momma)
        {
            InitializeComponent();
            mom = momma;
            Write();

        }
        private void Write()//Writing is serialize
        {
            string path = "mom.xml";
            if (mom.Count == 0 && File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                using (FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    serializer.Serialize(filestream, mom);
                }
                MessageBox.Show("All moms have written to file", "Success!!");
            }

        }
        //This is a button that a account holder will enter to access the application
        private void SignInButton(object sender, RoutedEventArgs e)
        {
            //ReadStudentsFromMemory();
            //This would lead the user to a log in window
            LoginWindow lw = new LoginWindow(mom);
            lw.ShowDialog();
            this.Close();

        }
        //This is a button that leads the user to a window where the user can create an account
        private void CreateButton(object sender, RoutedEventArgs e)
        {
            //This will take the user to a window where it will have the user will enter there info
            NewAccount nc = new NewAccount();
            nc.ShowDialog();

        }
        private void ReadStudentsFromMemory()
        {
            //name of file to read
            string path = "mom.xml";
            if (File.Exists(path))
            {
                using (FileStream ReadStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    mom = serializer.Deserialize(ReadStream) as ObservableCollection<MomAccount>;//breaking apart into .xmal format
                }
            }
        }
    }
}
