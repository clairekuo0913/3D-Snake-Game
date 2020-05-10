using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	int iCurrentLevel;

    // Start is called before the first frame update
    void Start()
    {
    	iCurrentLevel = PlayerStats.CurrentLevel;
    }

}
