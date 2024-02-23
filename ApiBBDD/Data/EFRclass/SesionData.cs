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
public SesionDTO ObtenerSesion(int id)
{
    var sesionDTO = _context.Sesiones
        .Where(s => s.SesionID == id) // Filtra por el ID de la sesion
        .Include(s => s.Pelicula)
        .Include(s => s.Sala)
        .ThenInclude(sala => sala.Butacas)
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
                                  .ToList() // Obtiene la lista de IDs de butacas ocupadas
        })
        .FirstOrDefault(); 

    return sesionDTO;
}

public void CrearSesion(SesionCrearDTO sesionDTO)
        {
       
                var nuevaSesion = new Sesion
                    {
                        FechaHora = sesionDTO.FechaHora,
                        PeliculaID = sesionDTO.PeliculaID,
                        SalaID = sesionDTO.SalaID
                    };

                _context.Sesiones.Add(nuevaSesion);
                _context.SaveChanges();
           
   
            }
}}