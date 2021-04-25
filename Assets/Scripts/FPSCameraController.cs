using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    Vector3 oldMousePos = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse X");
        float yRot = Input.GetAxis("Mouse Y");



        Vector3 mouseDelta = Input.mousePosition - oldMousePos;
        oldMousePos = Input.mousePosition;

        Vector3 rotation = new Vector3(-yRot, xRot, 0);

        transform.Rotate(rotation);
        float clampedAngle = transform.rotation.eulerAngles.x;
        if (transform.rotation.eulerAngles.x > 60 && transform.rotation.eulerAngles.x < 90)
        {
            clampedAngle = 60f;
        }
        else if (transform.rotation.eulerAngles.x < 300 && transform.rotation.eulerAngles.x > 270)
        {
            clampedAngle = 300f;
        }

        //        transform.rotation =Quaternion.Euler( new Vector3(Mathf.Clamp(transform.rotation.eulerAngles.x, -60f, 60f), transform.rotation.eulerAngles.y, 0));
        transform.rotation = Quaternion.Euler(new Vector3(clampedAngle, transform.rotation.eulerAngles.y, 0));

        //Debug.Log("MouseDelta: " + mouseDelta);
        //Debug.Log("MousePos: " + oldMousePos);
    }
}
