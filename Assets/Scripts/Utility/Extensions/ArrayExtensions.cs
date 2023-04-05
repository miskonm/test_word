namespace TW.Utility.Extensions
{
    public static class ArrayExtensions
    {
        public static T Random<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
            {
                return default;
            }

            var randomIndex = UnityEngine.Random.Range(0, array.Length);
            return array[randomIndex];
        }
    }
}