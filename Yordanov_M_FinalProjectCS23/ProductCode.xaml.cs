using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Yordanov_M_FinalProjectCS23
{
    /// <summary>
    /// Interaction logic for ProductCode.xaml
    /// </summary>
    public partial class ProductCode : Window
    {
        public ProductCode()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try

            {

                SqlConnection dbConnection = new SqlConnection(@"Data Source=LABSCIFIPC16\LOCALHOST;Initial Catalog=Final_Project;Integrated Security=True");

                dbConnection.Open();

                string qe = "Select * from Product_Info WHERE Product_Code= '" + code.Text + "'";

                SqlCommand load = new SqlCommand(qe, dbConnection);

                load.ExecuteNonQuery();

                SqlDataAdapter ALoad = new SqlDataAdapter(load);

                DataTable DTLOAD = new DataTable();

                ALoad.Fill(DTLOAD);

                dataGrid.ItemsSource = DTLOAD.DefaultView;

                ALoad.Update(DTLOAD);

                MessageBox.Show("Load successfully");

                dbConnection.Close();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Home(object sender, RoutedEventArgs e)
        {
            MainMenu lg = new MainMenu();
            lg.Show();
            this.Close();
        }
    }
}
