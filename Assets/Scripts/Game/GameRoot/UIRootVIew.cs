using UnityEngine;

namespace EntryPoint
{
    public class UIRootVIew : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;

        private void Awake()
        {
            _loadingScreen.SetActive(false);
        }
        
        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }
        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }
    }
}