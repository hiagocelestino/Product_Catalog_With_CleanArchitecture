using FluentAssertions;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest
{
    [Fact(DisplayName = "Create Product With Valid State")]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(
            1, "Product Name", "Product Description", 9.99m, 99, "product image"
        );
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product With Invalid State")]
    public void CreateProduct_NegativeIdValue_ResultObjectInvalidState()
    {
        Action action = () => new Product(
            -1, "Product Name", "Product Description", 9.99m, 99, "product image"
        );
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Product With Short Name")]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(
            1, "Pr", "Product Description", 9.99m, 99, "product image"
        );
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Product With Short Description")]
    public void CreateProduct_ShortDescriptionValue_DomainExceptionShortName()
    {
        Action action = () => new Product(
            1, "Product Name", "Desc", 9.99m, 99, "product image"
        );
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description, too short, minimum 5 characters");
    }

    [Fact(DisplayName = "Create Product With Long Image Name")]
    public void CreateProduct_LongImageName_DomainExceptionLongImageName()
    {
        Action action = () => new Product(
            1, "Product Name", "Product Description", 9.99m, 99, @"product
            imageeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
            tooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo
            looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong"
        );
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image name, too long, maximum 250 characters");
    }

    [Fact(DisplayName = "Create Product With Null Image Name")]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {
        Action action = () => new Product(
            1, "Product Name", "Product Description", 9.99m, 99, null);
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product With Null Image Name")]
    public void CreateProduct_WithNullImageName_NoNullReferenceException()
    {
        Action action = () => new Product(
            1, "Product Name", "Product Description", 9.99m, 99, null);
        action.Should()
            .NotThrow<NullReferenceException>();
    }

    [Fact(DisplayName = "Create Product With Empty Image Name")]
    public void CreateProduct_WithEmptyImageName_NoDomainException()
    {
        Action action = () => new Product(
            1, "Product Name", "Product Description", 9.99m, 99, "");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Product With Empty Image Name")]
    public void CreateProduct_InvalidPriceValue_NoDomainException()
    {
        Action action = () => new Product(
            1, "Product Name", "Product Description", -9.99m, 99, "");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid price value");
    }

    [Theory(DisplayName = "Create Product With Invalid Stock")]
    [InlineData(-5)]
    public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
    {
        Action action = () => new Product(
            1, "Product Name", "Product Description", 9.99m, value, "product image");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
    
}