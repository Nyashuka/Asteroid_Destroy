using System.Collections;
using System.Collections.Generic;
using SaveSystem.ScoreSaver;
using UnityEngine;

public class RecordsListView : MonoBehaviour
{
    [SerializeField] private RecordView recordPrefab;
    [SerializeField] private int recordHeight;
    [SerializeField] private RectTransform parent;

    public void Start()
    {
        List<PlayerScoreData> playerData = ServicesProvider.Instance.PlayerDataManager.PlayersData;
        playerData.Sort();
        playerData.Reverse();

        float size = recordHeight * playerData.Count;

        if(size > parent.sizeDelta.y)
            parent.sizeDelta = new Vector2(0, size);    

        foreach (var player in playerData)
        {
            recordPrefab.Init(player.Username, player.MaxScore);
            Instantiate(recordPrefab, parent);
        }
    }

}
