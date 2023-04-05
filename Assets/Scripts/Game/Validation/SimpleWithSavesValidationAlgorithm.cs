using UnityEngine;

namespace TW.Game.Validation
{
    public abstract class SimpleWithSavesValidationAlgorithm : IValidationAlgorithm
    {
        protected abstract bool NeedIncludeOpenedWorlds { get; }

        public ValidationResult Validate(ValidatedLevel validatedLevel, string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return new ValidationResult();
            }

            var wordLength = word.Length;
            var stringArray = new string[wordLength];
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = word[i].ToString();
            }

            var cells = validatedLevel.Cells;
            for (int i = 0; i < cells.Length; i++)
            {
                var line = cells[i];
                var lineLength = line.Length;
                for (int j = 0; j < lineLength; j++)
                {
                    if (lineLength - j < wordLength)
                    {
                        break;
                    }

                    var cell = line[j];
                    if ((NeedIncludeOpenedWorlds || !cell.IsOpened) && cell.Character == stringArray[0])
                    {
                        if (StartSearch(cells, stringArray, i, j, out var direction))
                        {
                            MarkOpened(cells, i, j, stringArray.Length, direction);
                            return new ValidationResult(new Vector2Int(i, j), stringArray.Length, direction);
                        }
                    }
                }
            }

            return new ValidationResult();
        }
        
        


        private bool StartSearch(ValidatedCell[][] cells, string[] stringArray, int line, int column,
            out Direction direction)
        {
            direction = Direction.Right;

            if (HorizontalSearch(cells, stringArray, line, column))
            {
                return true;
            }

            if (VerticalSearch(cells, stringArray, line, column))
            {
                direction = Direction.Down;
                return true;
            }

            return false;
        }

        private bool HorizontalSearch(ValidatedCell[][] cells, string[] stringArray, int line, int column)
        {
            var cellLine = cells[line];
            var isAllOpened = true;
            for (int i = 1; i < stringArray.Length; i++)
            {
                var columnIndex = column + i;

                if (columnIndex >= cellLine.Length)
                {
                    return false;
                }

                var cell = cellLine[columnIndex];
                if (!cell.IsOpened)
                {
                    isAllOpened = false;
                }
                
                if ((!NeedIncludeOpenedWorlds && cell.IsOpened) || !string.Equals(cell.Character, stringArray[i]))
                {
                    return false;
                }
            }

            return !isAllOpened;
        }

        private bool VerticalSearch(ValidatedCell[][] cells, string[] stringArray, int line, int column)
        {
            if (cells.Length - line < stringArray.Length)
            {
                return false;
            }

            var isAllOpened = true;
            for (int i = 1; i < stringArray.Length; i++)
            {
                var lineIndex = line + i;

                if (lineIndex >= cells.Length)
                {
                    return false;
                }

                var cell = cells[lineIndex][column];
                if (!cell.IsOpened)
                {
                    isAllOpened = false;
                }

                if ((!NeedIncludeOpenedWorlds && cell.IsOpened) || !string.Equals(cell.Character, stringArray[i]))
                {
                    return false;
                }
            }

            return !isAllOpened;
        }

        private void MarkOpened(ValidatedCell[][] cells, int line, int column, int length, Direction direction)
        {
            for (int i = 0; i < length; i++)
            {
                var lineIndex = direction == Direction.Down ? line + i : line;
                var columnIndex = direction == Direction.Right ? column + i : column;

                var cell = cells[lineIndex][columnIndex];
                cell.IsOpened = true;
            }
        }
    }
}