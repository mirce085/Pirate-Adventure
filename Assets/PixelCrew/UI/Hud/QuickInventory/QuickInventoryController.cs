using PixelCrew.Model;
using PixelCrew.Model.Data;
using PixelCrew.UI.Widgets;
using PixelCrew.Utils.Disposables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace PixelCrew.UI.Hud.QuickInventory
{
    public class QuickInventoryController : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private InventoryItemWidget _prefab;

        private GameSession _session;
        private InventoryItemData[] _inventory;
        private List<InventoryItemWidget> _createdItems = new List<InventoryItemWidget>();
        private CompositeDisposable _trash = new CompositeDisposable();
        private DataGroup<InventoryItemData, InventoryItemWidget> _dataGroup;

        private void Start()
        {
            _dataGroup = new DataGroup<InventoryItemData, InventoryItemWidget>(_prefab, _container);
            _session = FindObjectOfType<GameSession>();
            _trash.Retain(_session.QuickInventory.Subscribe(Rebuild));
            Rebuild();
        }

        private void Rebuild()
        {
            _inventory = _session.QuickInventory.Inventory;

            _dataGroup.SetData(_inventory);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}