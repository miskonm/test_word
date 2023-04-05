namespace TW.Game.Validation
{
    public interface IValidationAlgorithm
    {
        ValidationResult Validate(ValidatedLevel validatedLevel, string word);
    }
}