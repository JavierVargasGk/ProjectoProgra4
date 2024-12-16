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

            public void agregarEquipo(Equipo equipo)
            {
                equipos.Add(equipo);
                SaveChanges();
            }
            public List<Equipo> mostrarEquipos()
            {
                return    equipos.ToList();
            }

            public  Equipo buscarEquipos(int id)
            {
                var equipoBuscado = equipos.FirstOrDefault(x => x.Id == id);
                if (equipoBuscado != null)
                    return equipoBuscado;
                else throw new Exception("Usuario no registrado");
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
                    equipoAntiguo.Jugadores = equipoActualizado.Jugadores;
                    equipoAntiguo.Codigo = equipoActualizado.generarCodigoEquipo(equipoActualizado.Categoria, equipoActualizado.Jugadores);
                    SaveChanges();
                }
                else throw new Exception("Equipo no existente");
            }

            public List<Equipo> filtroEquipos()
            {
                return equipos.ToList();
            }

            public List<Equipo> filtroUsuarios(string CategoriaBuscada)
            {
                var equiposFiltrados = equipos.Where(x => x.CategoriaBuscada == CategoriaBuscada).ToList();
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

