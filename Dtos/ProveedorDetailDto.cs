namespace WebApi.Dtos
{
    public class ProveedorDetailDto : ProveedorListDto
    {
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public string ContactoUno { get; set; }
        public string ContactoDos { get; set; }
        public string Observacion { get; set; }
        public DateTime EstPossessionOn { get; set; }
    }
}
