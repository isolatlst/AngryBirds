using System;
using Slingshot;
using UnityEngine;

namespace PlayerInput
{
    public interface IInputHandler
    {
        public void InputHandler(
            in Camera camera, 
            ref Vector3 startPosition, 
            ref Vector3 currentPosition, 
            in AbstractSlingshot slingshot,
            Action released);

        public void ActivateSkill(Action skillWasActivated);
    }
}