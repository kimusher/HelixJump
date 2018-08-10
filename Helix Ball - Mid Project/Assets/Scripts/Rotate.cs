using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float sensitivityX = 8;

    //Camera that acts as a point of view to rotate the object relative to.
    Transform referenceCamera;


    void Start()
    {

        //Ensure the referenceCamera variable has a valid value before letting this script run.
        //If the user didn't set a camera manually, try to automatically assign the scene's Main Camera.
        if (!referenceCamera)
        {
            if (!Camera.main)
            {
                Debug.LogError(
                    "No Camera with 'Main Camera' as its tag was found. Please either assign a Camera to this script, or change a Camera's tag to 'Main Camera'.");
                Destroy(this);
                return;
            }

            referenceCamera = Camera.main.transform;
        }
    }

    //Update() is called once every frame, and should be used to run script that
    //should be doing something constantly. In this case, we potentially want to
    //rotate the object constantly if the user is always moving the mouse.
    void Update()
    {
        //Get how far the mouse has moved by using the Input.GetAxis().
        float rotationX = Input.GetAxis("Mouse X") * sensitivityX;

        transform.RotateAround(Vector3.up, -Mathf.Deg2Rad * rotationX);

    }

}


///this code is for ROTATING BY DRAGING THE MOUSE
/// 
//   private float speed = 20f;



    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //   }

    //   private void OnMouseDrag()
    //   {
    //       float rotateX = Input.GetAxis("Mouse X") * this.speed * Mathf.Deg2Rad;
    //       transform.RotateAround(Vector3.up, -rotateX);
    //   }

