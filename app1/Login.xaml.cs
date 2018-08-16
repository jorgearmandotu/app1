﻿using System;
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

namespace app1
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private const string DBName = "inventario.db";
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
            //creo coneecion
            var db = new SQLiteConnection(
               string.Format("Data Source={0};Version=3;", DBName));
            //abro la db
            db.Open();
            //ejecuto query
            SQLiteCommand cmd = new SQLiteCommand("select usuario, pwd from usuarios", db);
            SQLiteDataReader dr = cmd.ExecuteReader();

            Boolean login = false;
            while (dr.Read())
            {
                if (txtUserLogin.Text == Convert.ToString(dr["usuario"]) && txtPwdLogin.Password == Convert.ToString(dr["pwd"]))
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
