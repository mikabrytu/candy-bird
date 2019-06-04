using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameManager gameManager;
    private Animator animator;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            animator.SetInteger("animation", 9);
            gameManager.StopGame();
        }
    }

}
