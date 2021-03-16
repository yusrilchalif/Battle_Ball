using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;

public class BallController : MonoBehaviour
{
    public GameObject playerCube;
    Renderer hitRen;
    // RigidBody rigid;
    public Text scorePlayer;
    public Text scoreEnemy;
    public int speedBall;
    int scoreEnem;
    int scorePlay;
    public GameObject Ball;

    public Unit unitPlayer;
    // public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        scoreEnemy = GameObject.Find("Enemy_score").GetComponent<Text>();
        scorePlayer = GameObject.Find("Player_Score").GetComponent<Text>();

        // unitPlayer = GameObject.FindGameObjectWithTag("Player");

        scoreEnem = 0;
        scorePlay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collision collision)
    {
      if (collision.gameObject.tag == "Player"){
        //   Destroy(gameObject);
          // unitPlayer.ActiveCircle();
          Debug.Log("Collision");
      }

      if(collision.gameObject.tag=="Enemy")
      {
        // enemyController.ActiveCircle();
      }

      if(collision.gameObject.tag == "Goal_Enemy")
      {
          scorePlay += 1;
          ShowScore();
          ResetPos();
      }

      if(collision.gameObject.tag == "Goal_Player")
      {
          scoreEnem += 1;
          ShowScore();
          ResetPos();
      }
    }

   
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player"|| other.gameObject.tag=="Enemy"){
          // Destroy(gameObject);
          // unitPlayer.DeActiveCircle();
      }
    }

      public void ResetPos()
      {
          Ball.transform.position = new Vector3(-1f, -0.37f, 33.2f);
      }


    void ShowScore()
    {
        scoreEnemy.text = scoreEnem + "" ;
        scorePlayer.text = scorePlay + "";
    }
}
