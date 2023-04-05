namespace TW.Services.Config.Data
{
    public class SoundErrorConfig : ErrorConfig
    {
        public string SoundPath;
        
        public override string ToString() => 
            $"{nameof(SoundErrorConfig)}: {nameof(SoundPath)} = {SoundPath}";
    }
}