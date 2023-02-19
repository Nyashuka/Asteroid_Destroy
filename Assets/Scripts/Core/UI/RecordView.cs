using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordView : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Text _recordValue;

    public void Init(string name, int recordValue)
    {
        _name.text = name;
        _recordValue.text = recordValue.ToString();
    }

}

