using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class UIManager : MonoBehaviour
{
    [SerializeField] private ItemsManager itemsManager;
    void Awake()
    {
        itemsManager = gameObject.GetComponent<ItemsManager>();
    }


    void OnGUI()
    {
        int dashItemsLeft = itemsManager.DashUnlockerThreshold - itemsManager.DashItemCounter;
        int doubleJumpItemsLeft = itemsManager.DoubleJumpUnlockerThreshold - itemsManager.DoubleJumpItemCounter;
        int ballModeBombItemsLeft = itemsManager.BallMode_BombUnlockerThreshold - itemsManager.BallMode_BombItemCounter;

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24;

        GUI.Label(new Rect(10, 10, 300, 50), "Double Jump Left: " + doubleJumpItemsLeft.ToString(), style);
        GUI.Label(new Rect(10, 40, 300, 50), "Dash Left: " + dashItemsLeft.ToString(), style);
        GUI.Label(new Rect(10, 70, 300, 50), "Ball & Bomb Left: " + ballModeBombItemsLeft.ToString(), style);
    }


}
