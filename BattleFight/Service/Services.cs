using BattleFight.Models;
using System.Data.Entity;

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

            public void agregarEquipo(Equipo equipo, string jugador1, string jugador2, string jugador3, string jugador4)
            {
                equipo.AgregarJugador(equipo, jugador1);
                equipo.AgregarJugador(equipo, jugador2);
                equipo.AgregarJugador(equipo, jugador3);
                equipo.AgregarJugador(equipo, jugador4);
                equipo.Codigo = equipo.generarCodigoEquipo(equipo.Categoria, equipo.Jugadores);
                equipos.Add(equipo);
                SaveChanges();
            }
            public List<Equipo> mostrarEquipos()
            {
                return equipos.ToList();
            }

            public  Equipo buscarEquiposCat(string categoria)
            {
                var equipoBuscado = equipos.FirstOrDefault(x => x.Categoria == categoria);
                if (equipoBuscado != null)
                    return equipoBuscado;
                else throw new Exception("Categoria de equipo no registrada");
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

            public void actualizarEquipo(Equipo equipoActualizado, string jugador1,string jugador2, string jugador3, string jugador4)
            {
                var equipoAntiguo = equipos.FirstOrDefault(x => x.Id == equipoActualizado.Id);
                if (equipoAntiguo != null)
                {
                    equipoAntiguo.NombreEquipo = equipoActualizado.NombreEquipo;
                    equipoAntiguo.Categoria = equipoActualizado.Categoria;
                    equipoAntiguo.Puntuaje = equipoActualizado.Puntuaje;
                    if (!equipoAntiguo.Jugadores.Contains(jugador1))
                    {
                        equipoAntiguo.Jugadores.RemoveAt(0);
                        equipoAntiguo.Jugadores.Add(jugador1);
                    }
                    if (!equipoAntiguo.Jugadores.Contains(jugador2))
                    {
                        equipoAntiguo.Jugadores.RemoveAt(1);
                        equipoAntiguo.Jugadores.Add(jugador2);
                    }
                    if (!equipoAntiguo.Jugadores.Contains(jugador3))
                    {
                        equipoAntiguo.Jugadores.RemoveAt(2);
                        equipoAntiguo.Jugadores.Add(jugador3);
                    }
                    if (!equipoAntiguo.Jugadores.Contains(jugador4))
                    {
                        equipoAntiguo.Jugadores.RemoveAt(4);
                        equipoAntiguo.Jugadores.Add(jugador4);
                    }
                    equipoAntiguo.Codigo = equipoActualizado.generarCodigoEquipo(equipoActualizado.Categoria, equipoActualizado.Jugadores);
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

            public int cantidadEquipo(Equipo equipo)
            {
                return equipo.Jugadores.Count();
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

            
            

            #endregion
            
        }
    }

