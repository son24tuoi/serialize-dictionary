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

        // Hàm chạy trước khi tuần tự hóa
        // Hiển thị trên Inspector qua serializedList
        // Sao chép dữ liệu của dictionary sang serializedList
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            serializedList.Clear();

            foreach (var kvp in this)
            {
                serializedList.Add(new SerializedKeyValuePair<TKey, TValue>(kvp.Key, kvp.Value));
            }
#endif
        }

        // Hàm chạy sau khi hủy tuần tự hóa
        // Cập nhật dữ liệu cho dictionary
        // Sao chép dữ liệu của serializedList sang dictionary
        public void OnAfterDeserialize()
        {
#if UNITY_EDITOR
            base.Clear();

            foreach (var kvp in serializedList)
            {
                if (!base.ContainsKey(kvp.key))
                    base.Add(kvp.key, kvp.value);
                // serializedList.Add(new SerializedKeyValuePair<TKey, TValue>(kvp.key, kvp.value));
                // base.Add(kvp.key, kvp.value);
            }
#endif
        }

        // public new void Add(TKey key, TValue value)
        // {
        //     base.Add(key, value);
        //     serializedList.Add(new SerializedKeyValuePair<TKey, TValue>(key, value));
        // }

    }
}