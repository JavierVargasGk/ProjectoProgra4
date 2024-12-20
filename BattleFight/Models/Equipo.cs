using System.IO.Pipes;

namespace BattleFight.Models
{
    public class Equipo
    {
        private int id;
        private string codigo;
        private string nombreEquipo;
        private int puntuaje;
        private List<String> jugadores;
        private string categoria;

        public Equipo(int id, string nombreEquipo, int puntuaje, List<String> jugadores, string categoria, string codigo)
        {
            this.id = id;
            this.nombreEquipo = nombreEquipo;
            this.puntuaje = puntuaje;
            this.jugadores = jugadores;
            this.categoria = categoria;
            this.codigo = codigo;
        }

        public Equipo()
        {
            this.id = 0;
            this.codigo = "";
            this.nombreEquipo = "";
            this.puntuaje = 0;
            this.jugadores = new List<String>();
            this.categoria = "";
        }

        public int Id { get => id; set => id = value; }
        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }
        public int Puntuaje { get => puntuaje; set => puntuaje = value; }
        public List<String> Jugadores { get => jugadores; set => jugadores = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Codigo { get => codigo; set => codigo = value; }

        public string generarCodigoEquipo(string Categoria,List<String>Jugadores) 
        {
            Random random = new Random();
            string codigoEquipo = "";
            char letraCategoria = categoria.ToUpper()[0];
            codigoEquipo += letraCategoria;
            if (jugadores.Count > 0)
            {
                codigoEquipo += jugadores.Count();
            }
            else { 
                codigoEquipo += 0;
            }
            codigoEquipo += random.Next(10,99);
            string anno = DateTime.Now.Year.ToString().Substring(2,2);
            codigoEquipo += anno;
            return codigoEquipo;
        }

        public void AgregarJugador(Equipo equipo,string jugador)
        {
            if (equipo == null)
            {
                return;
            }
            if (jugador == null)
            {
                return;
            }
            equipo.Jugadores.Add(jugador);
        }
    }
}
