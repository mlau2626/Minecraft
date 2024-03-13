using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] int depth;

    [SerializeField] Landscape landscape;
    // Start is called before the first frame update
    void Start()
    {
        GenerateWorld();
    }

    void GenerateWorld()
    {
        Debug.Log(landscape.blocksDict);
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                for( int k = 0; k < depth; k++)
                {
                    Vector3Int pos = new Vector3Int(i, j, k);
                    
                    Instantiate(landscape.blocksDict["grass"].blockPrefab, pos, landscape.blocksDict["grass"].blockPrefab.transform.rotation);
                }
            }
        }
    }
}
