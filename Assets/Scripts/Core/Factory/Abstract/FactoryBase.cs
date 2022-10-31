using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryBase : MonoBehaviour
{
    [SerializeField] protected Enemy _objectPrefab;
    protected ObjectPool _objectsPool;
}
