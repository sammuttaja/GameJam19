using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFlames : MonoBehaviour
{

    public GameObject Flames;
    // Start is called before the first frame update
    public void SetFlames(bool value)
    {
        Flames.SetActive(value);
    }
}
