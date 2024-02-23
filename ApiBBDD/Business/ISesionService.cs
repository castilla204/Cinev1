using ApiPeliculas.Modelos;
namespace ApiPeliculas.Business.Services{
public interface ISesionService{
    
public List<SesionDTO> ObtenerSesiones();

public SesionDTO ObtenerSesion(int id);
public void CrearSesion(SesionCrearDTO sesionDTO);
}}