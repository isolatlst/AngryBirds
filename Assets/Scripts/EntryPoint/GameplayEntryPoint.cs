using UnityEngine;

namespace EntryPoint
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private void Start()
        {
            // Init UI with scene screens using UI Service that you grab from Service Locator or another references manager
            // If reference manager isnt created, u can create UI Service here (and reference manager too)

            // Init gameplay input

            // Init Storage Service (if its absent, lets create it)
            // Init Player feature
            // Init Enemies feature
            // Init Inventory feature
            // Init etc
        }

        public void Run()
        {
            
        }
    }
}
        
