using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private float waitForExplode;
    [SerializeField] private float waitForDestroy;
    private Animator animator;
    private bool isActive;
    private int IdIsActive;
    [SerializeField] private Transform transformBomb;
    [SerializeField] private float expansiveWaveRange;
    [SerializeField] private LayerMask isDestroyable;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        IdIsActive = Animator.StringToHash("isActive");
        transformBomb= GetComponent<Transform>();
    }

    private void Update()
    {
        waitForExplode -= Time.deltaTime;
        waitForDestroy -= Time.deltaTime;
        if (waitForExplode <= 0 && !isActive)
        {
            ActivatedBomb();
        }
        if (waitForDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void ActivatedBomb()
    {
        isActive = true;
        animator.SetBool(IdIsActive, isActive);
        Collider2D[] destroyableObjects = Physics2D.OverlapCircleAll(transformBomb.position, expansiveWaveRange, isDestroyable);
        if (destroyableObjects.Length > 0)
        {
            foreach (var col in destroyableObjects)
            {
                Destroy(col.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transformBomb.position, expansiveWaveRange);
    }
}
