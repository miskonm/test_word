using System.Globalization;

namespace TW.Services.Config.Data
{
    public class ShakeErrorConfig : ErrorConfig
    {
        public float Time;

        public override string ToString() => 
            $"{nameof(ShakeErrorConfig)}: {nameof(Time)} = {Time.ToString(CultureInfo.InvariantCulture)}";
    }
}