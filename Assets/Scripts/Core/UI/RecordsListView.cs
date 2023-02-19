using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsListView : MonoBehaviour
{
    [SerializeField] private RecordView _recordPrefab;
    [SerializeField] private int _recordHeight;
    [SerializeField] private RectTransform _parent;

    public void Start()
    {
        List<PlayerData> playerData = ServicesProvider.Instance.PlayerDataManager.PlayersData;
        playerData.Sort();
        playerData.Reverse();

        float size = _recordHeight * playerData.Count;

        if(size > _parent.sizeDelta.y)
            _parent.sizeDelta = new Vector2(0, size);    

        foreach (var player in playerData)
        {
            _recordPrefab.Init(player.Username, player.MaxScore);
            Instantiate(_recordPrefab, _parent);
        }
    }

}
