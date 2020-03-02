using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_Snake : MonoBehaviour
{
    public float f_NumOfBodyParts;
    public float f_SnakeSpeed;
    public GameObject gmobj_SnakeBodyPart;
    GameObject gmobj_SnakeHead;
    GameObject gmobj_Cube;

    GameObject[] gmobjarr_Snakes = new GameObject[10000];
    
    IEnumerator SnakeMovement(){
        int i_maxOfInstant = Mathf.RoundToInt(f_NumOfBodyParts / f_SnakeSpeed); 
        
        // The min size of Snake is 1 unit
        while(f_NumOfBodyParts <= 1){
            gmobj_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
            yield return null;
        }

        // Snake's Growth
        for(int i=1;i<=i_maxOfInstant;i++){
            if(!gmobj_Cube.GetComponent<sc_CubeRotation>().IsRotating()){
                gmobjarr_Snakes[i] = Instantiate(gmobj_SnakeBodyPart, new Vector3(gmobj_SnakeHead.transform.position.x, gmobj_SnakeHead.transform.position.y, gmobj_SnakeHead.transform.position.z) ,Quaternion.identity,gmobj_Cube.transform);
                gmobj_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
            }else{
                i--;    // do nothing while cube is rotating
            }
            yield return null;
        }
        Destroy(gmobjarr_Snakes[1]);

        // Snake's Movement
        while(true){
            for(int i=1;i<=i_maxOfInstant;i++){
                if(!gmobj_Cube.GetComponent<sc_CubeRotation>().IsRotating()){
                    gmobjarr_Snakes[i] = Instantiate(gmobj_SnakeBodyPart, new Vector3(gmobj_SnakeHead.transform.position.x, gmobj_SnakeHead.transform.position.y, gmobj_SnakeHead.transform.position.z) ,Quaternion.identity,gmobj_Cube.transform);
                    gmobj_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
                    if(i == i_maxOfInstant){Destroy(gmobjarr_Snakes[1]);}
                    else{Destroy(gmobjarr_Snakes[i+1]);}
                }else{
                    i--;    // do nothing while cube is rotating
                }
                yield return null;
                
            }
        }
    }
   
    
    private void OnTriggerEnter(Collider cldr_other){
        if(cldr_other.tag == "Cube"){
            Debug.Log("You are DEAD.");
            SceneManager.LoadScene(0);
        }
        if(cldr_other.tag == "EndPoint"){
            Debug.Log("You WIN!");
            SceneManager.LoadScene(0);
        }
        

    }


    // Start is called before the first frame update
    void Start()
    {
        gmobj_Cube =  GameObject.FindWithTag("Cube"); 
        gmobj_SnakeHead = GameObject.FindWithTag("Snake");
        StartCoroutine("SnakeMovement");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
