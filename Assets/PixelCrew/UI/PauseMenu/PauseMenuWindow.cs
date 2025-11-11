using PixelCrew.Model;
using PixelCrew.UI.MainMenu;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.UI.PauseMenu
{
    public class PauseMenuWindow : MainMenuWindow
    {
        private float _originalTimeScale;

        protected override void Start()
        {
            base.Start();

            _originalTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        private void OnDestroy()
        {
            Time.timeScale = _originalTimeScale;
        }

        public void OnExitToMainMenu()
        {
            SceneManager.LoadScene("MainMenuScene");

            var session = FindObjectOfType<GameSession>();
            Destroy(session);
        }

        public void OnResume()
        {
            Close();
        }
    }
}