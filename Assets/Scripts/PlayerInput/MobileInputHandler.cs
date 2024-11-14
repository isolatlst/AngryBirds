using System;
using Slingshot;
using UnityEngine;

namespace PlayerInput
{
    public class MobileInputHandler : IInputHandler
    {
        private Vector3 _startPosition;
        private Vector3 _currentPosition;
        private Touch _touch;

        public void InputHandler(
            in Camera camera,
            Action released,
            Action<Vector2> cursorMoved)
        {
            if (Input.touchCount <= 0)
                return;

            _touch = Input.GetTouch(0);
            _currentPosition = camera.ScreenToWorldPoint(_touch.position);

            if (_touch.phase == TouchPhase.Began)
                _startPosition = _currentPosition;

            if (_touch.phase == TouchPhase.Moved)
                cursorMoved?.Invoke(_startPosition - _currentPosition);

            if (_touch.phase == TouchPhase.Ended)
                released?.Invoke();
        }

        public void ActivateSkill(Action skillWasActivated)
        {
            if (_touch.phase is TouchPhase.Stationary)
                skillWasActivated?.Invoke();
        }
    }
}