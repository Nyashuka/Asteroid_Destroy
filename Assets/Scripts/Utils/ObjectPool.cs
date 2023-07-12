using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class ObjectPool<T> where T : PoolableObject
    {
        private readonly Transform _parentForPoolObjects;
        private readonly PoolableObject _objectPrefab;
        private readonly int _quantityObjects = 100;

        private readonly Queue<PoolableObject> _objectsPool = new Queue<PoolableObject>();

        public ObjectPool(PoolableObject objectPrefab, int quantityObjects, Transform parentObject)
        {
            _parentForPoolObjects = parentObject;
            _objectPrefab = objectPrefab;
            _quantityObjects = quantityObjects;
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < _quantityObjects; i++)
            {
                _objectsPool.Enqueue(CreateObject());
            }
        
        }

        private PoolableObject CreateObject()
        {
            PoolableObject createdObject = Object.Instantiate(_objectPrefab, _parentForPoolObjects);
            createdObject.gameObject.SetActive(false);

            return createdObject;
        }

        public PoolableObject GetObject(Vector3 position)
        {
            PoolableObject gotObjet = _objectsPool.Count == 0 ? CreateObject() : _objectsPool.Dequeue();

            //if(gotObjet == null) { return null; }

            gotObjet.gameObject.SetActive(true);
            gotObjet.transform.position = position;
        
            return gotObjet;
        }

        public void ReturnObjectToPool(PoolableObject objectToReturn)
        {
            if (!(objectToReturn is T))
                return;

            _objectsPool.Enqueue(objectToReturn);
            objectToReturn.gameObject.SetActive(false);
        }
    
    }
}