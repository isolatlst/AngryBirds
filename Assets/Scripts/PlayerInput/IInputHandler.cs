using System;
using Slingshot;
using UnityEngine;

namespace PlayerInput
{
    public interface IInputHandler
    {
        public void InputHandler(
            in Camera camera, 
            Action released,
            Action<Vector2> cursorMoved);

        public void ActivateSkill(Action skillWasActivated);
    }
}