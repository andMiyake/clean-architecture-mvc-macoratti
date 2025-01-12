using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            // Arrange & Act
            Action action = () => new Category(1, "Category Name");

            // Assert
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With invalid Id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            // Arrange & Act
            Action action = () => new Category(-1, "Category Name");

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            // Arrange & Act
            Action action = () => new Category(1, "Ca");

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptioRequiredName()
        {
            // Arrange & Act
            Action action = () => new Category(1, "");

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionShortName()
        {
            // Arrange & Act
            Action action = () => new Category(1, null);

            // Assert
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }
    }
}
