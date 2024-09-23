using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializedDictionary
{
    [Serializable]
    public class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] private List<SerializedKeyValuePair<TKey, TValue>> serializedList = new List<SerializedKeyValuePair<TKey, TValue>>();
#endif

        public void OnAfterDeserialize()
        {
#if UNITY_EDITOR
            base.Clear();

            foreach (var kvp in serializedList)
            {
                if (!ContainsKey(kvp.key))
                    base.Add(kvp.key, kvp.value);
                // serializedList.Add(new SerializedKeyValuePair<TKey, TValue>(kvp.key, kvp.value));
                // base.Add(kvp.key, kvp.value);
            }
#endif
        }

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            foreach (var kvp in this)
            {
                serializedList.Add(new SerializedKeyValuePair<TKey, TValue>(kvp.Key, kvp.Value));
            }
#endif
        }

        
    }
}