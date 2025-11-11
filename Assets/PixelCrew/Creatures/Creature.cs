using PixelCrew.Components;
using PixelCrew.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components.GOBased;
using PixelCrew.Components.Audio;


namespace PixelCrew.Creatures
{
    public class Creature : MonoBehaviour
    {
        [SerializeField] private bool _invertScale;
        [SerializeField] public float Speed;
        [SerializeField] protected float _jumpForce;
        [SerializeField] protected int _damage;

        [SerializeField] protected LayerCheck _groundCheck;

        [SerializeField] protected CheckCircleOverlap _attackRange;

        [SerializeField] protected SpawnListComponent _spawnListComponent;
        [SerializeField] protected PlaySoundsComponent _soundComponent;

        protected Animator _animator;
        protected Vector2? _direction;
        protected Rigidbody2D _rigidBody2D;
        protected bool _isGrounded;


        protected bool _isJumping;

        protected static int _isGround = Animator.StringToHash("isGround");
        protected static int _isRunning = Animator.StringToHash("isRunning");
        protected static int _hitTrigger = Animator.StringToHash("hitTrigger");
        protected static int _attackTrigger = Animator.StringToHash("attackTrigger");
        protected static int _verticalDirection = Animator.StringToHash("verticalDirection");

        protected virtual void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _soundComponent = GetComponent<PlaySoundsComponent>();
        }


        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        protected virtual void Update()
        {
            _isGrounded = _groundCheck.IsTouchingLayer;
        }

        protected virtual void FixedUpdate()
        {
            if(_direction == null)
            {
                return;
            }

            var xvelocity = _direction.Value.x * Speed;
            var yvelocity = CalculateYVelocity();

            _rigidBody2D.velocity = new Vector2(xvelocity, yvelocity);

            AnimationTransitions();

            UpdateSpriteDirection(_direction.Value);
        }

        protected virtual float CalculateJumpVelocity(float yvelocity)
        {
            if (_isGrounded && _rigidBody2D.velocity.y <= 0.01f)
            {
                yvelocity = _jumpForce;
                _spawnListComponent.Spawn("Jump");
                _soundComponent.Play("Jump");
            }

            return yvelocity;
        }

        protected virtual float CalculateYVelocity()
        {
            var yvelocity = _rigidBody2D.velocity.y;
            bool isJumpPressing = _direction.Value.y > 0;

            if (_isGrounded)
            {
                _isJumping = false;
            }

            if(isJumpPressing)
            {
                _isJumping = true;

                yvelocity = CalculateJumpVelocity(yvelocity);    
            }
            else if (_rigidBody2D.velocity.y > 0 && _isJumping)
            {
                yvelocity *= 0.5f;
            }

            return yvelocity;

        }

        public void UpdateSpriteDirection(Vector2 direction)
        {
            var multiplier = _invertScale ? -1 : 1;

            if (direction.x != 0)
            {
                if (direction.x < 0)
                {
                    transform.localScale = new Vector3(-1 * multiplier, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(multiplier, 1, 1);
                }
            }
        }

        private void AnimationTransitions()
        {
            _animator.SetBool(_isRunning, _direction.Value.x != 0);
            _animator.SetFloat(_verticalDirection, _rigidBody2D.velocity.y);
            _animator.SetBool(_isGround, _groundCheck.IsTouchingLayer);
        }

        public void SpawnFootDust()
        {
            _spawnListComponent.Spawn("FootDust");
        }

        public void SpawnJumpDust()
        {
            _spawnListComponent.Spawn("JumpDust");
        }

        public void SpawnFallDust()
        {
            _spawnListComponent.Spawn("FallDust");
        }

        public virtual void TakeDamage()
        {
            _isJumping = false;
            _animator.SetTrigger(_hitTrigger);
            _rigidBody2D.velocity = new Vector2(_direction.Value.x, _jumpForce);
        }

        public virtual void Attack()
        {
            _spawnListComponent.Spawn("AttackDust");
            _animator.SetTrigger(_attackTrigger);
        }

        public void FinalAttack()
        {
            _attackRange.Check();
            _soundComponent.Play("Melee");
        }
    }
}
