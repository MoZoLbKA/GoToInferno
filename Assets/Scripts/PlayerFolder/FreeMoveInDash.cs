
using UnityEngine;

namespace Assets.Scripts.Player
{
    internal class FreeMoveInDash : IMove
    {
        private Player _player;
        private MovementPlayer movementPlayer;
        private Animator _animator;
        private Rigidbody2D _rigidBody;
        private float _speedOfPlayer;
        private ParticleSystem _particleSystem;
        private Orientation lastOrient;

        public FreeMoveInDash(Animator anim, Player player, Rigidbody2D rbOfPlayer, ParticleSystem particle,MovementPlayer movement)
        {
            _player = player;
            _animator = anim;
            _rigidBody = rbOfPlayer;
            _speedOfPlayer = _player.Speed;
            _particleSystem = particle;
            movementPlayer = movement;
            lastOrient = movement.Orientation == Orientation.Right? Orientation.Right: Orientation.Left;
        }
        public void Move()
        {
            if (lastOrient != movementPlayer.Orientation)
            {
                lastOrient = movementPlayer.Orientation;
                int direction = movementPlayer.Orientation == Orientation.Left ? -1 : 1;
                _rigidBody.velocity = new Vector2(direction * _speedOfPlayer, 0);
                if (WallPlayerTrigger.inDash)
                {
                    movementPlayer.Flip();
                }
                if (_animator != null)
                {
                    _animator.SetBool("OnMove", true);
                }
                _particleSystem?.Stop();
            }
        }
    }
}
