using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace ApiPeliculas.Data{
public class SesionData: ISesionData{

private readonly PeliculaContext _context;
public SesionData(PeliculaContext context){

_context=context;

}

public List<SesionDTO> ObtenerSesionesDTO()
{
    var sesionesDTO = _context.Sesiones
        .Include(s => s.Pelicula)
        .Include(s => s.Sala).ThenInclude(sala => sala.Butacas)
        .Select(s => new SesionDTO
        {
            SesionID = s.SesionID,
            FechaHora = s.FechaHora,
            TituloPelicula = s.Pelicula.Titulo,
            NombreSala = s.Sala.NombreSala,
            ImagenPelicula= s.Pelicula.Imagen,
            ButacasOcupadasIds = s.Sala.Butacas
                                  .Where(b => b.Estado == EstadoButaca.Ocupada)
                                  .Select(b => b.ButacaID)
                                  .ToList()
        })
        .ToList();

    return sesionesDTO;
}
public Sesion ObtenerSesion(int id){
    var sesion= _context.Sesiones.
              Include(s => s.Pelicula)
              .Include(s => s.Sala)
              .Include(s => s.Reservas)
              .FirstOrDefault(s => s.SesionID == id );
      return sesion;
}


}}