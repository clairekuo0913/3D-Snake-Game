using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Snake : MonoBehaviour
{
    public float NumOfBodyParts;
    public float SnakeSpeed;
    public GameObject SnakeHead;
    public GameObject SnakeBodyPart;
    GameObject Cube;

    GameObject[] Snakes = new GameObject[10000];
    IEnumerator SnakeMovement(){
        int maxofinstant = Mathf.RoundToInt(NumOfBodyParts / SnakeSpeed); 
        
        // The min size of Snake is 1 unit
        while(NumOfBodyParts<=1){
            SnakeHead.transform.position += SnakeSpeed * Vector3.up;
            yield return null;
        }

        // Snake's Growth
        for(int i=1;i<=maxofinstant;i++){
            if(!Cube.GetComponent<sc_CubeRotation>().bool_IsRotate){
                Snakes[i] = Instantiate(SnakeBodyPart, new Vector3(SnakeHead.transform.position.x, SnakeHead.transform.position.y, SnakeHead.transform.position.z) ,Quaternion.identity,Cube.transform);
                SnakeHead.transform.position += SnakeSpeed * Vector3.up;
            }else{
                i--;    // do nothing while cube is rotating
            }
            yield return null;
        }
        Destroy(Snakes[1]);

        // Snake's Movement
        while(true){
            for(int i=1;i<=maxofinstant;i++){
                if(!Cube.GetComponent<sc_CubeRotation>().bool_IsRotate){
                    Snakes[i] = Instantiate(SnakeBodyPart, new Vector3(SnakeHead.transform.position.x, SnakeHead.transform.position.y, SnakeHead.transform.position.z) ,Quaternion.identity,Cube.transform);
                    SnakeHead.transform.position += SnakeSpeed * Vector3.up;
                    if(i==maxofinstant){Destroy(Snakes[1]);}
                    else{Destroy(Snakes[i+1]);}
                }else{
                    i--;    // do nothing while cube is rotating
                }
                yield return null;
                
            }
        }
    }
   


    // Start is called before the first frame update
    void Start()
    {
        Cube =  GameObject.Find("Cube"); 
        StartCoroutine("SnakeMovement");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
