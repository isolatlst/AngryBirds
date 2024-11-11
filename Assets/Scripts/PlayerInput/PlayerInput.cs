using System;
using Slingshot;
using UnityEngine;

namespace PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private AbstractSlingshot _slingshot;
        private IInputHandler _inputHandler;
        private Vector3 _startPosition;
        private Vector3 _currentPosition;
        private Camera _camera;
        public event Action SkillWasActivated;
        public event Action Released;

        private void Awake()
        {
            _camera = Camera.main;
            _inputHandler = Application.isMobilePlatform
                ? new MobileInputHandler()
                : new PCInputHandler();
        }

        private void Update()
        {
            _inputHandler.InputHandler(_camera, ref _startPosition, ref _currentPosition, in _slingshot, Released);
            _inputHandler.ActivateSkill(SkillWasActivated);
        }
    }
}