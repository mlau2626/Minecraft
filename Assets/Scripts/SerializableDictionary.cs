using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[Serializable]
public class SerializableDictionary<Tkey, TValue> : Dictionary<Tkey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<Tkey> keys = new List<Tkey>();

    [SerializeField]
    private List<TValue> values = new List<TValue>();

    // Save dictionary to lists
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach(KeyValuePair<Tkey, TValue> kvp in this)
        {
            keys.Add(kvp.Key);
            values.Add(kvp.Value);
        }
    }

    // Load dictionary from lists
    public void OnAfterDeserialize()
    {
        this.Clear();
        
        if(keys.Count != values.Count)
        {
            throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable.", keys.Count, values.Count));
        }

        for(int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}