using System;
using Slingshot;
using UnityEngine;

namespace PlayerInput
{
    public class PCInputHandler : IInputHandler
    {
        public void InputHandler(
            in Camera camera,
            ref Vector3 startPosition,
            ref Vector3 currentPosition,
            in AbstractSlingshot slingshot,
            Action released)
        {
            currentPosition = camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                startPosition = currentPosition;
            }

            if (Input.GetMouseButton(0))
            {
                slingshot.ChangeTension(startPosition, currentPosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                released?.Invoke();
            }
        }

        public void ActivateSkill(Action skillWasActivated)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                skillWasActivated?.Invoke();
        }
    }
}