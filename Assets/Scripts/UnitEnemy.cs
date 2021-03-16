using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RTS
{
    public class UnitEnemy : MonoBehaviour
    {
        private NavMeshAgent agent;
        public GameObject highlight;
        public UnitEnemy instance;

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            highlight.SetActive(false);
            instance = this;
        }

        public void Selected(bool select)
        {
           Debug.Log("Selected");
        }

        public void MoveUnit(Vector3 position)
        {
            agent.SetDestination(position);
            SliderPlayer.instance.usedEnergy(32);
        }

        public void ActiveCircle()
        {
            highlight.SetActive(true);
        }

        public void DeActiveCircle()
        {
            highlight.SetActive(false);
        }
    }
}

