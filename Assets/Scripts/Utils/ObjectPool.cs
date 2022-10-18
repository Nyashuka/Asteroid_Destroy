using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
    private readonly PoolableObject _objectPrefab;
    private readonly int _quantityObjects = 100;

    private readonly Queue<PoolableObject> _objectsPool = new Queue<PoolableObject>();

    public ObjectPool(PoolableObject objectPrefab, int quantityObjects)
    {
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
        PoolableObject createdObject = Object.Instantiate(_objectPrefab);
        createdObject.gameObject.SetActive(false);

        return createdObject;
    }

    public PoolableObject GetObject(Vector3 position)
    {
        PoolableObject gotObjet = _objectsPool.Count == 0 ? CreateObject() : _objectsPool.Dequeue();

        gotObjet.gameObject.SetActive(true);
        gotObjet.transform.position = position;
        
        return gotObjet;
    }

    public void ReturnObjectToPool(PoolableObject objectToReturn)
    {
        _objectsPool.Enqueue(objectToReturn);
        objectToReturn.gameObject.SetActive(false);
    }

    
}