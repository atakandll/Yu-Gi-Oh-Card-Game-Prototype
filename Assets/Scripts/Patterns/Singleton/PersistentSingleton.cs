using UnityEngine;

namespace Patterns.Singleton
{
    public class PersistentSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        #region Public Accessors

        // Static instance of PersistentGameObjectSingleton which allows it to be accessed by any other script
        public static T Instance
        {
            get
            {
                if (instance == null)
                    CreateInstance();
                else
                    HandleDuplication();

                return instance;
            }
        }

        #endregion
        
        private static void CreateInstance()
        {
            var go = new GameObject(typeof(T).ToString());
            instance = go.AddComponent<T>();
        }

        private static void HandleDuplication()
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance.
            var copies = FindObjectsOfType(typeof(T));
            foreach (var copy in copies)
                if (copy != instance)
                    Destroy(copy);
        }
    }
}