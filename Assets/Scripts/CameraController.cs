using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController playerController;
    private Transform camTransform;
    private Transform playerTransform;
    private BoxCollider2D levelLimit;
    private float cameraSizeVertical;
    private float cameraSizeHorizontal; 

    // Start is called before the first frame update
    void Start()
    {
        levelLimit= GameObject.Find("LevelLimit").GetComponent<BoxCollider2D>();
        camTransform = GetComponent<Transform>();
        playerController = FindObjectOfType<PlayerController>();
        playerTransform = playerController.GetComponent<Transform>();
        cameraSizeVertical = Camera.main.orthographicSize;
        cameraSizeHorizontal = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerTransform != null)
        {
            
            camTransform.position = new Vector3(
                Mathf.Clamp(playerTransform.position.x, levelLimit.bounds.min.x + cameraSizeHorizontal, levelLimit.bounds.max.x - cameraSizeHorizontal),
                Mathf.Clamp(playerTransform.position.y, levelLimit.bounds.min.y + cameraSizeVertical, levelLimit.bounds.max.y - cameraSizeVertical),
                camTransform.position.z);
        }
    }
}
