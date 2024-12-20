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
        private string aliasJugador1;
        private string aliasJugador2;
        private string aliasJugador3;
        private string aliasJugador4;
        private int cantidadJugador;
        private string categoria;

        public Equipo(int id, string nombreEquipo, int puntuaje,string aliasJugador1, string aliasJugador2, string aliasJugador3, string aliasJugador4 , int cantidadJugador,string categoria, string codigo)
        {
            this.id = id;
            this.nombreEquipo = nombreEquipo;
            this.puntuaje = puntuaje;
            this.aliasJugador1 = aliasJugador1;
            this.aliasJugador2 = aliasJugador2;
            this.aliasJugador3 = aliasJugador3;
            this.aliasJugador4 = aliasJugador4;
            this.cantidadJugador = cantidadJugador;
            this.categoria = categoria;
            this.codigo = codigo;
        }

        public Equipo()
        {
            this.id = 0;
            this.codigo = "";
            this.nombreEquipo = "";
            this.puntuaje = 0;
            this.aliasJugador1 = "";
            this.aliasJugador2 = "";
            this.aliasJugador3 = "";
            this.aliasJugador4 = "";
            this.cantidadJugador = 0;
            this.categoria = "";
        }

        public int Id { get => id; set => id = value; }
        public string NombreEquipo { get => nombreEquipo; set => nombreEquipo = value; }
        public int Puntuaje { get => puntuaje; set => puntuaje = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string AliasJugador1 { get => aliasJugador1; set => aliasJugador1 = value; }
        public string AliasJugador2 { get => aliasJugador2; set => aliasJugador2 = value ; }
        public string AliasJugador3 { get => aliasJugador3; set => aliasJugador3 = value; }
        public string AliasJugador4 {get => aliasJugador4; set => aliasJugador4 = value; }
        public int CantidadJugador { get => cantidadJugador; set => cantidadJugador = value; }


        public string generarCodigoEquipo(Equipo equipo) 
        {
            Random random = new Random();
            string codigoEquipo = "";
            char letraCategoria = equipo.categoria.ToUpper()[0];
            codigoEquipo += letraCategoria;
            if (!string.IsNullOrEmpty(AliasJugador1)) cantidadJugador++;
            if (!string.IsNullOrEmpty(AliasJugador2)) cantidadJugador++;
            if (!string.IsNullOrEmpty(AliasJugador3)) cantidadJugador++;
            if (!string.IsNullOrEmpty(AliasJugador4)) cantidadJugador++;
            codigoEquipo += cantidadJugador;
            codigoEquipo += random.Next(10,99);
            string anno = DateTime.Now.Year.ToString().Substring(2,2);
            codigoEquipo += anno;
            return codigoEquipo;
        }
        
    }
}
