using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsListView : MonoBehaviour
{
    [SerializeField] private RecordView _recordPrefab;
    [SerializeField] private Transform _parent;

    public void Start()
    {
        int count = 30;
        float size = 100 * count + count * 20;

        if(size > _parent.GetComponent<RectTransform>().sizeDelta.y)
            _parent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, size);
        

        for (int i = 0; i < count; i++)
        {
            _recordPrefab.Init("Test" + i, Random.Range(1214, 8090));
            Instantiate(_recordPrefab, _parent);
        }
    }

}
