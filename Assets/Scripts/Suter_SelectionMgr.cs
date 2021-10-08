using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suter_SelectionMgr : MonoBehaviour
{
    public Transform theDest;
    public GameObject Destination;
    private bool isHeld = false;
    public Material highlightMaterial;
    public Material defaultMaterial;
    private string selectableTag = "Selectable";
    private GameObject selectedObject;

    private Transform _selection;
   
    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                //if raycast hit and Left mouse button is held down:
                if (Input.GetMouseButton(0))
                {
                    selectedObject = hit.collider.gameObject;
                    Debug.Log("gameObject: " + selectedObject + "is held.");
                    isHeld = true;
                    selectedObject.gameObject.GetComponent<BoxCollider>().enabled = false;
                    selectedObject.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    hit.transform.position = theDest.position;
                    hit.transform.parent = GameObject.Find("Destination").transform;
                    
                    
                    Debug.Log("Pressed left click.");
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        Debug.Log("color change!");
                        selectionRenderer.material = highlightMaterial;
                    }
                }
                if (isHeld)
                {
                    selection.gameObject.transform.position = theDest.position;
                    Debug.Log("FOLLOW ME");
                }

                _selection = selection;
            }
           

        }
        if (Input.GetMouseButtonUp(0))
        {
            isHeld = false;

            Debug.Log("LET GO of gameObject: " + selectedObject);


        }

        if (isHeld == false && selectedObject != null)
        {
            Debug.Log("SELECTED OBJECT: " + selectedObject);
            selectedObject.transform.parent = null;
            selectedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Debug.Log("Mouse UP");
            selectedObject.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void LateUpdate()
    {
        if (isHeld)
        {
            transform.position = Destination.transform.position;
            //Debug.Log("transform.positon: " + transform.position + "...MainCamera1 position: " + MainCamera1.transform.position + "...offset: " + offset);
        }

    }
}
