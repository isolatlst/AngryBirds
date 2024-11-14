using System;
using Slingshot;
using UnityEngine;

namespace PlayerInput
{
    public class PCInputHandler : IInputHandler
    {
        private Vector3 _startPosition;
        private Vector3 _currentPosition;
        
        public void InputHandler(
            in Camera camera,
            Action released,
            Action<Vector2> cursorMoved)
        {
            
            _currentPosition = camera.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
                _startPosition = _currentPosition;

            if (Input.GetMouseButton(0))
                cursorMoved?.Invoke(_startPosition - _currentPosition);

            if (Input.GetMouseButtonUp(0))
                released?.Invoke();
        }

        public void ActivateSkill(Action skillWasActivated)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                skillWasActivated?.Invoke();
        }
    }
}