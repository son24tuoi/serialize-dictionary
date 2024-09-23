using System.Collections;
using System.Collections.Generic;
using SerializedDictionary;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    [SerializeField] private SerializedDictionary<string, int> dictionary = new SerializedDictionary<string, int>();
    [SerializeField] private List<SerializedKeyValuePair<string, int>> a = new List<SerializedKeyValuePair<string, int>>();

    private void Start()
    {
        dictionary["Hi"] = 5;
        dictionary.Add("Hello", 6);
    }
}
