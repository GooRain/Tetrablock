using TetraBlock.World.Board;

namespace TetraBlock.Global.Scene
{
    public class GameContext : SceneContext
    {
        public Map Map { get; private set; }

        public void SetMap(Map map)
        {
            Map = map;
        }
    }
}