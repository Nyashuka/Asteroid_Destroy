using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Heal();
            Destroy(gameObject);
        }
    }
}
