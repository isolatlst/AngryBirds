using System;
using UnityEngine;

namespace PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        private IInputHandler _inputHandler;
        private Camera _camera;
        public event Action SkillWasActivated;
        public event Action<Vector2> DisplayCursorDraged;
        public event Action Released;

        private void Awake()
        {
            _camera = Camera.main;
            _inputHandler = Application.isMobilePlatform // TODO перенести в entrypoint
                ? new MobileInputHandler()
                : new PCInputHandler();
        }

        private void Update()
        {
            _inputHandler.InputHandler(_camera, Released, DisplayCursorDraged);
            _inputHandler.ActivateSkill(SkillWasActivated);
        }
    }
}