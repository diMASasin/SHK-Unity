using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenOpener : MonoBehaviour
{
    [SerializeField] private Player _player;

    public GameObject _endGameScreen;

    public void ShowEndGameScreen()
    {
        _endGameScreen.SetActive(true);
        _player.enabled = false;
    }
}
