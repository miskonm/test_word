using System;
using System.Collections.Generic;
using TW.Services.Config.Data;
using UnityEngine;

namespace TW.Game.Error
{
    public class ErrorModule : IErrorModule
    {
        private readonly Dictionary<Type, IErrorHandler> _handlersByType = new();

        public ErrorModule(IList<IErrorHandler> handlers)
        {
            foreach (var handler in handlers)
            {
                _handlersByType.Add(handler.ErrorType, handler);
            }
        }

        public void Perform(ErrorConfig config)
        {
            Debug.LogError($"Error of type {config.GetType()}");

            if (_handlersByType.TryGetValue(config.GetType(), out var handler))
            {
                handler.Perform(config);
            }
            else
            {
                Debug.LogError($"No error handler for error with type '{config.GetType()}'");
            }
        }
    }
}