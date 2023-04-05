using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using TW.Services.Config.Data;
using UnityEngine;
using WordsConfig = TW.Services.Config.Data.WordsConfig;

namespace TW.Services.Config
{
    public class LocalFileConfigLoader : IConfigLoader
    {
        private const string WordConfigPath = "Configs/WordsConfig";
        private const string ErrorConfigPath = "";
        private const int SymbolsCountInWire = 10;

        public UniTask<LevelConfig> Load(CancellationToken ct = default)
        {
            var wordJsonAsset = Resources.Load<TextAsset>(WordConfigPath);
            var errorJsonAsset = Resources.Load<TextAsset>(ErrorConfigPath);
            var levelConfig = new LevelConfig(MapWord(wordJsonAsset), MapError(errorJsonAsset));

            return new UniTask<LevelConfig>(levelConfig);
        }

        private ErrorConfig MapError(TextAsset errorJsonAsset)
        {
            if (errorJsonAsset == null || string.IsNullOrEmpty(errorJsonAsset.text))
            {
                return CreateDefaultErrorConfig();
            }

            try
            {
                return JsonConvert.DeserializeObject<ErrorConfig>(errorJsonAsset.text);
            }
            catch (JsonSerializationException)
            {
                return CreateDefaultErrorConfig();
            }
        }

        private ErrorConfig CreateDefaultErrorConfig()
        {
            return new ShakeErrorConfig()
            {
                Time = 2
            };
        }

        private WordsConfig CreateEmptyWordConfig()
        {
            var wire = new string[SymbolsCountInWire][];
            for (int i = 0; i < SymbolsCountInWire; i++)
            {
                wire[i] = GetEmptyWordLine();
            }

            return new WordsConfig(wire);
        }

        private string[] GetEmptyWordLine()
        {
            var line = new string[SymbolsCountInWire];
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = string.Empty;
            }

            return line;
        }


        private WordsConfig MapWord(TextAsset wordJsonAsset)
        {
            if (wordJsonAsset == null || string.IsNullOrEmpty(wordJsonAsset.text))
            {
                return CreateEmptyWordConfig();
            }

            try
            {
                return JsonConvert.DeserializeObject<WordsConfig>(wordJsonAsset.text);
            }
            catch (JsonSerializationException)
            {
                return CreateEmptyWordConfig();
            }
        }
    }
}