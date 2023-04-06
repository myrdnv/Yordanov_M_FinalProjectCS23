using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Yordanov_M_FinalProjectCS23
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=LABSCIFIPC16\LOCALHOST;Initial Catalog=Final_Project;Integrated Security=True");
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="H:\12-5 Infromatics Yovchevski\Final Project\Yordanov_M_FinalProjectCS23\Yordanov_M_FinalProjectCS23\FinalProject.mdf";Integrated Security=True

            if (masterPass.Password == "pass")
            {
                try
                {
                    sqlCon.Open();

                    string query = "INSERT INTO LogIn_Details(FirstName,LastName,Email,Password)values ('" + firstName.Text + "','" + lastName.Text + "','" + email.Text + "','" + password.Password + "') ";

                    SqlCommand cmd = new SqlCommand(query, sqlCon);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully registered");

                    LogIn lg = new LogIn();
                    lg.Show();
                    this.Close();

                }

                catch (Exception ex)

                {

                    MessageBox.Show(ex.Message);

                }

                finally

                {

                    sqlCon.Close();

                }
            }
            else
            {
                MessageBox.Show("Wrong or missing Master Password");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogIn lg = new LogIn();
            lg.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LogIn lg = new LogIn();
            lg.Show();
            this.Close();
        }
    }
}
