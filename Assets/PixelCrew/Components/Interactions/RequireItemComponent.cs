using PixelCrew.Model;
using PixelCrew.Model.Data;
using PixelCrew.Model.Definitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.Interactions
{
    public class RequireItemComponent : MonoBehaviour
    {
        [SerializeField] private InventoryItemData[] _requiredItems;
        [SerializeField] private bool _removeAfterUse;

        private GameSession _gameSession;

        [SerializeField] UnityEvent _OnSuccess;
        [SerializeField] UnityEvent _OnFail;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
        }

        public void Validate()
        {
            bool allRequirementsAreMet = true;

            foreach (var item in _requiredItems)
            {
                var count = _gameSession.PlayerData.Invertory.Count(item.Id);

                if (count < item.Value)
                {
                    allRequirementsAreMet = false;
                    break;
                }
            }

            if (allRequirementsAreMet)
            {
                if (_removeAfterUse)
                {
                    foreach (var item in _requiredItems)
                    {
                        _gameSession.PlayerData.Invertory.Reduce(item.Id, item.Value);
                    }
                }

                _OnSuccess?.Invoke();
                return;
            }

            _OnFail?.Invoke();
        }
    }
}