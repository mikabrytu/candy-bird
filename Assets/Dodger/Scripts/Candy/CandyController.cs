using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyController : MonoBehaviour
{

    [SerializeField]
    private GameObject successEffect;
    [SerializeField]
    private GameObject failEffect;

    private CandyManager manager;
    private GameObject particleManager;

    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<CandyManager>();
        particleManager = GameObject.Find("Particle Manager");
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            manager.AddCandy();
            GameObject clone = Instantiate(successEffect, transform.position, successEffect.transform.rotation);
            clone.transform.parent = particleManager.transform;
        } else {
            GameObject clone = Instantiate(failEffect, transform.position, failEffect.transform.rotation);
            clone.transform.parent = particleManager.transform;
        }

        Destroy(gameObject);
    }

}
