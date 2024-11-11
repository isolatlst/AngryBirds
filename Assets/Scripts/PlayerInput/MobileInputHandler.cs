using System;
using Slingshot;
using UnityEngine;

namespace PlayerInput
{
    public class MobileInputHandler : IInputHandler
    {
        private Touch _touch;
        private bool _isTouchWasEnded = false;

        public void InputHandler(
            in Camera camera,
            ref Vector3 startPosition,
            ref Vector3 currentPosition,
            in AbstractSlingshot slingshot, 
            Action released)
        {
            if (Input.touchCount <= 0)
                return;

            _touch = Input.GetTouch(0);
            currentPosition = camera.ScreenToWorldPoint(_touch.position);

            if (_touch.phase == TouchPhase.Began)
            {
                startPosition = currentPosition;
            }

            if (_touch.phase == TouchPhase.Moved)
            {
                slingshot.ChangeTension(startPosition, currentPosition);
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                _isTouchWasEnded = true;
                released?.Invoke();
            }
        }

        public void ActivateSkill(Action skillWasActivated)
        {
            if (_isTouchWasEnded)
            {
                if (_touch.phase is TouchPhase.Began or TouchPhase.Stationary)
                {
                    skillWasActivated?.Invoke();
                }
            }
        }
    }
}