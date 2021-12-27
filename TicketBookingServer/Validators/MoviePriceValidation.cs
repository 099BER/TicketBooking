using TicketBookingServer.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace TicketBookingServer.Validators
{
    public class PriceWithinRange : ValidationAttribute
    {
        private int _maxAmount;
        private int _minAmount;

        public PriceWithinRange()
        {
            _maxAmount = 100;
            _minAmount = 0;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            MovieAddEditViewModel mvm = (MovieAddEditViewModel)validationContext.ObjectInstance;
            if (mvm.Movie != null)
            {
                if (mvm.Movie.Price > _maxAmount)
                {
                    return new ValidationResult("The price exceeds maximum price.");
                }
                if (mvm.Movie.Price < _minAmount)
                {
                    return new ValidationResult("The price is below minimum price.");
                }
            }
            return ValidationResult.Success;
        }
    }
}