namespace Jefferson_Guasumba.Models
{
    public class Tarea
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }


        public DateTime FechaCreacion { get; set; }


        public DateTime FechaVencimiento { get; set; }


        public int Completada { get; set; }




    }
}