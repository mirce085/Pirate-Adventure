using PixelCrew.Model.Data.Properties;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.Model.Data
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private InvertoryData _inventory;
        public InvertoryData Invertory => _inventory;

        public IntProperty HP = new IntProperty();

        public string StartScene;
    }
}