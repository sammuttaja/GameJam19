using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayMovement : MonoBehaviour
{

    [System.Serializable]
    public class DayObjects
    {
        public GameObject obj;
        public int Amount;
    }

    public float speed = 10f;
    public List<DayObjects> Furnices = new List<DayObjects>();
    public GameObject NightCharacter;
    public Transform StartLocation;
    public GameObject DayTimeUI;
    public GameObject Floor;
    [Header(header: "Light settings")]
    public GameObject Light;
    public Vector3 NightDirection;
    public Vector3 DayDirection;

    [Header(header: "Night Platforms")]
    public GameObject startPlatform;
    public GameObject EndPlatform;

    [Header(header: "Falling night")]
    public GameObject FallObject;

    [Header(header: "Fire night")]
    public GameObject FireController;

    private GameObject PickedObject;
    private List<GameObject> PlacedOBjects = new List<GameObject>();
    float timer = 0;
    private Camera cam;
    private bool picked = false;

    public void SetFurnice(int index)
    {
        int currentIndex = index;
        if(index == 0)
        {
            currentIndex += Random.Range(0, 2);
        }
        else if(index == 4)
        {
            currentIndex += Random.Range(0, 1);
        }
        PickedObject = Instantiate(Furnices[currentIndex].obj);
        picked = true;
        timer = 0.1f;
    }

    [SerializeField]
    private int doneLevels = 0;

    public void ChangeToNight()
    {
        Light.transform.rotation = Quaternion.Euler(NightDirection);
        int randomModes = Random.Range(1, 3);

        ///Putoavat huonekalut
        if (randomModes == 2)
            FallingNight();
        switch (randomModes)
        {
            case 1:
                JumpNight();
                break;
            case 2:
                FallingNight();
                break;
            case 3:
                FireNight();
                break;
        }

        ///jos 1 niin normi yö

        DayTimeUI.SetActive(false);
        NightCharacter.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().DisableMouseLock(true);

        NightCharacter.SetActive(true);
        foreach (var item in PlacedOBjects)
        {
            item.GetComponent<Collider>().enabled = true;
            if (item.name.Contains("chair"))
                item.transform.Rotate(new Vector3(0, 0, 1), 90f);
        }
        this.gameObject.SetActive(false);
    }

    private void JumpNight()
    {
        startPlatform.SetActive(true);
        EndPlatform.SetActive(true);
        Floor.SetActive(false);

    }

    private void FallingNight()
    {
        startPlatform.SetActive(true);
        EndPlatform.SetActive(true);
        Floor.SetActive(false);

        FallObject.SetActive(true);
    }

    private void FireNight()
    {
        FireController.SetActive(true);
        FireController.GetComponent<FireControll>().furnices = PlacedOBjects;
    }

    public void ChangeToDay()
    {
        doneLevels++;
        startPlatform.SetActive(false);
        EndPlatform.SetActive(false);
        if (FireController.activeSelf)
            FireController.SetActive(false);

        Floor.SetActive(true);
        Light.transform.rotation = Quaternion.Euler(DayDirection);
        if (FallObject.activeSelf)
            FallObject.SetActive(false);

        DayTimeUI.SetActive(true);
        NightCharacter.transform.position = StartLocation.position;

        NightCharacter.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().DisableMouseLock(false);
        NightCharacter.SetActive(false);
        
        foreach(GameObject obj in PlacedOBjects)
        {
            obj.GetComponent<Collider>().enabled = false;
        }
    }

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (picked)
        {
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit planePos))
            {
                Vector3 pos = cam.ScreenToWorldPoint(planePos.point);
                Debug.Log(pos);
                pos.y = 0.5f;
                PickedObject.transform.position = pos;
            }

            if (Input.GetMouseButtonDown(0) && timer <= 0)
            {
                picked = false;
                PlacedOBjects.Add(PickedObject);
                if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)){
                    PickedObject.transform.position = hit.point;// + new Vector3(0, PickedObject.GetComponent<Collider>().bounds.extents.y, 0);

                }
            }
            timer -= Time.deltaTime;
        }
    }
}
