using UnityEngine;

namespace Colony.Core.Factory
{
    public class Factory
    {
        public GameObject CreateInstance<T>(string name, Vector2 coordinates, Transform parent) where T : Component
        {
            GameObject instance = new GameObject(name);
            instance.transform.position = coordinates;
            instance.transform.SetParent(parent);
            instance.AddComponent<T>();
            return instance;
        }
    }
}

