namespace BattleFight.Models
{
    public class Torneo
    {
        private int id;
        private DateTime fechaTorneo;
        private double premio;
        private string categoria;
        private string ganador;

        public int Id { get => id; set => id = value; }
        public DateTime FechaTorneo { get => fechaTorneo; set => fechaTorneo = DateTime.Now; }
        public double Premio { get => premio; set => premio = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Ganador { get => ganador; set => ganador = value; }



        public Torneo(int idTorneo, DateTime fechaTorneo, double premio, string categoria, string ganador)
        {
            this.id = idTorneo;
            this.fechaTorneo = DateTime.Now;
            this.premio = premio;
            this.categoria = categoria;
            this.ganador = ganador;
        }

        public Torneo()
        {
            this.id = 0;
            this.premio = 0;
            this.categoria = "";
            this.fechaTorneo = DateTime.Now;
            this.ganador = "";
        }
    }
}
