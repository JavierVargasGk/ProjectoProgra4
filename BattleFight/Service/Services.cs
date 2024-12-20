using BattleFight.Models;
using System.Data.Entity;
using System.Reflection.Emit;

namespace BattleFight.Service
{
   
        public class Services : DbContext
        {
            public DbSet<Usuario> usuarios { get; set; }

            public DbSet<Equipo> equipos { get; set; }

            public DbSet<Torneo> torneos { get; set; }

        public Services() : base("BattleFight") { }

            #region Metodos de Usuario

            public void agregarUsuario(Usuario usuario)
            {
                usuario.Estado = "ACTIVO";
                usuarios.Add(usuario);
                SaveChanges();
            }
            public List<Usuario> mostrarUsuario()
            {
                return usuarios.ToList();
            }

            public Usuario buscarUsuario(int id)
            {
                var usuarioBuscado = usuarios.FirstOrDefault(x => x.Id == id);
                if (usuarioBuscado != null)
                    return usuarioBuscado;
                else throw new Exception("Usuario no registrado");
            }
            public void eliminarUsuario(Usuario usuario)
            {
                usuarios.Remove(usuario);
                SaveChanges();
            }

            public void actualizarUsuario(Usuario usuarioActualizado)
            {
                var usuarioAntiguo = usuarios.FirstOrDefault(x => x.Id == usuarioActualizado.Id);
                if (usuarioAntiguo != null)
                {
                    usuarioAntiguo.Nombre = usuarioActualizado.Nombre;
                    usuarioAntiguo.Alias = usuarioActualizado.Alias;
                    usuarioAntiguo.Contrasenna = usuarioActualizado.Contrasenna;
                    usuarioAntiguo.Genero = usuarioActualizado.Genero;
                    usuarioAntiguo.Estado = usuarioActualizado.Estado;
                    SaveChanges();
                }
                else throw new Exception("Usuario no existente");
            }

            public Usuario validarLogin(string user, string pass)
            {
                var usuarioLogueado =
                    usuarios.FirstOrDefault(u => u.Alias == user && u.Contrasenna == pass && u.Estado == "Activo");

                if (usuarioLogueado == null){
                    throw new Exception("Datos de inicio incorrectos o estado inactivo");
                }
                return usuarioLogueado;
            }
            #endregion

            #region Metodos de Equipo

            public void agregarEquipo(Equipo equipo)
            {
                equipo.Codigo = equipo.generarCodigoEquipo(equipo);
                equipos.Add(equipo);
                SaveChanges();
            }
            public List<Equipo> mostrarEquipos()
            {
                return equipos.ToList();
            }
        public Equipo buscarEquiposId(int id)
        {
            var equipoBuscado = equipos.FirstOrDefault(x => x.Id == id);
            if (equipoBuscado != null)
                return equipoBuscado;
            else throw new Exception("Id de equipo no encontrada");
        }
        public void eliminarEquipo(Equipo equipo)
            {
                    equipos.Remove(equipo);
                SaveChanges();
            }

            public void actualizarEquipo(Equipo equipoActualizado)
            {
                var equipoAntiguo = equipos.FirstOrDefault(x => x.Id == equipoActualizado.Id);
                if (equipoAntiguo != null)
                {
                    equipoAntiguo.NombreEquipo = equipoActualizado.NombreEquipo;
                    equipoAntiguo.Categoria = equipoActualizado.Categoria;
                    equipoAntiguo.Puntuaje = equipoActualizado.Puntuaje;
                    equipoAntiguo.AliasJugador1 = equipoActualizado.AliasJugador1;
                    equipoAntiguo.AliasJugador2 = equipoActualizado.AliasJugador2;
                    equipoAntiguo.AliasJugador3 = equipoActualizado.AliasJugador3;
                    equipoAntiguo.AliasJugador4 = equipoActualizado.AliasJugador4;
                    equipoAntiguo.Codigo = equipoActualizado.generarCodigoEquipo(equipoActualizado);
                    SaveChanges();
                }
                else throw new Exception("Equipo no existente");
            }
            
            public List<Equipo> FiltroEquipos(string CategoriaBuscada)
            {
                var equiposFiltrados = equipos.Where(x => x.Categoria == CategoriaBuscada).ToList();
                if (equiposFiltrados != null)
                    return (List<Equipo>)equiposFiltrados;
                else throw new Exception("Equipos sin la categoria solicitada");
            }
            #endregion

            #region Metodos de Torneo

            public void agregarTorneo(Torneo torneo)
            {
                torneos.Add(torneo);
                SaveChanges();
            }
            public List<Torneo> mostrarTorneos()
            {
                return torneos.ToList();
            }

            public Torneo buscarTorneos(int id)
            {
                var torneoBuscado = torneos.FirstOrDefault(x => x.Id == id);

                if (torneoBuscado != null)

                    return torneoBuscado;

                else throw new Exception("Torneo no registrado");
            }
            public void eliminarTorneo(Torneo torneo)
            {
                torneos.Remove(torneo);
                SaveChanges();
            }
            public void AsignarGanador(Torneo torneo,  Equipo id1, Equipo id2)
        {
            var TorneoActualizar = torneos.FirstOrDefault(x => x.Id == torneo.Id);
            if(TorneoActualizar == null) { throw new Exception("Torneo no encontrado"); }
            if (id1.Puntuaje > id2.Puntuaje)
            {
                TorneoActualizar.Ganador = id1.NombreEquipo;
            }
            else
            {
                TorneoActualizar.Ganador = id2.NombreEquipo;
            }
            SaveChanges();
        }
            
            

            #endregion
            
        }
    }