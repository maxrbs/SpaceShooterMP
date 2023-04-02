using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHP;
    // damagePartsList

    public UnityEvent OnDamage;
    public UnityEvent OnDead;

    public void AddHP(float count)
    {
        ModifyHPValue(Mathf.Abs(count));
    }

    public void ApplyDamage(float count)
    {
        ModifyHPValue(-Mathf.Abs(count));

        if (hp > 0f)
            OnDamage.Invoke();
        else
            OnDead.Invoke();
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
