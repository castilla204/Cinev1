namespace ApiPeliculas.Business.Services{
using ApiPeliculas.Modelos;
public class UsuarioService: IUsuarioService{

private readonly IUsuarioData _usuarioData;

public UsuarioService (IUsuarioData usuarioData){
    _usuarioData=usuarioData;
}

public List<UsuarioDTO> ObtenerUsuarios(){
   return _usuarioData.ObtenerUsuarios();
        
}

public UsuarioDTO ObtenerUsuario(int id){
return _usuarioData.ObtenerUsuario(id);
}


public void CrearUsuario(UsuarioCrearDTO usuario){

}


}
}