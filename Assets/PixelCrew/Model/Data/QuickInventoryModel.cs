using Packages.Rider.Editor;
using PixelCrew.Model.Data.Properties;
using PixelCrew.Model.Definitions;
using PixelCrew.Utils.Disposables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixelCrew.Model.Data
{
    public class QuickInventoryModel : IDisposable
    {
        private readonly PlayerData _playerData;

        public InventoryItemData[] Inventory { get; private set; }
        public readonly IntProperty SelectedIndex = new IntProperty();
        public event Action OnChanged;

        public InventoryItemData SelectedItem 
        { 
            get 
            { 
                if(Inventory.Length > 0 && Inventory.Length > SelectedIndex.Value)
                {
                    return Inventory[SelectedIndex.Value];
                }

                return null;
            }
        }

        public ItemDef SelectedDef => DefsFacade.Instance.Items.Get(SelectedItem?.Id);

        public QuickInventoryModel(PlayerData data)
        {
            _playerData = data;
            Inventory = _playerData.Invertory.GetAll(ItemTag.Usable);
            _playerData.Invertory.OnChangeEvent += OnChangedInventory;
        }

        public IDisposable Subscribe(Action action)
        {
            OnChanged += action;
            return new ActionDisposable(() => OnChanged -= action);
        }

        private void OnChangedInventory(string id, int value)
        {
            Inventory = _playerData.Invertory.GetAll(ItemTag.Usable);
            SelectedIndex.Value = Mathf.Clamp(SelectedIndex.Value, 0, Inventory.Length - 1);
            OnChanged?.Invoke();
        }

        internal void SetNextItem()
        {
            SelectedIndex.Value = (int)Mathf.Repeat(SelectedIndex.Value + 1, Inventory.Length);
        }

        public void Dispose()
        {
            _playerData.Invertory.OnChangeEvent -= OnChangedInventory;
        }
    }
}