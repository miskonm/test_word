using UnityEngine;

namespace TW.Game.Validation
{
    public struct ValidationResult
    {
        public ValidationStatus Status;
        public Vector2Int StartPosition;
        public int Length;
        public Direction Direction;

        public ValidationResult(Vector2Int startPosition, int length, Direction direction)
        {
            Status = ValidationStatus.Success;
            StartPosition = startPosition;
            Length = length;
            Direction = direction;
        }
    }
}