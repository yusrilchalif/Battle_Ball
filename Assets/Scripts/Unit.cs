using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    public class Unit : MonoBehaviour
    {
        private NavMeshAgent agent;
        public GameObject highlight;
        public Unit instance;
        public GameObject Ball;
        Renderer hitRen;
        public GameObject enemyObj;

        // private List<Material> mat = new List<Material>();
        // private List<Color> color = new List<Color>();


        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            // MeshRenderer[] meshes = GetComponentInChildren<MeshRenderer>();

            // foreach (var mesh in meshes)
            // {
            //     foreach(var mat in mesh.material)
            //     {
            //         this.mat.Add(mat);
            //         color.Add(mat.GetColor("_Color"));
            //     }
            // }


            Ball = GameObject.FindGameObjectWithTag("Ball");
            enemyObj = GameObject.FindGameObjectWithTag("Enemy");
            highlight.SetActive(false);
            instance = this;
        }

        public void Selected(bool select)
        {
            // for (int i = 0; i < mat.Count; i++)
            // {
            //     mat[i].SetColor("_Color", select ? Color.red : orgColors[i]);
            // }
           Debug.Log("Selected");
        }

        public void MoveUnit(Vector3 position)
        {
            agent.SetDestination(position);

            if(gameObject.tag=="Player")
            {
                SliderPlayer.instance.usedEnergy(32);
            }

            if(gameObject.tag=="Enemy")
            {
                EnemySlider.instance.usedEnergy(48);
            }
        }

        public void ActiveCircle()
        {
            highlight.SetActive(true);
        }

        public void DeActiveCircle()
        {
            highlight.SetActive(false);
        }

        // private void OnTriggerEnter(Collider other) {
        //     if(other.gameObjet.tag=="Player")
        //     {
        //         if(other.gameObjet.tag="Enemy")
        //         {
        //             hitRen = enemyObj.GetComponent<Renderer>();
        //             hitRen.material.color=Color.grey;
        //         }
        //     }
        // }
    }
}

