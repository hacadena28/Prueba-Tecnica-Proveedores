using Api.Examples.SupplierExamples;
using Application.Common;
using Application.UseCases.Suppliers.Commands.SupplierCreate;
using Application.UseCases.Suppliers.Commands.SupplierDelete;
using Application.UseCases.Suppliers.Commands.SupplierUpdate;
using Application.UseCases.Suppliers.Dto;
using Application.UseCases.Suppliers.Queries.GetSupplierById;
using Application.UseCases.Suppliers.Queries.GetSuppliers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SupplierController
{
    private readonly IMediator _mediator;

    public SupplierController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Registra proveedores en la base de datos.
    /// </summary>
    /// <remarks>
    /// Para registrar proveedores necesita llenar todos los datos necesarios
    /// </remarks>
    [HttpPost]
    [Authorize]
    [SwaggerRequestExample(typeof(SupplierCreateCommand), typeof(SupplierCreateCommandExample))]
    [SwaggerResponseExample(400, typeof(Response<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    public async Task Create(SupplierCreateCommand command) => await _mediator.Send(command);


    /// <summary>
    /// Consulta proveedores de la base de datos.
    /// </summary>
    /// <remarks>
    /// Consulta todos los proveedores registrados en la base de datos.
    /// </remarks>
    [HttpGet]
    [SwaggerRequestExample(typeof(GetAllSuppliersQuery), typeof(GetSupplierQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetSupplierResponseExample))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    [HttpGet("{id}")]
    [SwaggerRequestExample(typeof(GetSupplierByIdQuery), typeof(GetSupplierByIdQueryHandler))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetSupplierByIdResponseExample))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    [HttpPut("{id}")]
    [Authorize]
    [SwaggerRequestExample(typeof(SupplierUpdateCommand), typeof(SupplierUpdateCommandExample))]
    [SwaggerResponseExample(400, typeof(Response<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    public async Task Update(SupplierUpdateCommand command, string id)
    {
        if (id != command.SupplierId)
        {
            throw new Exception("Las Id no concuerdan");
        }

        await _mediator.Send(command);
    }

    /// <summary>
    /// Elimina un proveedor
    /// </summary>
    /// <remarks>
    /// para eliminar un proveedor solo es necesario el id
    /// </remarks>
    [HttpDelete("{id}")]
    [Authorize]
    [SwaggerResponseExample(400, typeof(Response<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    public async Task Delete(string id) => await _mediator.Send(new SupplierDeleteCommand(id));
}