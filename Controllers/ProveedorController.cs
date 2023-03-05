using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{  
    public class ProveedorController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ProveedorController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("proveedores")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetProveedores()
        {           
            var proveedores = await uow.ProveedorRepository.GetProveedoresAsync();
            var proveedoresDto = mapper.Map<IEnumerable<ProveedorListDto>>(proveedores);
            return Ok(proveedoresDto);            
        }

        //Post--> api/proveedor/post --Post the data in JSON Format
        [HttpPost("post")]
        public async Task<IActionResult> AddProveedor(ProveedorAddDto proveedorAddDto)
        {   
            var proveedor = mapper.Map<Proveedor>(proveedorAddDto);
            proveedor.LastUpdatedOn = DateTime.Now;
            proveedor.LastUpdatedBy = 1;      

            uow.ProveedorRepository.AddProveedor(proveedor);
            await uow.SaveAsync();
            return StatusCode(201);
        }
    }
}
