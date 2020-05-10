using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_SceneController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(Time.timeScale == 0.0f){
                Time.timeScale = 1.0f;
            }else{
                Time.timeScale = 0.0f;
            }
            print(Time.timeScale);
        }
    }
}
