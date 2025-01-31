using Xunit;
using Cpsc370Final.Core;
using Cpsc370Final;
using Cpsc370Final.Objects;
using Cpsc370Final.Entities;

namespace Cpsc370Final.Tests
{
    public class GameTests
    {
        private LevelGrid levelGrid;
        private Player player;

        public GameTests()
        {
            levelGrid = new LevelGrid(10, 10);
            player = new Player(levelGrid, new GridPosition(0, 0));
        }

        [Fact]
        public void Player_MovesCorrectly()
        {
            player.Move(Direction.East);
            Assert.Equal(new GridPosition(1, 0), player.position);

            player.Move(Direction.South);
            Assert.Equal(new GridPosition(1, 1), player.position);
        }

        [Fact]
        public void Player_CollectsKey()
        {
            var keyPosition = new GridPosition(2, 2);
            var key = new Key(levelGrid, keyPosition);
            levelGrid.AddGameObjectToGrid(key);

            player.position = new GridPosition(1, 2);
            player.Move(Direction.East);
            
            Assert.Equal(1, player.HeldKeys);
        }

        [Fact]
        public void Player_CannotEnterLockedDoor()
        {
            var doorPosition = new GridPosition(3, 3);
            var door = new Door(levelGrid, doorPosition, player, 1);
            levelGrid.AddGameObjectToGrid(door);

            player.position = new GridPosition(2, 3);
            player.Move(Direction.East);

            Assert.Equal(new GridPosition(2, 3), player.position);
        }

        [Fact]
        public void Goblin_MovesCorrectly()
        {
            var goblin = new Goblin(levelGrid, new GridPosition(4, 4));
            levelGrid.AddGameObjectToGrid(goblin);
            goblin.PerformTurnAction();

            var newPosition = goblin.position;
            Assert.True(newPosition.Equals(new GridPosition(4, 3)) || newPosition.Equals(new GridPosition(4, 5)));
        }

        [Fact]
        public void Skeleton_PathfindsToPlayer()
        {
            var skeleton = new Skeleton(levelGrid, new GridPosition(5, 5), player);
            levelGrid.AddGameObjectToGrid(skeleton);
            player.position = new GridPosition(5, 2);

            skeleton.PerformTurnAction();
            skeleton.PerformTurnAction();
            Assert.NotEqual(new GridPosition(5, 5), skeleton.position);
        }

        [Fact]
        public void Wraith_TeleportsPlayer()
        {
            var wraith = new Wraith(levelGrid, new GridPosition(6, 6), player);
            levelGrid.AddGameObjectToGrid(wraith);
            wraith.PlayerInteraction(player);

            Assert.NotEqual(new GridPosition(6, 6), player.position);
        }
    }
}
