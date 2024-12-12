using BattleFight.Models;
using System.Data.Entity;

namespace BattleFight.Service
{
    public class Services
    {
        public class Service : DbContext
        {
            public DbSet<Usuario> usuarios { get; set; }

            public DbSet<Equipo> equipos { get; set; }

            public DbSet<Torneo> torneos { get; set; }

            public Service() : base("BattleFight") { }

            #region Metodos de Usuario

            public void agregarUsuario(Usuario usuario)
            {
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
                    usuarioAntiguo.ConfirmarContrasenna = usuarioActualizado.ConfirmarContrasenna;
                    SaveChanges();
                }
                else throw new Exception("Usuario no existente");
            }

            #endregion

            #region Metodos de Equipo

            public void agregarUsuario(Usuario usuario)
            {
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
                    usuarioAntiguo.ConfirmarContrasenna = usuarioActualizado.ConfirmarContrasenna;
                    SaveChanges();
                }
                else throw new Exception("Usuario no existente");
            }

            public List<Equipo> cantidadJugadores(Equipo jugador)
            {
                return jugador.ToList();
            }

            #endregion

            #region Metodos de Torneo

            #endregion
        }
    }
}
