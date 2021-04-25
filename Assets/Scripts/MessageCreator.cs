using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCreator : MonoBehaviour
{

    [SerializeField]
    GameObject messagePrefab;
    Transform cameraRig;
    // Start is called before the first frame update
    void Start()
    {
        cameraRig = GetComponentInChildren<FPSCameraController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cameraRig.transform.position, cameraRig.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 3f))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Spawning Message");
                Quaternion rot = Quaternion.LookRotation(-hitInfo.normal);
                Instantiate(messagePrefab, hitInfo.point + 0.01f * hitInfo.normal, rot);
            }
        }
    }
}
