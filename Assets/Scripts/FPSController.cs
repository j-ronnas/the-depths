using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{

    Rigidbody rb;
    Transform cameraRig;
    float walkingSpeed = 5f;

    AudioSource footSounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraRig = GetComponentInChildren<FPSCameraController>().transform;
        footSounds = GetComponentInChildren<AudioSource>();
    }

    Vector3 velocity;
    
    // Update is called once per frame
    void Update()
    {
        float forwardDir = Input.GetAxis("Vertical");
        float rightDir = Input.GetAxis("Horizontal");

        Vector3 forwardVector = new Vector3(cameraRig.transform.forward.x, 0, cameraRig.transform.forward.z);
        Vector3 rightVector = new Vector3(cameraRig.transform.right.x, 0, cameraRig.transform.right.z);
        Vector3 downVector = new Vector3(0, rb.velocity.y, 0);

        footSounds.mute = forwardDir == 0 && rightDir == 0;

        rb.velocity = downVector + (forwardDir * forwardVector + rightDir * rightVector).normalized * walkingSpeed ;


        Ray ray = new Ray(cameraRig.transform.position, cameraRig.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 7f))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                Interactable inter = hitInfo.collider.transform.GetComponentInParent<Interactable>();
                if(inter != null)
                {
                    inter.Interact();
                }
            }
        }

    }
}
