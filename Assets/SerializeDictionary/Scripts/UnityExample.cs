using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityExample : MonoBehaviour, ISerializationCallbackReceiver
{
    public List<int> _keys = new List<int> { 3, 4, 5 };
    public List<string> _values = new List<string> { "I", "Love", "Unity" };

    //Unity doesn't know how to serialize a Dictionary
    public Dictionary<int, string> _myDictionary = new Dictionary<int, string>();

    private void Start()
    {
        _myDictionary.Add(1, "Hi");
        _myDictionary.Add(2, "Hello");
    }

    public void OnBeforeSerialize()
    {
        _keys.Clear();
        _values.Clear();

        foreach (var kvp in _myDictionary)
        {
            _keys.Add(kvp.Key);
            _values.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        _myDictionary = new Dictionary<int, string>();

        for (int i = 0; i != Mathf.Min(_keys.Count, _values.Count); i++)
            _myDictionary.Add(_keys[i], _values[i]);
    }

    void OnGUI()
    {
        foreach (var kvp in _myDictionary)
            GUILayout.Label("Key: " + kvp.Key + " value: " + kvp.Value);
    }
}
