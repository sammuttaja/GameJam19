using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{

    public GameObject DayTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            DayTime.SetActive(true);
            DayTime.GetComponent<DayMovement>().ChangeToDay();
        }
    }

}
