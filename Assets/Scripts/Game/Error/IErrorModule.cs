using TW.Services.Config.Data;

namespace TW.Game.Error
{
    public interface IErrorModule
    {
        void Perform(ErrorConfig config);
    }
}