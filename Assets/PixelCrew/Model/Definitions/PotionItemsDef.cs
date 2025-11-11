using PixelCrew.Model.Definitions.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/PotionItemsDef", fileName = "PotionItemsDef")]
    public class PotionItemsDef : DefRepository<PotionDef>
    {
    }

    [Serializable]
    public class PotionDef : IHaveId
    {
        [InventoryId][SerializeField] private string _id;
        [SerializeField] private float _value;
        [SerializeField] private float _time;

        public string Id => _id;
        public float Value => _value;
        public float Time => _time;
    }

}