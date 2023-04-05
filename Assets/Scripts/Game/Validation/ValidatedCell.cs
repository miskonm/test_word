namespace TW.Game.Validation
{
    public class ValidatedCell
    {
        public bool IsOpened;
        public readonly string Character;

        public ValidatedCell(string character)
        {
            Character = character;
        }
    }
}