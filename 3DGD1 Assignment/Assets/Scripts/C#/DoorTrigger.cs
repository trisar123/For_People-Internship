using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    public LayerMask pushObjects;
    Vector3 ogPos;
    public bool isOpen=false;

    private void Start()
    {
        ogPos = door.transform.position;
    }
    private void Update()
    {
        //to check for push block
        if (Physics.Raycast(transform.position + 0.1f * Vector3.down, Vector3.up, 1f, pushObjects))
        {
            isOpen = true;
        }
        else isOpen = false;
        
        if (isOpen)
        {
            //open door
            door.transform.position = ogPos + new Vector3(0, 2, 0);
        }
        else
        {
            door.transform.position = ogPos;
        }
    }
    /*
    void OnCollisionEnter(Collision col)
    {
        if (isOpen == false)
        {
            print("hi");
            print(col.gameObject.tag);
            print(col.gameObject);
            if(col.gameObject.tag=="Push block")
            {
                door.transform.position += new Vector3(0, 2, 0);
                print("1");
                isOpen = true;
            }
        }
            
    }

    void OnCollisionExit(Collision col)
    {
        if (isOpen == true)
        {
            if (col.gameObject.tag == "Push block")
            {
                door.transform.position -= new Vector3(0, -2, 0);
                isOpen = false;

            }
               
        }
    }
    */
}
