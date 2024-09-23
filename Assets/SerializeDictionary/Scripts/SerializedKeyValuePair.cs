using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SerializedDictionary
{
    [Serializable]
    public struct SerializedKeyValuePair<TKey, TValue>
    {
        public TKey key;
        public TValue value;

        public SerializedKeyValuePair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
