using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PixelCrew.Components
{
    [CreateAssetMenu]
    public class ChanceCoin : ScriptableObject
    {
        [SerializeField] public GameObject Object;
        [SerializeField][Range(1f, 100f)] public float DropChance;
    }
}