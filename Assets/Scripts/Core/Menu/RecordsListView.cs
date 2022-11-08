using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsListView : MonoBehaviour
{
    [SerializeField] private RecordView _recordPrefab;
    [SerializeField] private Transform _parent;

    public void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            _recordPrefab.Init("Test" + i, Random.Range(1214, 8090));
            Instantiate(_recordPrefab, _parent);
        }
    }
}
