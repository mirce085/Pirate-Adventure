using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixelCrew.Components.GOBased
{
    public class SpawnListComponent : MonoBehaviour
    {
        [SerializeField] SpawnData[] _spawners;

        public void Spawn(string id)
        {
            var spawner = _spawners.FirstOrDefault(x => x.Id == id);

            spawner?.Component.Spawn();
        }


        [Serializable]
        public class SpawnData
        {
            public string Id;
            public SpawnComponent Component;
        }
    }
}

