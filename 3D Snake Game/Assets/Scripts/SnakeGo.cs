using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnakeGo : MonoBehaviour
{
    public GameObject Pieces;
    public GameObject Box;
    public GameObject surface;

    public GameObject[] snake = new GameObject[4];
    public Material Dark;

    // Start is called before the first frame update
    void Awake()
    {
        ///this.gameObject.transform.DOScaleY(5.0f,0.0f);
    }
    void Start()
    {
        ///this.gameObject.transform.DOScaleY(1.0f,2.0f);
        this.gameObject.transform.DOLocalMoveX(1.5f,1.0f,false).OnComplete(Fade);
        ///this.gameObject.transform.DOMove(new Vector3(4.5f,-5.0f,4.5f),1.0f, false).SetEase(Ease.OutExpo);
        ///this.gameObject.transform.DOLocalRotateQuaternion(new Quaternion(0,0,0,1),1.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Break()
    {
        Pieces.SetActive(true);
        Box.GetComponent<MeshRenderer>().enabled = false;
        Invoke(("Cancel"),0.0f);
    }

    public void Cancel()
    {
        Box.SetActive(false);
        surface.SetActive(false);
    }

    public void Fade()
    {
        for(int i =0;i<snake.Length;i++)
        {
        Material a =snake[i].GetComponent<MeshRenderer>().material;
        a.DOColor(Dark.color,1.0f);
        }


    }
}
