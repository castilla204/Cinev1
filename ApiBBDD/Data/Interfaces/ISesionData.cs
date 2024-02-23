using ApiPeliculas.Modelos;
public interface ISesionData{
public List<SesionDTO> ObtenerSesionesDTO();
public Sesion ObtenerSesion(int id);
}