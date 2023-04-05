using TW.Services.Config.Data;

namespace TW.Game.Validation
{
    public interface IValidationModule
    {
        void Bootstrap(WordsConfig config);
        ValidationResult Validate(string word);
    }
}