using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameMode
{
    Game,
    Map,
    Max
}

public class GameManager : MonoBehaviour
{
    GameMode _mode;
    public GameObject _player;
    public GameObject _light;
    void Start()
    {
        _mode = GameMode.Game;
    }

    void Update()
    {
        if (Input.GetButton("Map"))
        {
            _mode = GameMode.Map;
        }
        if (Input.GetButton("Back")){
            _mode = GameMode.Game;
        }

        if(_mode == GameMode.Game)
        {
            _light.SetActive(false);
            _player.SetActive(true);
        }
        else
        {
            _light.SetActive(true);
            _player.SetActive(false);
        }
    }
}
