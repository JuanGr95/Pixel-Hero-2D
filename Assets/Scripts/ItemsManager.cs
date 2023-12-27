using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerExtrasTracker playerExtrasTracker;
    [SerializeField] private int _doubleJumpItemCounter, _dashItemCounter, _BallMode_BombItemCounter;
    [SerializeField] private int _doubleJumpUnlockerThreshold, _dashUnlockerThreshold, _ballMode_BombUnlockerThreshold;
    [Header("Item Move And Fade")]
    [SerializeField] private float _fadeAndMoveDuration;
    [SerializeField] private float _moveDistance;

    public int DoubleJumpItemCounter { get => _doubleJumpItemCounter; set => _doubleJumpItemCounter = value; }
    public int DashItemCounter { get => _dashItemCounter; set => _dashItemCounter = value; }
    public int BallMode_BombItemCounter { get => _BallMode_BombItemCounter; set => _BallMode_BombItemCounter = value; }
    public float FadeAndMoveDuration { get => _fadeAndMoveDuration; set => _fadeAndMoveDuration = value; }
    public float MoveDistance { get => _moveDistance; set => _moveDistance = value; }
    public int DoubleJumpUnlockerThreshold { get => _doubleJumpUnlockerThreshold; set => _doubleJumpUnlockerThreshold = value; }
    public int DashUnlockerThreshold { get => _dashUnlockerThreshold; set => _dashUnlockerThreshold = value; }
    public int BallMode_BombUnlockerThreshold { get => _ballMode_BombUnlockerThreshold; set => _ballMode_BombUnlockerThreshold = value; }



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerExtrasTracker = player.GetComponent<PlayerExtrasTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DoubleJumpItemCounter == DoubleJumpUnlockerThreshold)
        {
            playerExtrasTracker.CanDoubleJump = true;
        }
        if (DashItemCounter == DashUnlockerThreshold)
        {
            playerExtrasTracker.CanDash = true;
        }
        if (BallMode_BombItemCounter == BallMode_BombUnlockerThreshold)
        {
            playerExtrasTracker.CanEnterBallMode = true;
            playerExtrasTracker.CanDropBombs = true;
        }

    }
}
