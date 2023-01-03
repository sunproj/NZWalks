using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validator
{
    public class AddRegionRequestValidator : AbstractValidator<AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(x=>x.RCode).NotEmpty();
            RuleFor(x => x.RName).NotEmpty();
            RuleFor(x => x.RArea).GreaterThan(0);
            RuleFor(x => x.RPopulation).GreaterThanOrEqualTo(0);
            RuleFor(x => x.RLat).GreaterThanOrEqualTo(0);
            RuleFor(x => x.RLong).GreaterThanOrEqualTo(0);
        }
    }
}
