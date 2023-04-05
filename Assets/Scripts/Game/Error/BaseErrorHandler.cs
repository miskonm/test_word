using System;
using TW.Services.Config.Data;
using UnityEngine;

namespace TW.Game.Error
{
    public abstract class BaseErrorHandler<TError> : IErrorHandler where TError : ErrorConfig
    {
        public Type ErrorType => typeof(TError);
        
        public void Perform(ErrorConfig errorConfig)
        {
            if (errorConfig is TError casterError)
            {
                Perform(casterError);
            }
            else
            {
                Debug.LogError($"Invalid error casting for '{GetType()}'");
            }
        }

        protected abstract void Perform(TError errorConfig);
    }
}