using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Interfaces;
using WebApi.Models;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet("list")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetProveedores()
        {
            var proveedores = await uow.ProveedorRepository.GetProveedoresAsync();
            var proveedoresDto = mapper.Map<IEnumerable<ProveedorListDto>>(proveedores);
            return Ok(proveedoresDto);
        }

        //proveedor/detail/1
        [HttpGet("detail/{id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetProveedorDetail(int id)
        {
            var proveedor = await uow.ProveedorRepository.GetProveedorDetailAsync(id);
            var proveedorDto = mapper.Map<ProveedorDetailDto>(proveedor);
            return Ok(proveedorDto);
        }

        //Post--> add/proveedor/post --Post the data in JSON Format
        [HttpPost("add")]
        public async Task<IActionResult> AddProveedor(ProveedorAddDto proveedorAddDto)
        {
            var proveedor = mapper.Map<Proveedor>(proveedorAddDto);
            var userId = 1;
            proveedor.PostedBy = userId;
            proveedor.LastUpdatedBy = userId;
            uow.ProveedorRepository.AddProveedor(proveedor);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var proveedor = await uow.ProveedorRepository.GetProveedorByIdAsync(id);
            if (proveedor == null)
                return BadRequest("El proveedor no existe");

            uow.ProveedorRepository.DeleteProveedor(proveedor);
           
            if (await uow.SaveAsync()) return Ok();
            return BadRequest("Ocurrio un error al eliminar el proveedor");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProveedor(int id, ProveedorUpdateDto proveedorUpdateDto)
        {
            if (id != proveedorUpdateDto.Id)
                return BadRequest("La edicion no se encuentra lista");

            var proveedorFromDb = await uow.ProveedorRepository.GetProveedorByIdAsync(id);
            if (proveedorFromDb == null)
                return BadRequest("La edicion no se encuentra lista");

            proveedorFromDb.LastUpdatedOn = DateTime.Now;
            proveedorFromDb.LastUpdatedBy = 1;

            //proveedorFromDb.Ruc = proveedorDetailDto.Ruc;
            //proveedorFromDb.RazonSocial = proveedorDetailDto.RazonSocial;
            //proveedorFromDb.Email = proveedorDetailDto.Email;
            //proveedorFromDb.ContactoUno = proveedorDetailDto.Ruc;

            mapper.Map(proveedorUpdateDto, proveedorFromDb);
            if (await uow.SaveAsync()) return Ok();
            return BadRequest("Ocurrio un error al editar el proveedor");
        }

    }
}
