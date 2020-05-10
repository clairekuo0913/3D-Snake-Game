using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_Snake : MonoBehaviour
{
    public float f_NumOfBodyParts;
    public float f_SnakeSpeed;
    float f_SnakeSpeedTmp;
    public GameObject gmobj_SnakeBodyPart;
    GameObject gmobj_SnakeHead;
    GameObject gmobj_SnakeBodyParts;
    GameObject gmobj_Cube;
    public bool bool_SnakeStop;
    int i_maxOfInstant;

    GameObject[] gmobjarr_Snakes = new GameObject[10000];
    Queue<GameObject> gmobjq_Snakes = new Queue<GameObject>();

    bool bool_inSnakeGrowth;

    IEnumerator SnakeGrowth(){
        bool_inSnakeGrowth = true;
        i_maxOfInstant = Mathf.RoundToInt(f_NumOfBodyParts / f_SnakeSpeed); 
        
        // The min size of Snake is 1 unit
        while(f_NumOfBodyParts <= 1){
            gmobj_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
            yield return null;
        }

        // Snake's Growth
        for(int i=1;i<=i_maxOfInstant;i++){
            if(!gmobj_Cube.GetComponent<sc_CubeRotation>().IsRotating() && Time.timeScale!=0){
                gmobjq_Snakes.Enqueue(Instantiate(gmobj_SnakeBodyPart, new Vector3(gmobj_SnakeHead.transform.position.x, gmobj_SnakeHead.transform.position.y, gmobj_SnakeHead.transform.position.z) ,Quaternion.identity,gmobj_SnakeBodyParts.transform));
                gmobj_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
            }else{
                i--;    // do nothing while cube is rotating
            }
            yield return null;
        }
        bool_inSnakeGrowth = false;
    }

    IEnumerator SnakeMovement(){
        //Destroy(gmobjarr_Snakes[1]);
        while(bool_inSnakeGrowth)
            yield return new WaitForSeconds(0.1f);
        // Snake's Movement
        while(true){

            for(int i=1;i<=i_maxOfInstant;i++){
                if(!gmobj_Cube.GetComponent<sc_CubeRotation>().IsRotating() && !bool_SnakeStop && Time.timeScale!=0){
                    gmobjq_Snakes.Enqueue(Instantiate(gmobj_SnakeBodyPart, new Vector3(gmobj_SnakeHead.transform.position.x, gmobj_SnakeHead.transform.position.y, gmobj_SnakeHead.transform.position.z) ,Quaternion.identity,gmobj_SnakeBodyParts.transform));
                    gmobj_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
                    Destroy(gmobjq_Snakes.Dequeue());
                }else{
                    i--;
                }
                yield return null;
                
            }
        }
    }
        

    
    private void OnTriggerEnter(Collider cldr_other){
        if(cldr_other.tag == "Cube"){
            Debug.Log("You are DEAD.");
            Scene currScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currScene.buildIndex);
        }
        if(cldr_other.tag == "EndPoint"){
            Debug.Log("You WIN!");
            Scene currScene = SceneManager.GetActiveScene();
            if(currScene.buildIndex == 0){
                SceneManager.LoadScene(1);
            }else if(currScene.buildIndex == 1){
                SceneManager.LoadScene(2);
            }else{
                SceneManager.LoadScene(0);
            }
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        f_SnakeSpeedTmp = f_SnakeSpeed;
        gmobj_Cube =  GameObject.FindWithTag("Cube"); 
        gmobj_SnakeHead = GameObject.FindWithTag("Snake");
        gmobj_SnakeBodyParts = GameObject.Find("SnakeBodyParts"); 
        StartCoroutine("SnakeGrowth");
        StartCoroutine("SnakeMovement");

    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
