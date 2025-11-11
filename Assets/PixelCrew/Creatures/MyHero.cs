using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrew.Components;
using System;
using UnityEditor.Animations;
using PixelCrew.Model;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components.Health;
using PixelCrew.Model.Data;
using PixelCrew.UI.PauseMenu;
using PixelCrew.UI.SettingsMenu;
using PixelCrew.UI;
using PixelCrew.Components.GOBased;
using PixelCrew.Model.Definitions;

namespace PixelCrew.Creatures
{
    public class MyHero : Creature
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private CheckCircleOverlap _interactionCheck;

        [SerializeField] private ParticleSystem _hitParticleSystem;
        [SerializeField] private CooldownComponent _throwCooldown;
        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;
        [SerializeField] private SpawnComponent _throwSpawner;


        [SerializeField] private float _slamDownVelocity;
        private float _jumpCooldown = 0.2f;
        private float _jumpCooldownCounter;
        private bool _canDash = true;
        private bool _isDashing = false;
        [SerializeField] private float _dashForce;
        [SerializeField] private float _dashDuration;
        private float _dashCooldownDuration = 1.5f;
        [SerializeField] TrailRenderer _trailRenderer;


        private bool _canDoubleJump = false;

        private GameSession _gameSession;

        protected static int _throwTrigger = Animator.StringToHash("throwTrigger");

        private const string _swordId = "Sword";
        private string SelectedItemId => _gameSession.QuickInventory.SelectedItem.Id;
        private bool CanThrow
        {
            get
            {
                if (SelectedItemId == _swordId) return _gameSession.PlayerData.Invertory.Count(_swordId) > 1;

                var def = DefsFacade.Instance.Items.Get(SelectedItemId);
                return def.HasTag(ItemTag.Throwable);
            }
        }
        private bool IsPotion
        {
            get
            {
                var def = DefsFacade.Instance.Items.Get(SelectedItemId);
                return def.HasTag(ItemTag.Potion);
            }
        }

        void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
            var health = GetComponent<HealthComponent>();
            health.SetHealth(_gameSession.PlayerData.HP.Value);
            _gameSession.PlayerData.Invertory.OnChangeEvent += OnInventoryChanged;
            UpdateHeroWeapon();
        }

        private void OnDestroy()
        {
            _gameSession.PlayerData.Invertory.OnChangeEvent -= OnInventoryChanged;
        }

        private void OnInventoryChanged(string id, int value)
        {
            if (id == "Sword")
            {
                if (value > 0)
                {
                    _soundComponent.Play(_swordId);
                }
                UpdateHeroWeapon();
            }
        }

        protected override void Update()
        {
            _isGrounded = _groundCheck.IsTouchingLayer;

            if (_isGrounded)
            {
                _jumpCooldownCounter = _jumpCooldown;
            }
            else
            {
                _jumpCooldownCounter -= Time.deltaTime;
            }
        }

        protected override void FixedUpdate()
        {
            if (_isDashing)
            {
                return;
            }

            base.FixedUpdate();
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.IsInLayer(_groundLayer))
            {
                var contact = other.contacts[0];

                if (contact.relativeVelocity.y >= _slamDownVelocity)
                {
                    _spawnListComponent.Spawn("FallDust");
                }
            }
        }


        protected override float CalculateJumpVelocity(float yvelocity)
        {
            if (_jumpCooldownCounter > 0)
            {
                _jumpCooldownCounter = 0;
                _canDoubleJump = true;
            }
            else if (!_isGrounded && _canDoubleJump && _rigidBody2D.velocity.y <= 0.01f)
            {
                _canDoubleJump = false;
            }
            else
            {
                return base.CalculateJumpVelocity(yvelocity);
            }
            SpawnJumpDust();
            _soundComponent.Play("Jump");
            return _jumpForce;
        }

        public void AddInInventory(string id, int value)
        {
            _gameSession.PlayerData.Invertory.Add(id, value);
        }


        public override void TakeDamage()
        {
            base.TakeDamage();
            var coinNum = _gameSession.PlayerData.Invertory.Count("Coin");
            if (coinNum > 0)
            {
                CoinDrop();
            }
        }

        private void CoinDrop()
        {
            _hitParticleSystem.gameObject.SetActive(true);
            var coinNum = _gameSession.PlayerData.Invertory.Count("Coin");
            int coinsToEmmit = Mathf.Min(coinNum, 5);
            _gameSession.PlayerData.Invertory.Reduce("Coin", coinsToEmmit);

            var burst = _hitParticleSystem.emission.GetBurst(0);
            burst.count = coinsToEmmit;

            _hitParticleSystem.emission.SetBurst(0, burst);
            Debug.Log($"Grabbed coins - {coinNum}");
            _hitParticleSystem.Play();
        }


        public void Interact()
        {
            _interactionCheck.Check();
        }


        IEnumerator DashCoroutine()
        {
            _canDash = false;
            _soundComponent.Play("Dash");
            var tempGravity = _rigidBody2D.gravityScale;
            _rigidBody2D.gravityScale = 0;
            _rigidBody2D.velocity = new Vector2(transform.localScale.x * _dashForce, 0);
            _trailRenderer.emitting = true;
            yield return new WaitForSeconds(_dashDuration);
            _trailRenderer.emitting = false;
            _rigidBody2D.gravityScale = tempGravity;
            _isDashing = false;
            yield return new WaitForSeconds(_dashCooldownDuration);
            _canDash = true;
        }

        public void Dash()
        {
            if (_canDash)
            {
                _isDashing = true;
                StartCoroutine(DashCoroutine());
            }
        }

        public override void Attack()
        {
            if (_gameSession.PlayerData.Invertory.Count(_swordId) <= 0) return;

            base.Attack();
        }


        private void UpdateHeroWeapon()
        {
            _animator.runtimeAnimatorController = _gameSession.PlayerData.Invertory.Count(_swordId) > 0 ? _armed : _disarmed;
        }


        public void OnHealthChanged(int health)
        {
            _gameSession.PlayerData.HP.Value = health;
        }

        internal void Throw()
        {
            if (!CanThrow) return;

            if (_throwCooldown.IsReady)
            {
                _animator.SetTrigger(_throwTrigger);
                _throwCooldown.Reset();
            }
        }

        public void FinalThrow()
        {
            _soundComponent.Play("Range");
            var throwableId = _gameSession.QuickInventory.SelectedItem.Id;
            var throwableDef = DefsFacade.Instance.ThrowableItems.Get(throwableId);
            _throwSpawner.SetPrefab(throwableDef.Projectile);
            _throwSpawner.Spawn();
            _gameSession.PlayerData.Invertory.Reduce(throwableId, 1);
        }



        internal void UsePotion()
        {
            if (!IsPotion) return;

            var potion = DefsFacade.Instance.Potions.Get(SelectedItemId);
            //_soundComponent.Play("UsePotion");
            var health = GetComponent<HealthComponent>();
            health.DealDamage(-(int)potion.Value);
            _gameSession.PlayerData.Invertory.Reduce(potion.Id, 1);
        }

        internal void MenuPress()
        {
            var window = Resources.Load<GameObject>("UI/PauseMenu");
            var canvas = FindObjectOfType<Canvas>();

            for (int i = canvas.transform.childCount - 1; i >= 0; --i)
            {
                var child = canvas.transform.GetChild(i);
                var wd = child.GetComponent<AnimatedWindow>();
                if (wd != null)
                {
                    wd.Close();
                    return;
                }
            }

            Instantiate(window, canvas.transform);
        }

        internal void NextItem()
        {
            _gameSession.QuickInventory.SetNextItem();
        }
    }
}