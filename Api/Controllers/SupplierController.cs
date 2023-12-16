using Api.Examples.SupplierExamples;
using Application.Common;
using Application.UseCases.Suppliers.Commands.SupplierCreate;
using Application.UseCases.Suppliers.Commands.SupplierDelete;
using Application.UseCases.Suppliers.Commands.SupplierUpdate;
using Application.UseCases.Suppliers.Dto;
using Application.UseCases.Suppliers.Queries.GetSupplierById;
using Application.UseCases.Suppliers.Queries.GetSuppliers;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SupplierController : ControllerBase
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Registra proveedores en la base de datos.
    /// </summary>
    /// <remarks>
    /// Para registrar proveedores necesita llenar todos los datos necesarios
    /// </remarks>
    /// <response code="200">Proveedor creado con exito.</response>
    /// <response code="409">Proveedor ya registrado</response>
    /// <response code="400">Validaciones no cumplidas.</response>
    [HttpPost]
    [Authorize]
    [SwaggerRequestExample(typeof(SupplierCreateCommand), typeof(SupplierCreateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status409Conflict, typeof(SupplierCreateCommandNitDuplicate))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(SupplierCreateCommand command) => Ok(await _mediator.Send(command));


    /// <summary>
    /// Consulta proveedores de la base de datos.
    /// </summary>
    /// <remarks>
    /// Consulta todos los proveedores registrados en la base de datos.
    /// </remarks>
    /// <response code="200">Consulta exitosa</response>
    /// <response code="400">Error en consulta.</response>
    [HttpGet]
    [SwaggerRequestExample(typeof(GetAllSuppliersQuery), typeof(GetSupplierQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetSupplierResponseExample))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(GetAllSuppliersQuery), StatusCodes.Status200OK)]
    public async Task<IEnumerable<SupplierDto>> GetAll()
    {
        return await _mediator.Send(new GetAllSuppliersQuery());
    }

    /// <summary>
    /// Consulta proveedor por Id de la base de datos.
    /// </summary>
    /// <remarks>
    /// Consulta un proveedores mediante el Id registrados en la base de datos
    /// </remarks>
    /// <response code="404">Entidad no encontrada.</response>
    /// <response code="200">Cunsulta exitos.</response>
    /// <response code="400">Validaciones no cumplidas.</response>
    [HttpGet("{id}")]
    [SwaggerRequestExample(typeof(GetSupplierByIdQuery), typeof(GetSupplierByIdQueryHandler))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetSupplierByIdResponseExample))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SupplierByIdNoFound))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<SupplierDto> GetById(string id)
    {
        return await _mediator.Send(new GetSupplierByIdQuery(id));
    }

    /// <summary>
    /// Modifica los datos de un proveedor.
    /// </summary>
    /// <remarks>
    /// Para modificar un proveedor solo necesitas pasar los datos que necesitas cambiar junto con el id
    /// </remarks>
    /// <response code="404">Entidad no encontrada.</response>
    /// <response code="200">Modificacion exitosa.</response>
    /// <response code="400">Validaciones no cumplidas.</response>
    [HttpPut("{id}")]
    [Authorize]
    [SwaggerRequestExample(typeof(SupplierUpdateCommand), typeof(SupplierUpdateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SupplierByIdNoFound))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(SupplierUpdateCommand command, string id)
    {
        if (id != command.SupplierId)
        {
            throw new Exception("Las Id no concuerdan");
        }

        return Ok(await _mediator.Send(command));
    }

    /// <summary>
    /// Elimina un proveedor
    /// </summary>
    /// <remarks>
    /// para eliminar un proveedor solo es necesario el id
    /// </remarks>
    /// <response code="404">Entidad no encontrada.</response>
    /// <response code="200">Eliminacion exitosa.</response>
    [HttpDelete("{id}")]
    [Authorize]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SupplierByIdNoFound))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(string id) => Ok(await _mediator.Send(new SupplierDeleteCommand(id)));
}