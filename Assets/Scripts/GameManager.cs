using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public int totalPoint;
    //public int stagePoint;
    public int stageIndex;
    public PlayerMove player;
    public GameObject[] Stages;
    public GameObject Home;
    public GameObject[] Hearts;
    public int heart;

    public void NextStage()
    {   
        //Change Stage
        if(stageIndex < Stages.Length -1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;

            
            Home.SetActive(true);
            //Stages[stageIndex].SetActive(true);
            //PlayerReposition();
        }
        else //Game Clear
        {
            Home.SetActive(true);
        }
        

    }

    public void HeartDown()
    {
        if (heart > 0)
        {   
            heart--;
            Hearts[2-heart].SetActive(false);

            // 죽음 -> 홈으로 돌아감
            if(heart == 0)
            {
                
                Stages[stageIndex].SetActive(false);
                Home.SetActive(true);
            }
        }
            
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //낭떠러지 떨어지면
        if (collision.gameObject.tag == "Player")
        {
            HeartDown();
            HeartDown();
            HeartDown();
        }
    }

    /*void PlayerReposition()
    {
        player.transform.position = new Vector3(-4.65f, 2, 0);
        player.velocityZero();
    }*/
}
