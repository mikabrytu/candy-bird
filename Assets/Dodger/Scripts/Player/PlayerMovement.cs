using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    // Debug
    public float min;
    public float max;

    private Camera camera;
    private GameManager gameManager;
    private Rigidbody body;
    private Animator animator;
    private Vector3 touchPosition;
    private int[] animations = {1, 2, 3, 10, 13};
    private float animationTimer;
    private bool moving = false;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        animationTimer = Random.Range(1.5f, 4f);
    }

    void Update()
    {
        if (gameManager.GetCurrentScene() == GameManager.Scene.Menu)
        {
            if (animationTimer <= 0)
            {
                animationTimer = Random.Range(1.5f, 4f);
                animator.SetInteger("animation", animations[Random.Range(0, animations.Length)]);
            } else {
                animationTimer -= Time.deltaTime;
            }
        }

#if UNITY_EDITOR
        if (gameManager.GetCurrentScene() == GameManager.Scene.Game)
        {
            if (Input.GetMouseButtonDown(0))
                moving = true;
            else if (Input.GetMouseButtonUp(0))
            {
                moving = false;
                animator.SetInteger("animation", 1);
            }
        }
#else
        if (gameManager.GetCurrentScene() == GameManager.Scene.Game)
        {
            
            if (Input.touchCount > 0)
            {
                moving = true;
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                    touchPosition = touch.position;

                if (touch.phase == TouchPhase.Ended)
                {
                    moving = false;
                    animator.SetInteger("animation", 1);
                }
            }
        }
#endif
    }

    void FixedUpdate()
    {
#if UNITY_EDITOR
        if (gameManager.IsRunning() && moving)
        {
            /* The direction detection is inverted cause the bird model in 0 rotation 
            * is facing the same direction as the camera. To avoid a mess with rotations, 
            * I just inverted the direction of movement.
            * TODO: Rotate the model without break movement
            */
            if (Input.GetAxis("Mouse X") < 0)
            {
                Move(Vector3.right);
                animator.SetInteger("animation", 18);
            }

            if (Input.GetAxis("Mouse X") > 0)
            {
                Move(Vector3.left);
                animator.SetInteger("animation", 19);
            }
        }
#else
        if (gameManager.IsRunning() && moving)
        {
            var playerPos = camera.WorldToScreenPoint(transform.position);
            if (touchPosition.x < playerPos.x)
            {
                Move(Vector3.right);
                animator.SetInteger("animation", 18);
            }

            if (touchPosition.x > playerPos.x)
            {
                Move(Vector3.left);
                animator.SetInteger("animation", 19);
            }
        }
#endif
    }

    private void Move(Vector3 direction)
    {
        var pos = Camera.main.WorldToViewportPoint(body.position);
        pos.x = Mathf.Clamp(pos.x, min, max);
        pos.y = Mathf.Clamp(pos.y, 0.1f, 0.9f);
        
        body.MovePosition(Camera.main.ViewportToWorldPoint(pos) + direction * speed * Time.deltaTime);
    }
}
