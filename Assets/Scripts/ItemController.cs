using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private GameObject player, items;
    [SerializeField] private PlayerExtrasTracker playerExtrasTracker;
    [SerializeField] private ItemsManager itemsManager;

    private void Start()
    {
        player = GameObject.Find("Player");
        items = GameObject.Find("Items");
        playerExtrasTracker = player.GetComponent<PlayerExtrasTracker>();
        itemsManager = items.GetComponent<ItemsManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UpdateThreshold();
            StartCoroutine(MoveAndFade());
        }
    }

    private void UpdateThreshold()
    {

        if (gameObject.CompareTag("ItemDoubleJumpAbility"))
        {
            itemsManager.DoubleJumpItemCounter++;
        }
        else if (gameObject.CompareTag("ItemDashAbility"))
        {
            itemsManager.DashItemCounter++;
        }
        else if (gameObject.CompareTag("ItemBallMode&BombAbility"))
        {
            itemsManager.BallMode_BombItemCounter++;
        }

    }

    IEnumerator MoveAndFade()
    {
        Vector2 originalPosition = transform.position;
        float elapsedTime = 0.0f;
        Color originalColor = GetComponent<Renderer>().material.color;
        while (elapsedTime < itemsManager.FadeAndMoveDuration)
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / itemsManager.FadeAndMoveDuration);
            float moveAmount = Mathf.Lerp(0.0f, itemsManager.MoveDistance, elapsedTime / itemsManager.FadeAndMoveDuration);
            GetComponent<Renderer>().material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            transform.position = originalPosition + Vector2.up * moveAmount;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

}
