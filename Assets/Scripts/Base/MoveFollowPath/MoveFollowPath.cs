using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowPath : TienMonoBehaviour
{
    [Header("Checkpoints")]
    [SerializeField] protected List<Transform> checkPoints = new();
    [SerializeField] protected Transform checkPointsHolder;

    [Header("Move")]
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected Transform target;
    [SerializeField] protected int targetIndex = 0;
    [SerializeField] protected float disLimit = 0.1f;

    protected override void LoadComponents()
    {
        LoadCheckpointsHolder();
        LoadCheckPoints();
        LoadStartedPosition();
        target = FindNextTarget();
    }

    private void Update()
    {
        float curDistance = Vector3.Distance(transform.parent.position, target.position);
        if (curDistance <= disLimit)
        {
            target = FindNextTarget();
        }
        MoveToTargetWithoutRb2D(transform.parent, target, speed);
    }

    protected virtual Transform FindNextTarget()
    {
        targetIndex = (targetIndex + 1)%checkPoints.Count;
        return checkPoints[targetIndex];
    }

    protected virtual void MoveToTargetWithoutRb2D(Transform current, Transform target, float speed)
    {
        Vector3 direction = (target.position - current.position).normalized;
        current.Translate(speed * Time.deltaTime * direction, Space.World);
    }

    private void LoadStartedPosition()
    {
        transform.parent.position = checkPoints[0].position;
    }

    protected virtual void LoadCheckPoints()
    {
        checkPoints.Clear();
        foreach (Transform child in checkPointsHolder)
        {
            checkPoints.Add(child);
        }
    }

    protected virtual void LoadCheckpointsHolder()
    {
        if (checkPointsHolder != null) return;
        checkPointsHolder = GameObject.Find("CheckpointsHolder").transform;
    }
}
