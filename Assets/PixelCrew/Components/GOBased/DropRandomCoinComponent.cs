using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using PixelCrew.Components.Collectables;  
using PixelCrew.Creatures;
using PixelCrew.Components;


namespace PixelCrew.Components.GOBased
{
    public class DropRandomCoinComponent : MonoBehaviour
    {
        [SerializeField] private int _dropAmount;
        [SerializeField] private List<ChanceCoin> _dropElements;

        public void Drop()
        {
            float random = Random.Range(1, 101);
            foreach (var element in _dropElements)
            {
                if (random <= element.DropChance)
                {
                    for (int i = 0; i < _dropAmount; i++)
                    {
                        GameObject droppedItem = PrefabUtility.InstantiatePrefab(element.Object) as GameObject;
                        //GrabCoin gc = droppedItem.GetComponent<GrabCoin>();
                        //gc.Hero = _hero;
                        droppedItem.transform.position = new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.value, transform.position.z);
                    }
                    break;
                }
                else
                {
                    random -= element.DropChance;
                }
            }
        }
    }
}