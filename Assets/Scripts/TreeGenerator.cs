using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject treePrefab;
    [SerializeField]
    float radius;
    [SerializeField]
    int numberOfTrees;
    [SerializeField]
    float maxHeighCheck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 discPos;
    public void GenerateTree()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        Debug.Log("Generating trees");
        for (int i = 0; i < numberOfTrees; i++)
        {
            Debug.Log("Trying to Spawning Tree");
            float angle = Random.Range(0f, 2*Mathf.PI);

            discPos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle))*Random.Range(0f, radius);
            RaycastHit hitInfo;
            if(Physics.Raycast(transform.position + discPos + Vector3.up * maxHeighCheck,Vector3.down, out hitInfo))
            {
                Debug.Log("Spawning Tree");
                GameObject treeGo = Instantiate(treePrefab, hitInfo.point, Quaternion.Euler(new Vector3(0,Random.Range(0,360),0)), this.transform);
            }
            
        }
    }

}
