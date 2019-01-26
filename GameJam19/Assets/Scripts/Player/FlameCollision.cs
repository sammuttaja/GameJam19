using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCollision : MonoBehaviour
{

    public Transform StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Fire"))
        {
            gameObject.SetActive(false);
            transform.position = StartPosition.position;
            gameObject.SetActive(true);
        }
    }

    private void OnParticleTrigger()
    {
        gameObject.SetActive(false);
        transform.position = StartPosition.position;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Fire"))
        {
            
        }
    }
}
