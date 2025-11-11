using PixelCrew.Model.Data;
using PixelCrew.Model.Definitions;
using PixelCrew.UI.Hud.Dialogs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.Dialogs
{
    public class ShowDialogComponent : MonoBehaviour
    {
        [SerializeField] private Mode _mode;
        [SerializeField] private DialogItem _bound;
        [SerializeField] private DialogDef _external;

        private DialogBoxController _dialogBoxController;

        public enum Mode
        {
            Bound,
            External
        }

        public void Show()
        {
            if (_dialogBoxController == null)
            {
                _dialogBoxController = FindObjectOfType<DialogBoxController>();
            }

            _dialogBoxController.ShowDialog(Data);
        }

        public DialogItem Data
        {
            get
            {
                switch (_mode)
                {
                    case Mode.Bound:
                        return _bound;
                    case Mode.External:
                        return _external.Data;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}