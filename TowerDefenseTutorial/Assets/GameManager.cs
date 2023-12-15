using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.Lives <= 0) //플레이어 체력이 0 이하
        {
            EndGame;
        }
    }
}
