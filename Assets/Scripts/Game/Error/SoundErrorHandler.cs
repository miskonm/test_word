using System;
using TW.Services.Config.Data;
using UnityEngine;

namespace TW.Game.Error
{
    public class SoundErrorHandler : BaseErrorHandler<SoundErrorConfig>
    {
        protected override void Perform(SoundErrorConfig errorConfig)
        {
            Debug.LogError($"SoundErrorHandler '{errorConfig.SoundPath}'");
        }
    }
}