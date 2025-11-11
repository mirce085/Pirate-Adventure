using PixelCrew.Creatures;
using PixelCrew.Model.Definitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    public class InventoryAddComponent : MonoBehaviour
    {
        [InventoryId] [SerializeField] private string _id;
        [SerializeField] private int _value;

        public void Add(GameObject go)
        {
            var hero = go.GetComponent<MyHero>();
            if (hero != null)
            {
                hero.AddInInventory(_id, _value);
            }
        }
    }
}