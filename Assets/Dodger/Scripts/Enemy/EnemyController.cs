using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private GameObject collisionEffect;

    private GameObject particleManager;
    private ScoreController scoreController;

    void Start()
    {
        scoreController = GameObject.Find("Canvas").GetComponent<ScoreController>();
        particleManager = GameObject.Find("Particle Manager");
    }
    
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ground")
            scoreController.IncreaseScore();
            
        GameObject clone = Instantiate(collisionEffect, transform.position, collisionEffect.transform.rotation);
        clone.transform.parent = particleManager.transform;
        Destroy(gameObject, 0.1f);
    }

}
