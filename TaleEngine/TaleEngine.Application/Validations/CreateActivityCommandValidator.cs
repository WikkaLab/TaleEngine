using FluentValidation;
using Microsoft.Extensions.Logging;
using TaleEngine.Application.Commands;

namespace TaleEngine.Application.Validations
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        public CreateActivityCommandValidator(ILogger<CreateActivityCommandValidator> logger)
        {
            //RuleFor(command => command.City).NotEmpty();
            //RuleFor(command => command.Street).NotEmpty();
            //RuleFor(command => command.State).NotEmpty();
            //RuleFor(command => command.Country).NotEmpty();
            //RuleFor(command => command.ZipCode).NotEmpty();
            //RuleFor(command => command.CardNumber).NotEmpty().Length(12, 19);
            //RuleFor(command => command.CardHolderName).NotEmpty();
            //RuleFor(command => command.CardExpiration).NotEmpty().Must(BeValidExpirationDate).WithMessage("Please specify a valid card expiration date");
            //RuleFor(command => command.CardSecurityNumber).NotEmpty().Length(3);
            //RuleFor(command => command.CardTypeId).NotEmpty();
            //RuleFor(command => command.OrderItems).Must(ContainOrderItems).WithMessage("No order items found");

            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }

        //private bool BeValidExpirationDate(DateTime dateTime)
        //{
        //    return dateTime >= DateTime.UtcNow;
        //}

        //private bool ContainOrderItems(IEnumerable<OrderItemDTO> orderItems)
        //{
        //    return orderItems.Any();
        //}
    }
}