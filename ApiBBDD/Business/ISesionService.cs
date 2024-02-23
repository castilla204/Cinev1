using ApiPeliculas.Modelos;
namespace ApiPeliculas.Business.Services{
public interface ISesionService{
    
public List<SesionDTO> ObtenerSesiones();

public Sesion ObtenerSesion(int id);
}}