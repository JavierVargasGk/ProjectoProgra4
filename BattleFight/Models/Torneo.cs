namespace BattleFight.Models
{
    public class Torneo
    {
        private int id;
        private DateTime fechaTorneo;
        private double premio;
        private string categoria;

        public int Id { get => id; set => id = value; }
        public DateTime FechaTorneo { get => fechaTorneo; set => fechaTorneo = DateTime.Now; }
        public double Premio { get => premio; set => premio = value; }
        public string Categoria { get => categoria; set => categoria = value; }

        public Torneo(int idTorneo, DateTime fechaTorneo, double premio, string categoria)
        {
            this.id = idTorneo;
            this.fechaTorneo = fechaTorneo;
            this.premio = premio;
            this.categoria = categoria;
        }

        public Torneo()
        {
            this.id = 0;
            this.premio = 0;
            this.categoria = "";
        }
    }
}
