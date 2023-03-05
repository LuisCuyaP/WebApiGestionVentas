namespace WebApi.Dtos
{
    public class ProveedorListDto
    {
        public int Id { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public DateTime EstPossessionOn { get; set; }
    }
}
