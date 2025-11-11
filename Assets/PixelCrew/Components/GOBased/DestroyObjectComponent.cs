using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.GOBased
{
    public class DestroyObjectComponent : MonoBehaviour
    {

        [SerializeField] private GameObject _objectToDestroy;

        public void Destroy()
        {
            Destroy(_objectToDestroy);
        }
    }
}