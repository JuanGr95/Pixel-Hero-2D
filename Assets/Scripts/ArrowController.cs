using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D arrowRB;
    [SerializeField]
    private float arrowSpeed;  
    private Vector2 _arrowDirection;

    public Vector2 ArrowDirection { get => _arrowDirection; set => _arrowDirection = value; }

    [SerializeField] private GameObject arrowImpact, arrowEnemyImpact;
    private Transform transformArrow; 

    private void Awake()
    {
        arrowRB = GetComponent<Rigidbody2D>();
        transformArrow = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        arrowRB.velocity = ArrowDirection * arrowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Instantiate(arrowEnemyImpact, transformArrow.position, Quaternion.identity);
        }
        else
        {
            Instantiate(arrowImpact, transformArrow.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
}
