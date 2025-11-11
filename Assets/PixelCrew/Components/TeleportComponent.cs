using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PixelCrew.Components
{
    public class TeleportComponent : MonoBehaviour
    {
        [SerializeField] private Transform _destination;

        public void Teleport(GameObject obj)
        {
            obj.transform.position = _destination.position;
        }
    }
}
