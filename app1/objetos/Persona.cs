
namespace app1.objetos
{
    class Persona
    {
        private string id;
        private string nombre;
        private string apellido;
        private string telefono;

        //cliente and proveedor
        private string numeroCuenta;
        private string banco;

        public string Id { get => id;
            set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }
        public string Banco { get => banco; set => banco = value; }

        public Persona(string id, string nombre, string apellido, string telefono, string numeroCuenta, string banco)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.NumeroCuenta = numeroCuenta;
            this.Banco = banco;
        }
        public Persona(string id, string nombre, string apellido, string telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
        }
        public Persona()
        {
            this.Id = "";
            this.Nombre = "";
            this.Apellido = "";
            this.Telefono = "";
        }


    }
}
