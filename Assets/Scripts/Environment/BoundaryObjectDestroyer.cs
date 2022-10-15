using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryObjectDestroyer : MonoBehaviour
{
    public void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
