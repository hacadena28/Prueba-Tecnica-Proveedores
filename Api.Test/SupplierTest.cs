using Api.Controllers;
using Application.Common.Exceptions;
using Application.UseCases.Suppliers.Commands.SupplierCreate;
using Application.UseCases.Suppliers.Commands.SupplierDelete;
using Application.UseCases.Suppliers.Commands.SupplierUpdate;
using Application.UseCases.Suppliers.Dto;
using Application.UseCases.Suppliers.Queries.GetSupplierById;
using Application.UseCases.Suppliers.Queries.GetSuppliers;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Test;

public class SupplierTest
{
    private readonly SupplierController _supplierController;
    private readonly Mock<IMediator> _mediator;

    public SupplierTest()
    {
        _mediator = new Mock<IMediator>();
        _supplierController = new SupplierController(_mediator.Object);
    }

    //unitarias
    [Fact]
    public async Task Create_Provider_Without_Throwing_Exceptionss()
    {
        // Arrange
        var supplierCreateCommand = new SupplierCreateCommand("1234578", "Bussiness one", "Calle 1", "Ciudad 1",
            "Departamento 1", "email@example.com", "Contact Name", "ContactEmail@mail.com");
        _mediator.Setup(m => m.Send(It.IsAny<SupplierCreateCommand>(), default))
            .ReturnsAsync(Unit.Value);
        // Act

        var result = await _supplierController.Create(supplierCreateCommand);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    public async Task Get_All_Providers_Without_Throwing_Exceptions()
    {
        // Arrange
        var returnSuppliers = new List<SupplierDto>() { };

        _mediator.Setup(m => m.Send(It.IsAny<GetAllSuppliersQuery>(), default))
            .ReturnsAsync(returnSuppliers);
        // Act

        var result = await _supplierController.GetAll();

        // Assert
        Assert.IsType<OkObjectResult>(result);
        Assert.IsAssignableFrom<IEnumerable<SupplierDto>>(result);
    }

    [Fact]
    public async Task Get_Supplier_By_Id()
    {
        // Arrange
        var supplierAddress = new SupplierAddress("Calle 1", "Ciudad 1", "Departamento 1");
        var expectedSupplier = new SupplierDto("657d04a8192e26f65f3906a8", "12345678", "Bussiness", supplierAddress,
            "Email@example.com", true, "Name Contact", "contactemail@example.com");

        var id = "657d04a8192e26f65f3906a8";

        _mediator.Setup(x => x.Send(It.IsAny<GetSupplierByIdQuery>(), CancellationToken.None))
            .ReturnsAsync(expectedSupplier);

        // Act
        var result = await _supplierController.GetById(id);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<SupplierDto>(result);
        Assert.Equal(result.Id, id);
    }

    [Fact]
    public async Task Modify_Supplier_And_Return_Ok()
    {
        // Arrange
        var command = new SupplierUpdateCommand("657d04a8192e26f65f3906a8", "Bussiness", "Calle1", "Ciudad 1",
            "Departamento 1", "Email@example.com", true, "Name Contact", "contactemail@example.com");
        var id = "657d04a8192e26f65f3906a8";

        _mediator.Setup(x => x.Send(It.IsAny<SupplierUpdateCommand>(), CancellationToken.None))
            .ReturnsAsync(Unit.Value);
        ;

        // Act
        var result = await _supplierController.Update(command, id);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Delete_Supplier_And_Returns_Ok()
    {
        // Arrange
        var id = "657d04a8192e26f65f3906a8";

        _mediator.Setup(x => x.Send(It.IsAny<SupplierDeleteCommand>(), CancellationToken.None))
            .ReturnsAsync(Unit.Value);

        // Act
        var result = await _supplierController.Delete(id);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<OkObjectResult>(result);
    }

    //integracion
    [Fact]
    public async Task CreateProviderWithoutThrowingExceptions()
    {
        // Arrange
        var supplierCreateCommand = new SupplierCreateCommand("12345", "Bussiness one", "Calle 1", "Ciudad 1",
            "Departamento 1", "email@example.com", "Contact Name", "ContactEmail@mail.com");

        // Act
        try
        {
            await _supplierController.Create(supplierCreateCommand);
            Assert.True(true);
        }
        catch (Exception ex)
        {
            Assert.True(false, $"Se lanzó una excepción: {ex.Message}");
        }

        // Assert
    }
}