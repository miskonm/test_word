namespace TW.Services.Config.Data
{
    public class LevelConfig
    {
        public WordsConfig WordsConfig { get; }
        public ErrorConfig ErrorConfig { get; }
        
        public LevelConfig(WordsConfig wordsConfig, ErrorConfig errorConfig)
        {
            WordsConfig = wordsConfig;
            ErrorConfig = errorConfig;
        }
    }
}