using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrew.Model;
using PixelCrew.Model.Data;

namespace PixelCrew.Components.LevelManagement
{
    public class ResetLevel : MonoBehaviour
    {
        public void Reset()
        {
            var session = FindObjectOfType<GameSession>();
            var scene = session.PlayerData.StartScene;
            Destroy(session);
            SceneManager.LoadScene(scene);
        }
    }
}
