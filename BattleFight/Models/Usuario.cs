namespace BattleFight.Models
{
    public class Usuario
    {

        private int iduser;
        private int cedula;
        private string nombre;
        private string alias;
        private string genero;
        private DateTime fechaDeRegistro;
        private string estado;
        private string contrasenna;
        private string confirmarContrasenna;

        public int Id { get => id; set => id = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Genero { get => genero; set => genero = value; }
        public DateTime FechaDeRegistro { get => fechaDeRegistro; set => fechaDeRegistro = DateTime.Now; }
        public string Estado { get => estado; set => estado = value; }
        public string Contrasenna { get => contrasenna; set => contrasenna = value; }
        public string Alias { get => alias; set => alias = value; }
        public string ConfirmarContrasenna { get => confirmarContrasenna; set => confirmarContrasenna = value; }

        public Usuario(string confirmarContrasenna, int id, int cedula, string nombre,string alias, string genero, DateTime fechaDeRegistro, string estado, string contrasenna)
        {
            this.id = id;
            this.cedula = cedula;
            this.nombre = nombre;
            this.genero = genero;
            this.fechaDeRegistro = fechaDeRegistro;
            this.estado = estado;
            this.contrasenna = contrasenna;
            this.alias = alias;
            this.confirmarContrasenna = confirmarContrasenna;   
        }

        public Usuario()
        {
            this.id = 0;
            this.cedula = 0;
            this.nombre = "";
            this.genero = "";
            this.estado = "";
            this.contrasenna = "";
            this.alias = "";
            this.confirmarContrasenna = "";
        }
    }
}
