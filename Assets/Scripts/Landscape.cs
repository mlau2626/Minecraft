using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Minecraft/Block Dictionary", order = 1)]
public class Landscape: ScriptableObject
{
    [Serializable]
    public class LandscapeBlocks
    {
        public string name;
        public GameObject blockPrefab;
        public int hardness;
    }

    [SerializeField] LandscapeBlocks[] blocks;

    public Dictionary<string, LandscapeBlocks> blocksDict;

    private void OnEnable()
    {
        blocksDict = new Dictionary<string, LandscapeBlocks>();
        if (blocksDict != null)
        {
            
            foreach (var block in blocks)
            {
                blocksDict[block.name] = block;
            }
        }
    }

}

