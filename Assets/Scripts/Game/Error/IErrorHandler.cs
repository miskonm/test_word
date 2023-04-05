using System;
using TW.Services.Config.Data;

namespace TW.Game.Error
{
    public interface IErrorHandler
    {
        Type ErrorType { get; }
        void Perform(ErrorConfig errorConfig);
    }
}