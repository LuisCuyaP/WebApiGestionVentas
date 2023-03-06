namespace WebApi.Dtos
{
    public class ProveedorUpdateDto
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string ContactoUno { get; set; }
        public string ContactoDos { get; set; }
        public string Observacion { get; set; }        
    }
}
