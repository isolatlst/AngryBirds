using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EntryPoint
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        private IEnumerator Start()
        {
            // Init Loading Screen Service, show it // Экран загрузки
            // Init DI Service (ex. Zenject) // Менеджер ссылок
            // Init UI Service 
            // Init Input Service
            // Init Cloud Services
            // Init Localization Service
            // Init Storage Service
            // Init Scene Management Service
            
            var loadingDuration = 3.0f; // TODO Сделать загрузочный экран
            while (loadingDuration > 0.0f)
            {
                loadingDuration -= Time.deltaTime;
                Debug.Log("Loading ...");
                yield return null;
            }
            
            SceneManager.LoadScene("Level");
        }
    }
}
