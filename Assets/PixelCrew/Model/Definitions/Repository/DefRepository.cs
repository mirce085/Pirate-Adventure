using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.Editor.InputActionCodeGenerator;

namespace PixelCrew.Model.Definitions.Repository
{
    public class DefRepository<T> : ScriptableObject where T : IHaveId
    {
        [SerializeField] protected T[] _collection;

        public T Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return default;
            foreach (var item in _collection)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return default;
        }
    }
}