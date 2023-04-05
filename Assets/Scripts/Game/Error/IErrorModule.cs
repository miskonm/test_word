using TW.Services.Config.Data;
using UnityEngine;

namespace TW.Game.Error
{
    public interface IErrorModule
    {
        void Perform(ErrorConfig config);
    }

    public class MockErrorModule : IErrorModule
    {
        public void Perform(ErrorConfig config)
        {
            Debug.LogError($"Error of type {config.GetType()}");
        }
    }
}