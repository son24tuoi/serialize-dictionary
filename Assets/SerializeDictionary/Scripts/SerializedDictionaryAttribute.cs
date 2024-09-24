using System;
using System.Diagnostics;
using UnityEngine;

namespace SerializedDictionary
{
    [Conditional("UNITY_EDITOR")]
    public class SerializedDictionaryAttribute : Attribute
    {
        public readonly string keyName;
        public readonly string valueName;

        public SerializedDictionaryAttribute(string keyName = null, string valueName = null)
        {
            this.keyName = keyName;
            this.valueName = valueName;
        }
    }
}