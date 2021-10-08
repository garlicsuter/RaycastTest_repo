using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPlain : MonoBehaviour
{
    public Transform theDest;

    public GameObject MainCamera1;
    public GameObject Destination;
    private Vector3 offset;
    private bool isHeld = false;

    Camera cam;
    //Vector3 pos = new Vector3(200, 200, 0);
    Vector3 crosshairloc = new Vector3(Screen.width / 2, Screen.height / 2);


    //private void Update()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(Camera.main.transform.position, crosshairloc, out hit, 100f))
    //    {
    //        isHeld = true;
    //        GetComponent<BoxCollider>().enabled = false;
    //        GetComponent<Rigidbody>().useGravity = false;
    //        this.transform.position = theDest.position;
    //        this.transform.parent = GameObject.Find("Destination").transform;

    //        if (hit.collider.gameObject.tag == "Grabbable")
    //        {
    //            Debug.Log("Hit a GRABBABLE!");
    //        }
    //    }
    //}

    void OnMouseDown()
    {
        isHeld = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        Debug.Log("MOUSE DOWN! I REPEAT, MOUSE IS DOWN!");
    }


    void OnMouseUp()
    {
        isHeld = false;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        Debug.Log("Mouse UP");
        GetComponent<BoxCollider>().enabled = true;
    }

    void LateUpdate()
    {
        if (isHeld)
        {
            transform.position = Destination.transform.position;
            Debug.Log("transform.positon: " + transform.position + "...MainCamera1 position: " + MainCamera1.transform.position + "...offset: " + offset);
        }

    }

    //void LateUpdate()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("Pressed primary button.");
    //        transform.position = theDest.transform.position;
    //    }


}
