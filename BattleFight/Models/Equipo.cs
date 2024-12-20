using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Text;
using System.IO.Pipes;

namespace BattleFight.Models
{
    public class Equipo
    {
        private int id;
        private string codigo;
        private string nombreEquipo;
        private int puntuaje;
        private string[] jugadores;
        private string categoria;

        public Equipo(int id, string nombreEquipo, int puntuaje, string[] jugadores, string categoria, string codigo)
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
            this.jugadores = new string[4];
            this.categoria = "";
        }

        public int Id { get => id; set => id = value; }
        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }
        public int Puntuaje { get => puntuaje; set => puntuaje = value; }
        public string[] Jugadores { get => jugadores; set => jugadores = value;}
        [NotMapped]
        public string setJugadoresJson
        {
            get => jugadores = JsonConvert.DeserializeObject<string[]>(jugadores);
            set => jugadores= JsonConvert.SerializeObject(value);
        }

        public string Categoria { get => categoria; set => categoria = value; }
        public string Codigo { get => codigo; set => codigo = value; }

        public string generarCodigoEquipo(string Categoria,string[] Jugadores) 
        {
            Random random = new Random();
            string codigoEquipo = "";
            char letraCategoria = categoria.ToUpper()[0];
            codigoEquipo += letraCategoria;
            if (jugadores.Length > 0)
            {
                codigoEquipo += jugadores.Length;
            }
            else { 
                codigoEquipo += 0;
            }
            codigoEquipo += random.Next(10,99);
            string anno = DateTime.Now.Year.ToString().Substring(2,2);
            codigoEquipo += anno;
            return codigoEquipo;
        }

        public void AgregarJugador(Equipo equipo,string jugador,int pos)
        {
            if (equipo == null)
            {
                return;
            }
            if (jugador == null)
            {
                return;
            }
            equipo.Jugadores[pos] = jugador;
        }
    }
}
