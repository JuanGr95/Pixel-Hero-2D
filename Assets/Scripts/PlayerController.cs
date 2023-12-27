using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Sprites
    private GameObject standingPlayer;
    private GameObject ballPlayer;
    private float ballModeCounter;
    [SerializeField] private float waitForBallMode;

    //Player Movement
    [Header("Player Movement")]
    [SerializeField] private float moveSped;
    [SerializeField] private float jumpForce;
    private Rigidbody2D playerRB;
    [SerializeField] private Transform checkGroundPoint;
    private Transform transformPlayerController;
    [SerializeField] private LayerMask selectedLayerMask;
    private Animator animatorStandingPlayer, animatorBallPlayer;
    private bool isGrounded, isFlippedInX;
    private int IdSpeed, IdIsGrounded, IdShootArrow, IdCanDoubleJUmp;
    [SerializeField] private float isGroundedRange;

    //Player Shoot
    [Header("Player Shoot")]
    [SerializeField] private ArrowController arrowController;
    private Transform transformArrowPoint, transformBombPoint;
    [SerializeField] private GameObject prefabBomb;

    //Player Dust
    [Header("Player Dust")]
    [SerializeField] private GameObject dustJump;
    private Transform transformDustPoint;
    private bool isIdle, canDoubleJump;

    //Player Dash
    [Header("Player Dash")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    private float dashCounter;
    [SerializeField] private float waitForDash;
    private float afterDashCounter;


    [Header("Player Dash After Image")]
    [SerializeField] private SpriteRenderer playerSR;
    [SerializeField] private SpriteRenderer afterImageSR;
    [SerializeField] private float afterImageLifeTime;
    [SerializeField] private Color afterImageColor;
    [SerializeField] private float afterImageTimeBetween;
    private float afterImageCounter;

    //Player Extras
    private PlayerExtrasTracker playerExtrasTracker;

    private void Awake()
    {
        transformPlayerController = GetComponent<Transform>();
        playerRB = GetComponent<Rigidbody2D>();
        playerExtrasTracker = GetComponent<PlayerExtrasTracker>();
    }
    // Update is called once per frame

    private void Start()
    {
        standingPlayer = GameObject.Find("Standing Player");
        ballPlayer = GameObject.Find("BallPlayer");
        ballPlayer.SetActive(false);

        transformBombPoint = GameObject.Find("BombPoint").GetComponent<Transform>();
        transformDustPoint = GameObject.Find("DustPoint").GetComponent<Transform>();
        transformArrowPoint = GameObject.Find("ArrowPoint").GetComponent<Transform>();
        //checkGroundPoint = GameObject.Find("CheckGroundPoint").GetComponent<Transform>();
        animatorStandingPlayer = standingPlayer.GetComponent<Animator>();
        animatorBallPlayer = ballPlayer.GetComponent<Animator>();
        IdSpeed = Animator.StringToHash("speed");
        IdIsGrounded = Animator.StringToHash("isGrounded");
        IdShootArrow = Animator.StringToHash("shootArrow");
        IdCanDoubleJUmp = Animator.StringToHash("canDoubleJump");
    }
    void Update()
    {
        Dash();
        Jump();
        CheckAndSetDirection();
        Shoot();
        PlayDust();
        BallMode();
    }

    private void Dash()
    {
        if (afterDashCounter > 0)
        {
            afterDashCounter -= Time.deltaTime;
        }
        else
        {
            if ((Input.GetButtonDown("Fire2") && standingPlayer.activeSelf) && playerExtrasTracker.CanDash)
            {
                dashCounter = dashTime;
                ShowAfterImage();
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            playerRB.velocity = new Vector2(dashSpeed * transformPlayerController.localScale.x, playerRB.velocity.y);
            afterImageCounter -= Time.deltaTime;
            if (afterImageCounter <= 0)
            {
                ShowAfterImage();
            }
            afterDashCounter = waitForDash;
        }
        else
        {
            Move();
        }
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && standingPlayer.activeSelf)
        {
            ArrowController tempArrowController = Instantiate(arrowController, transformArrowPoint.position, transformArrowPoint.rotation);
            if (isFlippedInX)
            {
                tempArrowController.ArrowDirection = new Vector2(-1, 0f);
                tempArrowController.GetComponent<SpriteRenderer>().flipX= true; 
            }
            else
            {
                tempArrowController.ArrowDirection = new Vector2(1, 0f);
            }
            animatorStandingPlayer.SetTrigger(IdShootArrow);
        }
        if ((Input.GetButtonDown("Fire1") && ballPlayer.activeSelf) && playerExtrasTracker.CanDropBombs)
        {
            Instantiate(prefabBomb, transformBombPoint.position, Quaternion.identity);
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal") * moveSped;
        playerRB.velocity = new Vector2(inputX, playerRB.velocity.y);
        if (standingPlayer.activeSelf)
        {
            animatorStandingPlayer.SetFloat(IdSpeed, Mathf.Abs(playerRB.velocity.x));
        }
        if (ballPlayer.activeSelf)
        {
            animatorBallPlayer.SetFloat(IdSpeed, Mathf.Abs(playerRB.velocity.x));
        }
    }

    private void Jump()
    {
        //isGrounded = Physics2D.OverlapCircle(checkGroundPoint.position, isGroundedRange, selectedLayerMask);
        isGrounded = Physics2D.Raycast(checkGroundPoint.position, Vector2.down, isGroundedRange, selectedLayerMask);
        if (Input.GetButtonDown("Jump") && (isGrounded || (canDoubleJump && playerExtrasTracker.CanDoubleJump)))
        {
            if (isGrounded)
            {
                canDoubleJump = true;
                Instantiate(dustJump, transformDustPoint.position, Quaternion.identity);
            }
            else
            {
                canDoubleJump= false;
                animatorStandingPlayer.SetTrigger(IdCanDoubleJUmp);
            }
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }
            
        animatorStandingPlayer.SetBool(IdIsGrounded, isGrounded);
    }

    private void CheckAndSetDirection()
    {
        if (playerRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFlippedInX= true;
        }
        else if (playerRB.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
            isFlippedInX = false;
        }
    }

    private void PlayDust() 
    {
        if (playerRB.velocity.x != 0 && isIdle)
        {
            isIdle= false;
            if (isGrounded)
            {
                Instantiate(dustJump, transformDustPoint.position, Quaternion.identity);
            }
        }
        if (playerRB.velocity.x == 0)
        {
            isIdle = true;
        }
    }


    private void ShowAfterImage()
    {
        SpriteRenderer afterImage = Instantiate(afterImageSR, transformPlayerController.position, transformPlayerController.rotation);
        afterImage.sprite = playerSR.sprite;
        afterImage.transform.localScale = transformPlayerController.localScale;
        afterImage.color = afterImageColor;
        Destroy(afterImage.gameObject, afterImageLifeTime);
        afterImageCounter = afterImageTimeBetween;
    }

    private void BallMode()
    {
        float inputVertical = Input.GetAxisRaw("Vertical");
        if ((inputVertical <= -.9f && !ballPlayer.activeSelf || inputVertical >= .9f && ballPlayer.activeSelf) && playerExtrasTracker.CanEnterBallMode)
        {
            ballModeCounter -= Time.deltaTime;
            if (ballModeCounter < 0)
            {
                ballPlayer.SetActive(!ballPlayer.activeSelf);
                standingPlayer.SetActive(!standingPlayer.activeSelf);
            }
        }
        else
        {
            ballModeCounter = waitForBallMode;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(checkGroundPoint.position, isGroundedRange);
    }
}
