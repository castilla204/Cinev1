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
public List<Sesion> ObtenerSesiones(){
return _context.Sesiones.ToList();
    
}

public Sesion ObtenerSesion(int id){
       return _context.Sesiones.Find(id);
}


}}