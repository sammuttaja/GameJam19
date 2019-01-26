using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = StartPosition.position;
            other.gameObject.SetActive(true);

            Debug.Log(other.gameObject.transform.position);
        }
    }
}
