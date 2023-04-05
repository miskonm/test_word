using TW.Services.Config.Data;

namespace TW.Game.Validation
{
    public class ValidationModule : IValidationModule
    {
        private readonly IValidationAlgorithm _validationAlgorithm;
        private ValidatedLevel _validatedLevel;

        public ValidationModule(IValidationAlgorithm validationAlgorithm)
        {
            _validationAlgorithm = validationAlgorithm;
        }

        public void Bootstrap(WordsConfig config)
        {
            _validatedLevel = new ValidatedLevel
            {
                Cells = new ValidatedCell[config.WordsWire.Length][]
            };

            for (int i = 0; i < config.WordsWire.Length; i++)
            {
                var line = config.WordsWire[i];
                var validatedLine = new ValidatedCell[line.Length];
                for (int j = 0; j < line.Length; j++)
                {
                    validatedLine[j] = new ValidatedCell(line[j]);
                }

                _validatedLevel.Cells[i] = validatedLine;
            }
        }

        public ValidationResult Validate(string word) =>
            _validationAlgorithm.Validate(_validatedLevel, word);
    }
}