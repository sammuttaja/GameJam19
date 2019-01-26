using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayMovement : MonoBehaviour
{

    public float speed = 10f;
    public List<GameObject> Furnices = new List<GameObject>();
    public GameObject NightCharacter;
    

    private GameObject PickedObject;
    private List<GameObject> PlacedOBjects = new List<GameObject>();
    float timer = 0;
    private Camera cam;
    private bool picked = false;

    public void SetFurnice(int index)
    {
        PickedObject = Instantiate(Furnices[index]);
        picked = true;
        timer = 1f;
    }

    public void ChangeToNight()
    {
        NightCharacter.SetActive(true);
        foreach (var item in PlacedOBjects)
        {
            item.GetComponent<Collider>().enabled = true;
        }
        this.gameObject.SetActive(false);
    }

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizon * Time.deltaTime * speed, vertical * Time.deltaTime * speed, 0));

        if (picked)
        {
            PickedObject.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
            
            if (Input.GetMouseButtonDown(0) && timer <= 0)
            {
                picked = false;
                PlacedOBjects.Add(PickedObject);
                if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)){
                    PickedObject.transform.position = hit.point + new Vector3(0, PickedObject.GetComponent<Collider>().bounds.extents.y, 0);

                }
            }
            timer -= Time.deltaTime;
        }
    }
}
