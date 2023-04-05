using TW.Game.Validation;

namespace TW.Game.Success
{
    public interface ISuccessModule
    {
        void Perform(ValidationResult validationResult);
    }
}