using UnityEngine;

namespace TW.Game.Validation
{
    public class SimpleValidationAlgorithm : IValidationAlgorithm
    {
        public ValidationResult Validate(ValidatedLevel validatedLevel, string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return new ValidationResult();
            }

            var stringArray = new string[word.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = word[i].ToString();
            }

            for (int i = 0; i < validatedLevel.Cells.Length; i++)
            {
                var line = validatedLevel.Cells[i];
                for (int j = 0; j < line.Length; j++)
                {
                    var cell = line[j];
                    if (cell.Character == stringArray[0])
                    {
                        if (StartSearch(validatedLevel, stringArray, i, j, out var direction))
                        {
                            return new ValidationResult(new Vector2Int(i, j), stringArray.Length, direction);
                        }
                    }
                }
            }

            return new ValidationResult();
        }

        private bool StartSearch(ValidatedLevel validatedLevel, string[] stringArray, int line, int column,
            out Direction direction)
        {
            direction = Direction.Right;

            if (HorizontalSearch(validatedLevel, stringArray, line, column))
            {
                return true;
            }

            if (VerticalSearch(validatedLevel, stringArray, line, column))
            {
                direction = Direction.Down;
                return true;
            }

            return false;
        }

        private bool HorizontalSearch(ValidatedLevel validatedLevel, string[] stringArray, int line, int column)
        {
            var cells = validatedLevel.Cells;
            var cellLine = cells[line];
            for (int i = 1; i < stringArray.Length; i++)
            {
                var columnIndex = column + i;

                if (columnIndex >= cellLine.Length)
                {
                    return false;
                }

                if (!string.Equals(cellLine[columnIndex].Character, stringArray[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerticalSearch(ValidatedLevel validatedLevel, string[] stringArray, int line, int column)
        {
            var cells = validatedLevel.Cells;

            for (int i = 1; i < stringArray.Length; i++)
            {
                var lineIndex = line + i;

                if (lineIndex >= cells.Length)
                {
                    return false;
                }

                var cell = cells[lineIndex][column];

                if (!string.Equals(cell.Character, stringArray[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}