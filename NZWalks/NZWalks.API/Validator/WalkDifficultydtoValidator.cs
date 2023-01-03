using FluentValidation;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Validator
{
    public class WalkDifficultydtoValidator:AbstractValidator<WalkDifficultydto>
    {
        public WalkDifficultydtoValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.WalkDifficultyId).NotEmpty();
            
        }
    }
}
