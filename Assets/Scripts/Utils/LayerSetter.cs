using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSetter : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;

    private void Start()
    {
        gameObject.layer = _layer;
    }
}
