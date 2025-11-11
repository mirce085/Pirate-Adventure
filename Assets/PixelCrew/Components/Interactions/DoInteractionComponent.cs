using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.Interactions
{
    public class DoInteractionComponent : MonoBehaviour
    {
        public void DoInteraction(GameObject gameObject)
        {
            var intComponent = gameObject.GetComponent<InteractableComponent>();

            if (intComponent != null)
            {
                intComponent.Interact();
            }
        }
    }
}