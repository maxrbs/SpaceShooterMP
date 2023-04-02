using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHP;
    // damagePartsList
    
    public void AddHP(float count)
    {
        ModifyHPValue(Mathf.Abs(count));
    }

    public void ApplyDamage(float count)
    {
        ModifyHPValue(-Mathf.Abs(count));

        if (hp == 0f)
        { 
            //death
        }
    }

    private void ModifyHPValue(float count)
    {
        hp += count;
        hp = Mathf.Clamp(hp, 0f, maxHP);
    }

    public float GetHP()
    {
        float health = hp;
        return health;
    }

    public float GetMaxHP()
    {
        float health = maxHP;
        return health;
    }

}
