using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
    public class DefsFacade : ScriptableObject
    {
        [SerializeField] private InventoryItemDef _items;
        [SerializeField] private ThrowableItemsDef _throwableItems;
        [SerializeField] private PotionItemsDef _potions;
        [SerializeField] private PlayerDef _player;
        public InventoryItemDef Items => _items;
        public ThrowableItemsDef ThrowableItems => _throwableItems;
        public PotionItemsDef Potions => _potions;
        public PlayerDef Player => _player;

        private static DefsFacade _instance;

        public static DefsFacade Instance => _instance == null ? LoadDefs() : _instance;

        private static DefsFacade LoadDefs()
        {
            return _instance = Resources.Load<DefsFacade>("DefsFacade");
        }
    }
}