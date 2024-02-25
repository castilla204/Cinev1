using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace ApiPeliculas.Data{
    public class UsuarioData: IUsuarioData{
        private readonly PeliculaContext _context;

        public UsuarioData(PeliculaContext context){
            _context=context;
        }

        public List<UsuarioDTO> ObtenerUsuarios(){
            var UsuariosDTO= _context.Usuarios
                .Include(u => u.Reservas)
                .Select(u => new UsuarioDTO{
                UsuarioID=u.UsuarioID,
                Nombre=u.Nombre,
                CorreoElectronico=u.CorreoElectronico,
                CantidadReservas=u.Reservas.Count
        }).ToList();

        return UsuariosDTO;
        }

      
    }
}