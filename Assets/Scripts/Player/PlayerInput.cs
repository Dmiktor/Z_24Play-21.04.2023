using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public static event Action OnPlayerStartsToPlay;
    public static event Action OnPlayerDropsToPlay;

    private PlayerMovement playerMovement;
    private bool playerIsTouching = false;
    private float initialTouchXPosition;
    private const float horizontalLimit = 2.0f;
    private float screenHorizontalMultiplier = 5f / Screen.width;
    private float touchX;

    private void OnEnable()
    {
        PlayerCollisions.OnPlayerHitTheWall += HandlePlayerHitTheWall;
    }   

    private void OnDisable()
    {
        PlayerCollisions.OnPlayerHitTheWall -= HandlePlayerHitTheWall;
    } 
    private void Awake()    
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        HandleTouch();

    }

    private void FixedUpdate()
    {
        HandleMoving();
    }

    private void HandleTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                playerIsTouching = true;
                OnPlayerStartsToPlay?.Invoke();
                touchX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                playerIsTouching = false;
                OnPlayerDropsToPlay?.Invoke();
                HandlePlayerHitTheWall();
            }
        }
    }
    private void HandleMoving()
    {
        if (!playerIsTouching)
        {
            return;
        }

        float targetX = Mathf.Clamp((Input.GetTouch(0).position.x - touchX) / Screen.width * 5f, -2.0f, 2.0f);
   
        playerMovement.Move(targetX);
    }

    private void HandlePlayerHitTheWall()
    {
        this.enabled = false;
    }
}