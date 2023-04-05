using Zenject;

namespace TW.Game
{
    public class GameStarter : IInitializable
    {
        private readonly IGameController _gameController;

        public GameStarter(IGameController gameController)
        {
            _gameController = gameController;
        }

        public void Initialize()
        {
            _gameController.Start();
        }
    }
}