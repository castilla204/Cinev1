
namespace ApiPeliculas.Modelos{
public class Reserva
    {
        public int ReservaID { get; set; }

        // Claves foráneas
        public int SesionID { get; set; }
        public int ButacaID { get; set; }
        public int UsuarioID { get; set; }
        

        // Propiedades de navegación
        public virtual Sesion Sesion { get; set; }
        public virtual Butaca Butaca { get; set; }
        public virtual Usuario Usuario { get; set; }
    }}