using System.Collections;
using System.Collections.Generic;
using SerializedDictionary;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    [SerializeField] private SerializedDictionary<string, int> dictionary = new SerializedDictionary<string, int>();
    [SerializeField] private List<SerializedKeyValuePair<string, int>> a = new List<SerializedKeyValuePair<string, int>>();
    [SerializeField] private int index;

    private void Start()
    {
        dictionary["Hi"] = 5;
        dictionary.Add("Hello", 6);
        Debug.Log(dictionary.Count);
    }

    private void OnGUI()
    {
        foreach (var kvp in dictionary)
        {
            GUILayout.Label("Key: " + kvp.Key + " value: " + kvp.Value);
        }
    }
}
