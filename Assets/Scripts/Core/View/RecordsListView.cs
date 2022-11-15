using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsListView : MonoBehaviour
{
    [SerializeField] private RecordView _recordPrefab;
    [SerializeField] private int _recordHeight; // 100 is good size
    [SerializeField] private Transform _parent;

    public void Start()
    {
        List<PlayerData> playerData = ServicesProvider.Instance.PlayerDataManager.PlayersData;

        int count = playerData.Count;
        float size = _recordHeight * count + count * 20; // i forgot what is 20 

        if(size > _parent.GetComponent<RectTransform>().sizeDelta.y)
            _parent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, size);
        

        foreach (var player in playerData)
        {
            _recordPrefab.Init(player.Username, player.MaxScore);
            Instantiate(_recordPrefab, _parent);
        }
    }

}
