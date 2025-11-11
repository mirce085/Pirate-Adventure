using PixelCrew.Model.Data;
using PixelCrew.UI.Widgets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.UI.SettingsMenu
{
    public class SettingsWindow : AnimatedWindow
    {
        [SerializeField] private AudioSettingsWidget _music;
        [SerializeField] private AudioSettingsWidget _sfx;

        protected override void Start()
        {
            base.Start();
            _music.SetModel(GameSettings.Instance.Music);
            _sfx.SetModel(GameSettings.Instance.Sfx);
        }
    }
}