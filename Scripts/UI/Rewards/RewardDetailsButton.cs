using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardDetailsButton : MonoBehaviour
{

    private Button _button;
    private RewardIconManager _rewardIconManager;

    private LobbyManager _lobbyManager;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _rewardIconManager = GetComponent<RewardIconManager>();
        
        _lobbyManager = LobbyManager.Instance;
        
        
        _button.onClick.AddListener(OnShowRewardDetails);
    }

    private void OnShowRewardDetails()
    {
        _lobbyManager.rewardDetails.ShowDetails(_rewardIconManager.reward.rewardDetails.name, _rewardIconManager.reward.rewardDetails.description);
    }
}
