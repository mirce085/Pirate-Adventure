using PixelCrew.Model.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixelCrew.Model.Data
{
    [Serializable]
    public class InvertoryData
    {
        [SerializeField] private List<InventoryItemData> _inventory = new List<InventoryItemData>();

        public delegate void OnInventoryChanged(string id, int value);

        public OnInventoryChanged OnChangeEvent;

        public void Add(string id, int value)
        {
            if (value <= 0) return;

            var itemDef = DefsFacade.Instance.Items.Get(id);
            if (itemDef.IsVoid) return;

            if (itemDef.HasTag(ItemTag.Stackable))
            {
                AddToStack(id, value);
            }
            else
            {
                AddNonStack(id, value);
            }

            OnChangeEvent?.Invoke(id, value);
        }

        public InventoryItemData[] GetAll(params ItemTag[] tags)
        {
            var retValue = new List<InventoryItemData>();
            foreach (var item in _inventory)
            {
                var itemDef = DefsFacade.Instance.Items.Get(item.Id);
                var areAllRequirementsMet = tags.All(x => itemDef.HasTag(x));
                if(areAllRequirementsMet)
                {
                    retValue.Add(item);
                }
            }

            return retValue.ToArray();
        }

        private void AddToStack(string id, int value)
        {
            var isFull = _inventory.Count >= DefsFacade.Instance.Player.InventorySize;

            var foundItem = _inventory.FirstOrDefault(x => x.Id == id);
            if (foundItem == null)
            {
                if (isFull) return;
                _inventory.Add(new InventoryItemData(id, value));
                return;
            }
            foundItem.Value += value;
        }

        private void AddNonStack(string id, int value)
        {
            var itemLasts = DefsFacade.Instance.Player.InventorySize - _inventory.Count;
            value = Mathf.Min(value, itemLasts);

            for (int i = 0; i < value; i++)
            {
                _inventory.Add(new InventoryItemData(id, 1));
            }
        }

        public void Reduce(string id, int value)
        {
            if (value <= 0) return;

            var itemDef = DefsFacade.Instance.Items.Get(id);
            if (itemDef.IsVoid) return;

            if (itemDef.HasTag(ItemTag.Stackable))
            {
                RemoveFromStack(id, value);
            }
            else
            {
                RemoveNonStack(id, value);
            }


            OnChangeEvent?.Invoke(id, value);
        }

        private void RemoveFromStack(string id, int value)
        {
            var foundItem = _inventory.FirstOrDefault(y => y.Id == id);
            if (foundItem == null) return;

            foundItem.Value -= value;

            if (foundItem.Value <= 0) _inventory.Remove(foundItem);
        }

        private void RemoveNonStack(string id, int value)
        {
            for (int i = 0; i < value; i++)
            {
                var foundItem = _inventory.FirstOrDefault(y => y.Id == id);
                if (foundItem == null) return;

                _inventory.Remove(foundItem);
            }
        }

        public int Count(string id)
        {
            var itemDef = DefsFacade.Instance.Items.Get(id);
            if (itemDef.IsVoid) return 0;

            var item = _inventory.FirstOrDefault(x => x.Id == id);

            if (item == null) return 0;

            return item.Value;
        }
    }




    [Serializable]
    public class InventoryItemData
    {
        [InventoryId] public string Id;
        public int Value;

        public InventoryItemData(string id, int value)
        {
            Id = id;
            Value = value;
        }
    }
}