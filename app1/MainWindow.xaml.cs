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
using System.Data.SQLite;
using app1.data;
using System.Data;
using ResourcesApp;
using Microsoft.Win32;
using System.IO.Packaging;
using System.IO;
using app1.objetos;
using System.Threading;
//using Microsoft.Office.Interop.Excel;

namespace app1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DBName = "inventario.db";

        public MainWindow()
        {

            InitializeComponent();
           
            cargartxtProductos();
            cargartxtProveedor();
            cargarcmbIngCategoria();
            cargarTxtClientes();
            cargartxtBusquedaReporte();
            //var instFolder = Package.Current.InstalledLocation;
            //var imgPath = @"ms-appx:///Assets\conejo.bmp";
            var s = Directory.GetCurrentDirectory();

            imgIngresoProducto.Source = new BitmapImage(new Uri(s + "..\\..\\..\\\\resources\\imagenes\\imagenSmall.png"));

            cargarIngresosDataGrid();
            /*Movimiento mov = new Movimiento("1231", 12, "05/08/2018", "cemento", "usuario", "ingreso", "Argos");
            datosGrid.Items.Add(mov);*/
        }

        private void cargarcmbIngCategoria()
        {
            cmbIngCategoria.Items.Clear();
            DataBase db = new DataBase();
            String sql = $"select {ValuesDB.categoriNombreDB} from {ValuesDB.tablaCategoria}";
            SQLiteDataReader dr = db.EjecutarSql(sql);

            SQLiteDataAdapter adap = new SQLiteDataAdapter();

            while (dr.Read())
            {

                String nombre = Convert.ToString(dr["nombre"]);
                cmbIngCategoria.Items.Add(nombre);

            }
            dr.Close();
            db.CerrarCon();
            cmbIngCategoria.Items.Insert(0, StringResources.cmbSelecionCategoria);
            cmbIngCategoria.SelectedIndex = 0;


        }

        private void cargartxtProductos()
        {

            DataBase db = new DataBase();
            String sql = $"select {ValuesDB.productoNombreDB} from {ValuesDB.tablaProducto}";
            SQLiteDataReader dr = db.EjecutarSql(sql);

            txtProducto.RemoveAllItem();
            txtSalidaCliente.RemoveAllItem();
            while (dr.Read())
            {
                String nombre = Convert.ToString(dr["nombre"]);
                String[] sugerencias = nombre.Split(' ');

                foreach (var text in sugerencias)
                {
                    txtProducto.AddItem(new AutoCompleteEntrada(nombre, text));
                    txtSalidaProducto.AddItem(new AutoCompleteEntrada(nombre, text));
                }

            }
            dr.Close();
            db.CerrarCon();



        }

        private void cargartxtProveedor()
        {
            txtProveedor.RemoveAllItem();
            //txtProveedorIngProducto.RemoveAllItem();
            DataBase db = new DataBase();
            String sql = "select nombre from proveedor";
            SQLiteDataReader dr = db.EjecutarSql(sql);

            while (dr.Read())
            {
                String nombre = Convert.ToString(dr["nombre"]);

                String[] sugerencias = nombre.Split(' ');

                foreach (var text in sugerencias)
                {
                    txtProveedor.AddItem(new AutoCompleteEntrada(nombre, text));
                    //txtProveedorIngProducto.AddItem(new AutoCompleteEntrada(nombre, text));

                }


            }
            dr.Close();
            db.CerrarCon();

        }

        private void cargarTxtClientes()
        {
            txtSalidaCliente.RemoveAllItem();
            DataBase db = new DataBase();
            String sql = "select nombre from clientes";
            SQLiteDataReader dr = db.EjecutarSql(sql);

            while (dr.Read())
            {
                String nombre = Convert.ToString(dr["nombre"]);

                String[] sugerencias = nombre.Split(' ');

                foreach (var text in sugerencias)
                {
                    txtSalidaCliente.AddItem(new AutoCompleteEntrada(nombre, text));
                    //txtProveedorIngProducto.AddItem(new AutoCompleteEntrada(nombre, text));

                }


            }
            dr.Close();
            db.CerrarCon();
        }

        private void cargartxtBusquedaReporte()
        {
            txtBusquedaReporte.RemoveAllItem();
            DataBase db = new DataBase();
            String sql = "select nombre from clientes";
            SQLiteDataReader dr = db.EjecutarSql(sql);

            while (dr.Read())
            {
                String nombre = Convert.ToString(dr["nombre"]);

                String[] sugerencias = nombre.Split(' ');

                foreach (var text in sugerencias)
                {
                    txtBusquedaReporte.AddItem(new AutoCompleteEntrada(nombre, text));
                    //txtProveedorIngProducto.AddItem(new AutoCompleteEntrada(nombre, text));

                }


            }
            db.CerrarCon();
            db = new DataBase();
            sql = "select nombre from proveedor";
            dr = db.EjecutarSql(sql);

            while (dr.Read())
            {
                String nombre = Convert.ToString(dr["nombre"]);

                String[] sugerencias = nombre.Split(' ');

                foreach (var text in sugerencias)
                {
                    txtBusquedaReporte.AddItem(new AutoCompleteEntrada(nombre, text));
                    //txtProveedorIngProducto.AddItem(new AutoCompleteEntrada(nombre, text));

                }
            }
            db.CerrarCon();
            db = new DataBase();
            sql = $"select {ValuesDB.productoNombreDB} from {ValuesDB.tablaProducto}";
            dr = db.EjecutarSql(sql);
            while (dr.Read())
            {
                String nombre = Convert.ToString(dr["nombre"]);
                String[] sugerencias = nombre.Split(' ');

                foreach (var text in sugerencias)
                {
                    txtBusquedaReporte.AddItem(new AutoCompleteEntrada(nombre, text));
                }

            }
            dr.Close();
            db.CerrarCon();

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void btnIngresos_MouseHover(Object sender, EventArgs e)
        {

            MessageBox.Show("You are in the ToolStripItem.MouseHover event.");

        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnIngresoProveedor_Click(object sender, RoutedEventArgs e)
        {

            
            this.Cursor = Cursors.Wait;

            String id = txtNitProveedor.Text.Trim();
            String nombre = txtNombreProveedor.Text.Trim();
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(nombre))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageCamposErroneos);
            }
            else
            {
                IngresoProveedor(id, nombre);
                this.Cursor = Cursors.Arrow;
            }
            //this.Cursor = Cursors.Arrow;

        }

        private void IngresoProveedor(String id, String nombre)
        {
            this.Cursor = Cursors.Wait;
            DataBase db = new DataBase();

            String tabla = ValuesDB.tablaProveedor;
            String campoBusqueda = ValuesDB.proveedorIdDB;
            String campoResultado = ValuesDB.proveedorNombreDB;

            String valorExistente = ObtenerCampo(id, tabla, campoBusqueda, campoResultado);

            if (valorExistente != null)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show($"{StringResources.MessageIdProveedorExist} {valorExistente}");
                return;
            }

            String sql = $"insert into proveedor values('{id}','{nombre}')";

            if (db.InsertarSQL(sql))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageInsercionExitosa);
                txtNitProveedor.Text = "";
                txtNombreProveedor.Text = "";
                cargartxtProveedor();
                cargartxtBusquedaReporte();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageErrorEnInsercion);
            }
        }

        private void btnIngresoCliente_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            String id = txtidCliente.Text.Trim();
            String nombre = txtNombrecliente.Text.Trim();
            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(nombre))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageCamposErroneos);
            }
            else
            {

                DataBase db = new DataBase();

                String tabla = ValuesDB.tablaClientes;
                String campoBusqueda = ValuesDB.clientesIdDB;
                String campoResultado = ValuesDB.clientesNombreDB;

                String valorExistente = ObtenerCampo(id, tabla, campoBusqueda, campoResultado);

                if (valorExistente != null)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show($"{StringResources.MessageIdClienteExist} {valorExistente}");
                    return;
                }

                String sql = $"insert into clientes values('{id}', '{nombre}')";
                if (db.InsertarSQL(sql))
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show(StringResources.MessageInsercionExitosa);
                    txtidCliente.Text = "";
                    txtNombrecliente.Text = "";
                    cargarTxtClientes();
                    cargartxtBusquedaReporte();
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show(StringResources.MessageErrorEnInsercion);
                }
            }
        }

        private void btnIngresoCategoria_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            String nombre = txtNombreCategoria.Text.Trim();
            if (String.IsNullOrEmpty(nombre))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageCamposErroneos);
            }
            else
            {
                DataBase db = new DataBase();

                String tabla = ValuesDB.tablaCategoria;
                String campoBusqueda = ValuesDB.categoriNombreDB;
                String campoResultado = ValuesDB.categoriNombreDB;
                String valorExistente = ObtenerCampo(nombre, tabla, campoBusqueda, campoResultado);

                if (valorExistente != null)
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show($"{StringResources.MessageNombreCategoriaExist} {valorExistente}");
                    return;
                }

                String sql = $"insert into categoria (nombre) values('{nombre}')";
                if (db.InsertarSQL(sql))
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show(StringResources.MessageInsercionExitosa);
                    txtNombreCategoria.Text = "";
                    cargarcmbIngCategoria();
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show(StringResources.MessageErrorEnInsercion);
                }
            }
        }


        private void btnIngresoProducto_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            String categoria = cmbIngCategoria.Text.Trim();
            String codProducto = txtCodIngProducto.Text.Trim();
            String producto = txtNombreProducto.Text.Trim();
            //String proveedor = txtProveedorIngProducto.Text.Trim();
            String vlrUnitario = txtVlrUnitarioProducto.Text.Trim();
            String unidad = txtUnidadIngProducto.Text.Trim();
            String imagen = txtRutaImgIngProducto.Text.Trim();

            String tabla = ValuesDB.tablaProducto;
            String camBusq = ValuesDB.ProductoCodigoDB;

            if (ObtenerCampo(codProducto, tabla, camBusq, camBusq) != null)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageCodProductoExist);
                return;
            }

            tabla = ValuesDB.tablaProveedor;
            camBusq = ValuesDB.proveedorNombreDB;
            String campoReturn = ValuesDB.proveedorIdDB;


            tabla = ValuesDB.tablaCategoria;
            camBusq = ValuesDB.categoriNombreDB;
            campoReturn = ValuesDB.categoriaCodigoDB;
            categoria = ObtenerCampo(categoria, tabla, camBusq, campoReturn);
            if (categoria == null)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageCategoriaNotExist);
                return;
            }



            if (String.IsNullOrEmpty(codProducto) || String.IsNullOrEmpty(producto)
                || String.IsNullOrEmpty(unidad))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageCamposErroneos);
                return;
            }

            DataBase db = new DataBase();
            String sql = $"insert into {ValuesDB.tablaProducto} " +
                $"values({codProducto},  {categoria}, '{producto}', '{unidad}', {vlrUnitario}); ";

            String sqlStock = $"insert into {ValuesDB.tablaStock} values('{codProducto}', '0'); ";

            String insercion = sql + sqlStock;

            String RutaImagen = "";

            var s = Directory.GetCurrentDirectory();
            imgIngresoProducto.Source = new BitmapImage(new Uri(s + "..\\..\\..\\\\resources\\imagenes\\imagenSmall.png"));
            if (imagen != "")
            {
                if (File.Exists(imagen))
                {
                    // var s = Directory.GetCurrentDirectory();
                    RutaImagen = s + $"..\\..\\..\\\\resources\\imagenes\\{codProducto}";
                    if (File.Exists(RutaImagen))
                    {
                        this.Cursor = Cursors.Arrow;
                        MessageBox.Show("ya existe este codigo de producto", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);

                        return;
                    }
                    File.Copy(imagen, RutaImagen);
                    String sqlImg = $"insert into media values({codProducto}, '{RutaImagen}'); ";

                    insercion += sqlImg;

                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show("Nose encontro el archivo", "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            

            if (db.InsertarTransaacionSQL(insercion))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageInsercionExitosa);
                cmbIngCategoria.SelectedIndex = 0;
                txtCodIngProducto.Text = "";
                txtNombreProducto.Text = "";
                //txtProveedorIngProducto.Text = "";
                txtVlrUnitarioProducto.Text = "";
                txtUnidadIngProducto.Text = "";
                txtRutaImgIngProducto.Text = "";
                cargartxtProductos();
                cargartxtBusquedaReporte();
            }
            else
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageErrorEnInsercion);
            }
            db.CerrarCon();


        }

        private String ObtenerCampo(String condicion, String tabla, String campoBusqueda, String campoResultado)
        {
            String campo = null;
            String sql = $"select * from {tabla} where {campoBusqueda} = '{condicion}'";
            DataBase db = new DataBase();
            SQLiteDataReader dr = db.EjecutarSql(sql);
            while (dr.Read())
            {
                campo = Convert.ToString(dr[$"{campoResultado}"]);

            }
            if (!dr.IsClosed)
            {

                dr.Close();
            }
            db.CerrarCon();

            return campo;
        }

        private void btnIngImagenProducto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "imagenes | *.jpg; *.jpeg; *.png";
            dialog.Title = "Seleccione una Imagen";

            //Nullable<bool> res = dialog.ShowDialog();
            var resultimg = dialog.ShowDialog();
            if (resultimg == true)
            {

                //imgIngresoProducto.Source = new BitmapImage(new Uri(System.Environment.CurrentDirectory + "/linea.jpg"));
                imgIngresoProducto.Source = new BitmapImage(new Uri(dialog.FileName));
                txtRutaImgIngProducto.Text = dialog.FileName;

            }

        }

        private void numerosTextBox_keyDown(object sender, KeyEventArgs e)
        {

            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private String ObtenerUsuarioActual()
        {
            String id = "111777";
            return id;
        }

        private void RegistroIngresos(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            String producto = txtProducto.Text.Trim();
            String proveedor = txtProveedor.Text.Trim();
            String cantidad = txtCantidad.Text.Trim();

            String tabla = ValuesDB.tablaProducto;
            String camBusq = ValuesDB.productoNombreDB;
            String codigoObtener = ValuesDB.ProductoCodigoDB;

            String codigoP = ObtenerCampo(producto, tabla, camBusq, codigoObtener);
            if (codigoP == null)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageProductoNotExist);
                return;
            }

            tabla = ValuesDB.tablaProveedor;
            camBusq = ValuesDB.proveedorNombreDB;
            codigoObtener = ValuesDB.proveedorIdDB;

            String codigoProvee = ObtenerCampo(proveedor, tabla, camBusq, codigoObtener);
            if (codigoProvee == null)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageProveedorNotExist);
                return;
            }

            tabla = ValuesDB.tablaStock;
            int cant = 0;
            String cantidadExistente = ObtenerCampo(codigoP, tabla, ValuesDB.stockProductoDB, ValuesDB.stockCantidadDB);
            int cantidadTotal = 0;
            if (!String.IsNullOrEmpty(cantidad))
            {
                try
                {
                    cantidadTotal = Int32.Parse(cantidadExistente);
                    cant = Int32.Parse(cantidad);

                    cantidadTotal += cant;
                    //MessageBox.Show(Convert.ToString(cantidadTotal)+" "+codigoProvee );
                }
                catch
                {
                    this.Cursor = Cursors.Arrow;
                    MessageBox.Show($"{StringResources.MessageCantidadNoValida}");
                    return;
                }
            }

            String user = ObtenerUsuarioActual();


            DataBase db = new DataBase();

            String fecha = DateTime.Today.ToString("d");

            String sql = $"insert into {ValuesDB.tablaingresos} ({ValuesDB.ingresosProducto}, {ValuesDB.ingresosUser}, " +
                $"{ValuesDB.ingresosCantidad}, {ValuesDB.ingresosFecha}, {ValuesDB.ingresoProveedor}) values('{codigoP}', '{user}', {cant}, '{fecha}', '{codigoProvee}');";
            //MessageBox.Show(sql);
            String sql1 = $"UPDATE {ValuesDB.tablaStock} SET {ValuesDB.stockCantidadDB} = '{cantidadTotal}' WHERE {ValuesDB.stockProductoDB} = {codigoP};";

            String insercion = sql + sql1;

            if (db.InsertarTransaacionSQL(insercion))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageInsercionExitosa);
                txtProducto.Text = "";
                txtProveedor.Text = "";
                txtCantidad.Text = "";
                cargarIngresosDataGrid();
            }
            else
            {
                db.CerrarCon();
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageErrorEnInsercion);
            }

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            // ... Create a List of objects.
            /*var items = new List<Movimiento>();
            items.Add(new Movimiento("id", 12, "fecha", "producto", "usuario"));
            items.Add(new Movimiento("id1", 13, "fecha1", "producto1", "usuario1"));
            items.Add(new Movimiento("id2", 14, "fecha2", "producto2", "usuario2"));

            // ... Assign ItemsSource of DataGrid.
            var grid = sender as DataGrid;
            grid.ItemsSource = items;*/

        }

        private void RegistroSalidas(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            String producto = txtSalidaProducto.Text.Trim();
            String cantidad = txtSalidaCantidad.Text.Trim();
            String cliente = txtSalidaCliente.Text.Trim();

            String tabla = ValuesDB.tablaProducto;
            String campoBusqueda = ValuesDB.productoNombreDB;
            String campoResultado = ValuesDB.ProductoCodigoDB;
            String codProducto = ObtenerCampo(producto, tabla, campoBusqueda, campoResultado);

            tabla = ValuesDB.tablaClientes;
            campoBusqueda = ValuesDB.clientesNombreDB;
            campoResultado = ValuesDB.clientesIdDB;
            String codCliente = ObtenerCampo(cliente, tabla, campoBusqueda, campoResultado);
            int cant = 0;

            if (codCliente == null || codProducto == null)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("Verifique Datos ingresados");
                return;
            }
            try
            {
                cant = Int32.Parse(cantidad);
            }
            catch
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show($"{StringResources.MessageCantidadNoValida}");
                return;
            }

            tabla = ValuesDB.tablaStock;
            campoBusqueda = ValuesDB.stockProductoDB;
            campoResultado = ValuesDB.stockCantidadDB;
            String cantidadStock = ObtenerCampo(codProducto, tabla, campoBusqueda, campoResultado);
            int cantidadResultante = Int32.Parse(cantidadStock);
            if (cantidadResultante < cant)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageNohayCantidadSuficiente);
                return;
            }
            else
            {
                cantidadResultante -= cant;
            }
            String fecha = DateTime.Today.ToString("d");
            String usuario = ObtenerUsuarioActual();
            Salidas sale = new Salidas(codCliente, cant, fecha, codProducto, usuario, "salida", codCliente);


            String sql = $"" +
                $"" +
                $"insert into {ValuesDB.tablaSalidas}({ValuesDB.salidasClienteDB}, {ValuesDB.salidasProductoDB}," +
                $" {ValuesDB.salidasUsuarioDB}, {ValuesDB.salidasCantidadDB}, {ValuesDB.salidasFechaDB})" +
                $" values('{sale.UserFinal}', '{sale.Producto}'," +
                $" '{sale.Usuario}', '{sale.Cantidad}', '{sale.Fecha}');" +
                $"";

            String sql1 = $"UPDATE {ValuesDB.tablaStock} SET {ValuesDB.stockCantidadDB} = {cantidadResultante} " +
                $"WHERE {ValuesDB.stockProductoDB} = {codProducto};" +
                $"";

            DataBase db = new DataBase();

            String insercion = sql + sql1;

            if (db.InsertarTransaacionSQL(insercion))
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageInsercionExitosa);
                txtSalidaCantidad.Text = "";
                txtSalidaCliente.Text = "";
                txtSalidaProducto.Text = "";


            }
            else
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(StringResources.MessageErrorEnInsercion);
            }

        }

        private List<Ingresos> IngresosDeHoy()
        {

            String sql = $"SELECT * FROM {ValuesDB.tablaingresos} WHERE {ValuesDB.ingresosFecha} = '{DateTime.Today.ToString("d")}';";
            //String sql = $"SELECT * FROM {ValuesDB.tablaingresos};";
            
            DataBase db = new DataBase();
            SQLiteDataReader dr = db.EjecutarSql(sql);
            List<Ingresos> ingresos = new List<Ingresos>();
            while (dr.Read())
            {
                String proveedor = Convert.ToString(dr[$"{ValuesDB.ingresoProveedor}"]);
                String id = Convert.ToString(dr[$"{ValuesDB.ingresosId}"]);
                int cantidad = Convert.ToInt32(dr[$"{ValuesDB.ingresosCantidad}"]);
                // DateTime fech = Convert.ToDateTime(dr["fecha"]);
                String fecha = Convert.ToString(dr[$"{ValuesDB.ingresosFecha}"]);
                String producto = Convert.ToString(dr[$"{ValuesDB.ingresosProducto}"]);
                String usuario = Convert.ToString(dr[$"{ValuesDB.ingresosUser}"]);
                String tipo = "ingreso";
                String userFinal = Convert.ToString(dr[$"{ValuesDB.ingresoProveedor}"]);
                
                Ingresos ing = new Ingresos(proveedor, id, cantidad, fecha, producto, usuario, tipo, userFinal);
                //MessageBox.Show(Convert.ToString(fecha));
               // Console.WriteLine(dr[5]);
                ingresos.Add(ing);
            }

            //Movimiento mov = new Movimiento("1231", 12, "05/08/2018", "cemento", "usuario", "ingreso", "Argos");
            //datosGrid.Items.Add(mov);
            return ingresos;

        }

        private void cargarIngresosDataGrid()
        {
            this.Cursor = Cursors.Wait;
            datosGrid.Items.Clear();
            List<Ingresos> lista = IngresosDeHoy();
            //datosGrid.Items.Add(lista);
            foreach (Ingresos obj in lista)
            {
                //MessageBox.Show("aa");
                datosGrid.Items.Add(obj);
            }
            this.Cursor = Cursors.Arrow;

        }

        private void GenerarReporte(Object sender, RoutedEventArgs e)
        {
            Boolean ingresos = false;
            Boolean salidas = false;
            String busqueda = txtBusquedaReporte.Text.Trim();
            if (String.IsNullOrEmpty(busqueda))
            {
                //busqueda de todos los articulos
                if (checkIngreso.IsChecked.Value) ingresos = true;
                if (checkSalida.IsChecked.Value) salidas = true;
                Console.WriteLine(ingresos);
                MessageBox.Show("veo veo");
            }
            else
            {
                //Thread t = new Thread(() => generarReporteExcel(busqueda));// metodo con lambda "funciones anonimas"

                //con delegate pasar parametros al thread
                /*Thread t = new Thread(delegate(){
                    generarReporteExcel(busqueda);
                });
                t.Start();*/

                //usar el hilo con clase y pasar parametros
                ManejoExcel mExcel = new ManejoExcel(busqueda);
                Thread t = new Thread(new ThreadStart(mExcel.GenerarReporte));
                t.Start();

                //t.IsBackground = true;
                MessageBox.Show("se generara el reporte, púede seguir trabajando mientras se genera");
            }

            //t.IsBackground = true; // cambia el hilo a un proceso en segundo plano, lo q implica q al cerrar la app se termina
            //el proceso si no es asi el hilo se sequira ejecutando asi se cierre la aplicacion Control foreground and background threads 
            
            //t.Suspend();//suspende el hilo funcion obsoleta
            //t.Resume();//reaunda hilo solo si este ya ha sido suspendido antes funcion obsoleta en lugar de usar estas funciones usar  AutoResetEvent and EventWaitHandle

        }
        private void generarReporteExcel(String busqueda)
        {
            Thread.Sleep(10000);
            MessageBox.Show("se termino de ejecutar el hilo "+ busqueda);
        }
        

        

    }
}