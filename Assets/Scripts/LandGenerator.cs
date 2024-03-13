using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] int length;

    int bedrockDepth = -100;
    int minDiamondOreDepth = -20;
    float diamondOreChance = .05f;
    Dictionary<Vector3Int, int> worldArray; // make faster lookup

    [SerializeField] Landscape landscape;

    

    // Start is called before the first frame update
    void Start()
    {
        worldArray = new Dictionary<Vector3Int, int>();
        GenerateWorld();
        SpawnWorld2();
    }

    void GenerateWorld()
    {
        for (int h = -100; h < height; h++)
        {
            for(int w = -100; w < width; w++)
            {
                for( int l = -100; l < length; l++)
                {
                    Vector3Int pos = new Vector3Int(h, w, l);
                    worldArray[pos] = 0;

                    if (h == -100)
                    {
                        worldArray[pos] = landscape.blocksDict["bedrock"].blockId;
                    }
                    else if (h < -95 && Random.Range(0, 1.0f) > .5f)
                    {
                        if (worldArray[new Vector3Int(h - 1,w,l)] == landscape.blocksDict["bedrock"].blockId)
                        {
                            worldArray[pos] = landscape.blocksDict["bedrock"].blockId;
                        }
                    }
                    else
                    {
                        worldArray[pos] = landscape.blocksDict["stone"].blockId;
                    }
                    
                }
            }
        }
    }

    void SpawnWorld1()
    {
        for (int h = -100; h < height; h++)
        {
            for (int w = -100; w < width; w++)
            {
                for (int l = -100; l < length; l++)
                {
                    Vector3Int pos = new Vector3Int(h, w, l);
                    foreach(var kvp in landscape.blocksDict)
                    {
                        if (kvp.Value.blockId == worldArray[pos])
                        {
                            Instantiate(kvp.Value.blockPrefab,
                                pos,
                                kvp.Value.blockPrefab.transform.rotation);
                        }
                    }
                    
                    
                   

                }
            }
        }
    }

    void SpawnWorld2()
    {

    }
}
