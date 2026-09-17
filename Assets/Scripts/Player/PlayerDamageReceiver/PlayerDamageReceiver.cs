using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected override void Death()
    {
        transform.parent.gameObject.SetActive(false);
        UIManager.Instance.GameOver();
    }
}
