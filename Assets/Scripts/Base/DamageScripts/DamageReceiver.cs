using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : TienMonoBehaviour
{
    [SerializeField] protected int curHP;
    [SerializeField] protected int maxHP;

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

    protected abstract void Death();

    protected virtual void SetCurHPAtStart() => curHP = maxHP;
}
