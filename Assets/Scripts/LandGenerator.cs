
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    [SerializeField] int width = 32;
    [SerializeField] int height = 0;
    [SerializeField] int length = 32;

    int bedrockDepth = -86;
    int minDiamondOreDepth = -82;
    float diamondOreChance = .05f;
    Dictionary<Vector3Int, string> chunkArray; // make faster lookup

    [SerializeField] Landscape landscape;

    

    // Start is called before the first frame update
    void Start()
    {
        chunkArray = new Dictionary<Vector3Int, string>();
        GenerateChunk();
        SpawnChunk2();
    }

    void GenerateChunk()
    {
        List<string> choices = new List<string>();
        for (int x = 0; x < length; x++)
        {
            for(int z = 0; z < width; z++)
            {
                for( int y = bedrockDepth; y < height; y++)
                {
                    Vector3Int pos = new Vector3Int(x, y, z);
                    chunkArray[pos] = null;

                    if (y == bedrockDepth)
                    {
                        chunkArray[pos] = landscape.blocksDict["bedrock"].name;
                    }
                    else if (y < minDiamondOreDepth)
                    {
                        choices.Clear();
                        choices = new List<string>() { "stone", "diamond_ore", "coarse_dirt" };
                        if (Random.Range(0, 1.0f) > .7f)
                        {
                            if (chunkArray[new Vector3Int(x, y - 1, z)] == landscape.blocksDict["bedrock"].name)
                            {
                                chunkArray[pos] = landscape.blocksDict["bedrock"].name;
                            }
                            else
                            {
                                chunkArray[pos] = landscape.blocksDict["stone"].name;
                            }
                        }
                        else
                        {
                            int index = Random.Range(0, choices.Count);
                            chunkArray[pos] = landscape.blocksDict[choices[index]].name;
                        }
                        
                    }
                    else if (y < -10)
                    {
                        choices.Clear();
                        choices = new List<string> { "stone", "sand", "coarse_dirt", "sandstone"};
                        foreach (var label in choices) { Debug.Log(label); }
                        int index = Random.Range(0, choices.Count);
                        chunkArray[pos] = landscape.blocksDict[choices[index]].name;
                    }
                    else if (y < -1)
                    {
                        chunkArray[pos] = landscape.blocksDict["dirt"].name;
                    }
                    else
                    {
                        chunkArray[pos] = landscape.blocksDict["grass"].name;
                    }
                    
                }
            }
        }
    }

    void SpawnChunk1()
    {
        for (int x = -50; x < length; x++)
        {
            for (int z = -50; z < width; z++)
            {
                for (int y = -50; y < height; y++)
                {
                    Vector3Int pos = new Vector3Int(x, y, z);
                    foreach(var kvp in landscape.blocksDict)
                    {
                        if (kvp.Value.name == null) { continue; }
                        if (kvp.Value.name == chunkArray[pos])
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

    void SpawnChunk2()
    {
        foreach(var kvp in chunkArray)
        {
            if (kvp.Value != null)
            {
                Instantiate(landscape.blocksDict[kvp.Value].blockPrefab,
                            kvp.Key,
                            landscape.blocksDict[kvp.Value].blockPrefab.transform.rotation);
            }
        }
    }
}
