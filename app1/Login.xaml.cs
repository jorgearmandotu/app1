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
using System.Data.SQLite;
using app1.data;
using System.IO;

namespace app1
{
    
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private const string DBName = ValuesDB.DBName;
        public Window1()
        {
            
            InitializeComponent();
            txtUserLogin.Focus();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        { if (e.Key == Key.Return)
            {
                logear();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            logear();
        }

        private void logear()
        {
        	string path = Directory.GetCurrentDirectory();
        MessageBox.Show(path);
        MessageBox.Show(DBName);
            //creo coneecion
            var db = new SQLiteConnection(
               string.Format("Data Source={0};Version=3;", DBName));
            //abro la db
            db.Open();
            //ejecuto query
            String sql = $"select {ValuesDB.userUsuarioDB}, {ValuesDB.userPasswordDB} from {ValuesDB.tablaUsuarios}";
            SQLiteCommand cmd = new SQLiteCommand(sql, db);

            SQLiteDataReader dr = cmd.ExecuteReader();
            
            Boolean login = false;
            while (dr.Read())
            {
                if (txtUserLogin.Text == Convert.ToString(dr["usuario"]) && txtPwdLogin.Password == Convert.ToString(dr["pasword"]))
                {
                    MainWindow dasborad = new MainWindow();
                    dasborad.Show();
                    dr.Close();
                    db.Dispose();
                    this.Close();
                    login = true;
                    break;
                    //return;
                }
            }
            
            db.Dispose();
            if (!login)
            {
                MessageBox.Show("Datos erroneos");
                txtUserLogin.Text = "";
                txtPwdLogin.Password = "";
                txtUserLogin.Focus();
            }


            /*if (txtUser.Text == "admin" && txtPwd.Text == "12312")
            {
               this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Datos Incorectos");
                txtUser.Text = "";
                txtPwd.Text = "";
                txtUser.Focus();
            }*/
        }
    }
}
