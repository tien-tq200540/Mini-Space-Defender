using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : TienMonoBehaviour
{
    [SerializeField] protected int curHP;
    [SerializeField] protected int maxHP = 100;

    protected override void LoadComponents()
    {
        SetCurHPAtStart();
    }

    public virtual void DeductHealth(int baseDamage)
    {
        if (curHP <= 0) return;

        curHP -= baseDamage;

        if (curHP <= 0)
        {
            curHP = 0;
            Death();
        }
    }

    protected virtual void Death()
    {
        throw new NotImplementedException();
    }

    protected virtual void SetCurHPAtStart() => curHP = maxHP;
}
