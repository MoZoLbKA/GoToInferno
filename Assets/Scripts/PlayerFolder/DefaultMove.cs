
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    internal class DefaultMove : IMove
    {
        private MovementPlayer _movementPlayer;
        private Animator _animator;
        private Rigidbody2D _rigidBody;
        private ParticleSystem _particleSystem;
        private float _speedOfPlayer;
        public DefaultMove(Animator anim, Player player, Rigidbody2D rbOfPlayer, ParticleSystem particle,MovementPlayer movement)
        {
            _movementPlayer = movement;
            _animator = anim;
            _rigidBody = rbOfPlayer;
            _speedOfPlayer = player.Speed;
            _particleSystem = particle;
        }
        public void Move()
        {
            int direction = _movementPlayer.Orientation == Orientation.Left ? -1 : 1;
            if (!WallPlayerTrigger.inDash)
            {
                _rigidBody.velocity = new Vector2(direction * _speedOfPlayer, 0);
                if (_animator != null)
                {
                    _animator.SetBool("OnMove", true);
                }
                _particleSystem?.Stop();              
            }                   
        }
    }
}
