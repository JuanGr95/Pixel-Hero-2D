using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtrasTracker : MonoBehaviour
{
    [SerializeField] private bool _canDoubleJump, _canDash, _canEnterBallMode, _canDropBombs;

    public bool CanDash { get => _canDash; set => _canDash = value; }
    public bool CanDoubleJump { get => _canDoubleJump; set => _canDoubleJump = value; }
    public bool CanEnterBallMode { get => _canEnterBallMode; set => _canEnterBallMode = value; }
    public bool CanDropBombs { get => _canDropBombs; set => _canDropBombs = value; }
}
