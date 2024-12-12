namespace BattleFight.Models
{
    public class Equipo
    {
        private List<int> cantidadJugadores;
        private string id;
        private string nombreEquipo;
        private int puntuaje;
        private string jugadores;
        private string categoria;

        public Equipo(string id, string nombreEquipo, int puntuaje, string jugadores, string categoria)
        {
            this.id = id;
            this.nombreEquipo = nombreEquipo;
            this.puntuaje = puntuaje;
            this.jugadores = jugadores;
            this.categoria = categoria;
        }

        public Equipo()
        {
            this.id = "";
            this.nombreEquipo = "";
            this.puntuaje = 0;
            this.jugadores = "";
            this.categoria = "";
        }

        public string Id { get => id; set => id = value; }
        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }
        public int Puntuaje { get => puntuaje; set => puntuaje = value; }
        public string Jugadores { get => jugadores; set => jugadores = value; }
        public string Categoria { get => categoria; set => categoria = value; }

        public string generarCodigoEquipo(string Categoria, string Jugadores)
        {



            string anno = DateTime.Now.Year.ToString().Substring(2, 2);

            char letraCategoria = categoria.ToUpper()[0];

            Random random = new Random();

            int numerosAleatorios = random.Next(10, 99);

            string codigoEquipo = $"{letraCategoria}{}{numerosAleatorios}";

            return codigoEquipo;
        }
    }
}
