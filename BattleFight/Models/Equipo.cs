using System.IO.Pipes;

namespace BattleFight.Models
{
    public class Equipo
    {
        private int id;
        private string codigo;
        private string nombreEquipo;
        private int puntuaje;
        private List<int> jugadores;
        private string categoria;
        private string usuarioResp;

        public Equipo(int id, string nombreEquipo, int puntuaje, List<int> jugadores, string categoria, string usuarioResp)
        {
            this.id = id;
            this.nombreEquipo = nombreEquipo;
            this.puntuaje = puntuaje;
            this.jugadores = jugadores;
            this.categoria = categoria;
            this.UsuarioResp = usuarioResp;
        }

        public Equipo()
        {
            this.UsuarioResp = "";
            this.id = 0;
            this.codigo = "";
            this.nombreEquipo = "";
            this.puntuaje = 0;
            this.jugadores = new List<int>();
            this.categoria = "";
        }

        public int Id { get => id; set => id = value; }
        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }
        public int Puntuaje { get => puntuaje; set => puntuaje = value; }
        public List<int> Jugadores { get => jugadores; set => jugadores = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string UsuarioResp { get => usuarioResp; set => usuarioResp = value; }

        public string generarCodigoEquipo(string Categoria, string Jugadores)
        {
            string codigoEquipo = "";
            string anno = DateTime.Now.Year.ToString().Substring(2, 2);
            codigo += anno;
            char letraCategoria = categoria.ToUpper()[0];
            codigo += letraCategoria;
            codigo += jugadores.Count();
            Random random = new Random();
            codigo += random.Next(10, 99);
            return codigoEquipo;
        }
    }
}
