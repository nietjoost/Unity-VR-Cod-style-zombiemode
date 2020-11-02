using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI round;
    public TextMeshProUGUI money;

    public void SetRound(int num)
	{
        round.text = "Round: " + num;
	}

    public void SetMoney(int num)
    {
        money.text = "Money: " + num;
    }
}
