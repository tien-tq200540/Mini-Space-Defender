using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : TienMonoBehaviour
{
    [SerializeField] protected float timeElapsed = 0f;
    [SerializeField] protected float timeLimit = 0.5f;
    [SerializeField] protected bool canShoot = false;
    private PlayerActions inputActions;

    protected override void LoadComponents()
    {
        inputActions = new PlayerActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed < timeLimit) return;

        if (inputActions.Shoot.Shooting.IsPressed())
        {
            BulletSpawner.Instance.SpawnPlayerBullet(transform.position, transform.parent.rotation);
            timeElapsed = 0f;
        }
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
