
using UnityEngine;

public abstract class BattleBonus : MonoBehaviour
{
    private float _durationInSeconds;



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

