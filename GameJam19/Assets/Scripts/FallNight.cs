using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallNight : MonoBehaviour
{

    public List<GameObject> FallingGameobjects = new List<GameObject>();
    public float SpawnRate = 0.4f;
    public List<Transform> SpawnPositions = new List<Transform>();
    private Collider FallZone;

    Coroutine refObject;

    // Start is called before the first frame update
    void Start()
    {
        FallZone = GetComponent<Collider>();
        refObject = StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Time.time % SpawnRate == 0)
        {
            GameObject s = Instantiate(FallingGameobjects[Random.Range(0, FallingGameobjects.Count)]);
            s.AddComponent<Rigidbody>();
            s.transform.position = FallNight.RandomPoinInBox(FallZone.bounds.center, FallZone.bounds.size);
            Destroy(s, 5);
        }*/
    }

    IEnumerator SpawnObjects()
    {
        int index = 0;
        while (true)
        {
            GameObject s = Instantiate(FallingGameobjects[Random.Range(0, FallingGameobjects.Count - 1)]);
            s.AddComponent<FallingNightMovement>();

            s.transform.position = SpawnPositions[index % (SpawnPositions.Count - 1)].position;
            Destroy(s, 5);
            index++;
            yield return new WaitForSeconds(SpawnRate);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(refObject);
    }
}
