using PixelCrew.Model;
using PixelCrew.Model.Definitions;
using PixelCrew.UI.Widgets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.UI.Hud
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private ProgressBarWidget _healthBar;
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            _session.PlayerData.HP.OnChanged += OnHealthChanged;

            OnHealthChanged(0, _session.PlayerData.HP.Value);
        }

        private void OnHealthChanged(int oldValue, int newValue)
        {
            var maxHealth = DefsFacade.Instance.Player.MaxHealth;
            var progress = (float)newValue / maxHealth;
            _healthBar.SetProgress(progress);
        }

        private void OnDestroy()
        {
            _session.PlayerData.HP.OnChanged -= OnHealthChanged;
        }
    }
}