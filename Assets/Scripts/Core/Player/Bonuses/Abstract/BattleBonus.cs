
using UnityEngine;

public abstract class BattleBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            ApplyBonus(player);
            Destroy(gameObject);
        }          
    }

    protected abstract void ApplyBonus(Player player);
}

