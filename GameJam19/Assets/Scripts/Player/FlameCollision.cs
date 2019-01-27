using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCollision : MonoBehaviour
{

    public Transform StartPosition;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Fire"))
        {
            gameObject.SetActive(false);
            transform.position = StartPosition.position;
            gameObject.SetActive(true);
        }
    }
}
