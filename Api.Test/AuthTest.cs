using Api.Controllers;
using Application.Common;
using Application.UseCases.Auth.Commands.Authentication;
using Application.UseCases.Auth.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using System;
using Application.Common.Exceptions;
using Domain.Exceptions;
using FluentValidation;
using ValidationException = Application.Common.Exceptions.ValidationException;

namespace Api.Test
{
    public class AuthTest
    {
        private readonly AuthController _authController;
        private readonly Mock<IMediator> _mediator;

        public AuthTest()
        {
            _mediator = new Mock<IMediator>();
            _authController = new AuthController(_mediator.Object);
        }

        //unitarias
        
        [Fact]
        public async Task Return_Token_With_Valid_Valid_Credentials()
        {
            // Arrange
            var authenticationCommand = new AuthenticationCommand("admin", "12345678");
            var expectedResult = new AuthenticationDto(
                    ObjectId.GenerateNewId().ToString(),
                    "admin",
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhYzNmOGZiMS05NGVjLTQ1YTctOTUyYi0zMjNjZThjYjI3OGIiLCJVaWQiOiI2NTdiZjUwOGE1MTBiYzMwYmZmNzZkMWIiLCJzdWIiOiJhZG1pbiIsImV4cCI6MTcwMjcxMzAyOCwiaXNzIjoiQXBpU3VwcGxpZXIiLCJhdWQiOiJTdXBwbGllclVzZXIifQ.X8GcHtOq0wpWpp7cDdIB5EH5ES5pDyIb-BHnTVUZd9M"
                )
                { };

            _mediator.Setup(m => m.Send(authenticationCommand, default))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _authController.Authentication(authenticationCommand);

            // Assert
            Assert.IsType<AuthenticationDto>(result);
            Assert.NotNull(result.TokenGenerated);
        }

        [Fact]
        public async Task Return_Message_With_Invalid_Credentials()
        {
            // Arrange
            var authenticationCommand = new AuthenticationCommand("adminfalso", "12345679");
            _mediator.Setup(m => m.Send(It.IsAny<AuthenticationCommand>(), default))
                .ThrowsAsync(new IncorrectCredentialsException());
            // Act

            var exception = await Assert.ThrowsAsync<IncorrectCredentialsException>(async () =>
            {
                await _authController.Authentication(authenticationCommand);
            });
            // Assert

            Assert.IsType<IncorrectCredentialsException>(exception);
            Assert.Equal("Credenciales incorrectas",exception.Message);
        }
        
        [Fact]
        public async Task Return_AttributeValidationMessage()
        {
            // Arrange
            var authenticationCommand = new AuthenticationCommand("admin", "1234567");
            _mediator.Setup(m => m.Send(It.IsAny<AuthenticationCommand>(), default))
                .ThrowsAsync(new ValidationException());
            // Act

            var exception = await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await _authController.Authentication(authenticationCommand);
            });
            // Assert

            Assert.IsType<ValidationException>(exception);
            Assert.Equal("Se han producido uno o mas errores de validacion",exception.Message);
        }
        
        //integracion
    }
}