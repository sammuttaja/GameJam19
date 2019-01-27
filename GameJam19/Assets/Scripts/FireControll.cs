using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControll : MonoBehaviour
{
    public GameObject FireEffect;
    public List<GameObject> furnices = new List<GameObject>();
    public float intervalTime = 2f;
    public GameObject RotatingFire;

    int index = 0;

    private void Start()
    {
        RotatingFire.SetActive(true);
        StartCoroutine(startFire());
    }

    Coroutine fire;

    // Update is called once per frame
    void Update()
    {
        if (Time.time % intervalTime == 0 && index != furnices.Count)
        {
           
            index++;
        }
    }

    IEnumerator startFire()
    {
        for (int i = 0; i < furnices[index].transform.childCount; i++)
        {
            yield return new WaitForSeconds(intervalTime);

            furnices[index].GetComponent<ActivateFlames>().SetFlames(true);
        }
    }

    private void OnDisable()
    {
        RotatingFire.SetActive(false);
        StopCoroutine(fire);

        for (int i = 0; i < furnices[index].transform.childCount; i++)
        {
            furnices[index].transform.GetChild(i).GetComponent<ActivateFlames>().SetFlames(false);


        }
    }
}
