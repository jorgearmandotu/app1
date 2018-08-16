using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows;

namespace app1.data
{
    class DataBase
    {
        
        private SQLiteConnection con;

        public DataBase()
        {
            
            con = new SQLiteConnection(string.Format($"Data Source={ValuesDB.DBName};Version={ValuesDB.DataVersion};"));

        }

        private void  Conectar()
        {
            //con = new SQLiteConnection(string.Format($"Data Source={ValuesDB.DBName};Version={ValuesDB.DataVersion};"));
            con.Open();
            
        }

       public SQLiteDataReader EjecutarSql(String sql)
        {
            Conectar();
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            return dr;
            
        }

        public DataTable DatosTablaDB(String sql)
        {
            DataTable dt = new DataTable();
            Conectar();
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            SQLiteDataAdapter datos = new SQLiteDataAdapter(cmd);
            datos.Fill(dt);

            return dt;
        }

        public Boolean InsertarSQL(String sql)
        {
            bool res = false;
            Conectar();

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
                res = true;
                CerrarCon();
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                CerrarCon();
            }

            
            return res;
        }

        public Boolean InsertarTransaacionSQL(String sql)
        {
            bool res = false;
            Conectar();
            try
            {
                using (SQLiteTransaction tr = con.BeginTransaction())
                {
                    using (SQLiteCommand cmd = new SQLiteCommand())
                    {
                        cmd.Transaction = tr;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                    tr.Commit();
                    res = true;
                }
                CerrarCon();
            }catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
                CerrarCon();
            }

            return res;
        }

        public void CerrarCon()
        {
            con.Dispose();
        }
    }
}