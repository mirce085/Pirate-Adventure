using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PixelCrew.Creatures;

namespace PixelCrew.Creatures
{
    public class HeroBehaviour : MonoBehaviour
    {
        [SerializeField] private MyHero _hero;


        public void OnHorizontalMovement(InputAction.CallbackContext context)
        {
            _hero.SetDirection(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            _hero.Interact();
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            _hero.Dash();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Attack();
            }
        }

        public void OnThrow(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Throw();
            }
        }

        public void OnHeal(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.UsePotion();
            }
        }

        public void OnMenuPressed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.MenuPress();
            }
        }
        
        public void OnInventorySwitch(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.NextItem();
            }
        }
    }
}
