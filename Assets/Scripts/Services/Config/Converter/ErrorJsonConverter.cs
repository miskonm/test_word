using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TW.Services.Config.Data;

namespace TW.Services.Config.Converter
{
    public class ErrorConverter : JsonCreationConverter<ErrorConfig>
    {
        protected override ErrorConfig Create(Type objectType, JObject jObject)
        {
            if (FieldExists("Time", jObject))
            {
                return new ShakeErrorConfig();
            }

            if (FieldExists("SoundPath", jObject))
            {
                return new SoundErrorConfig();
            }

            return null;
        }

        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}