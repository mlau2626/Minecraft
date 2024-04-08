using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowTree : MonoBehaviour
{
    public GameObject trunkBlock;
    public GameObject leavesBlock;

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int growPoint = new Vector3(-3, -4, -5);
        GameObject block = Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
        growPoint += new Vector3Int(0, 1, 0);
        block = Instantiate(trunkBlock, growPoint, trunkBlock.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

