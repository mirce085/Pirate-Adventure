using PixelCrew.Model.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/DialogDef", fileName = "DialogDef")]
    public class DialogDef : ScriptableObject
    {
        [SerializeField] private DialogItem _data;
        public DialogItem Data => _data;
    }
}