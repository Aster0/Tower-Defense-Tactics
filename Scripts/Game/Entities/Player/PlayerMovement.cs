using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


namespace TD.Game
{
    public class PlayerMovement : MonoBehaviour
    {
    
        private NavMeshAgent agent;
        private Animator anim;
    
    
    
        [Header("Player Tap Animation")]
        public GameObject playerTabPrefab;
    
    
        private GameObject playerTabObject;
    
        public bool canMove { get; set; }
    
    
        public LayerMask playerTabLayerMask;
    
    
        // Start is called before the first frame update
        void Start()
        {
    
    
            canMove = true;
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animator>();
    
        }
    
        // Update is called once per frame
        void Update()
        {
    
    
         
    
    
    
            if (Input.GetButtonDown("Fire1") && (!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject()) && canMove)
            {
           
                RaycastHit hit;
    
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, playerTabLayerMask)) 
                {
    
                    agent.SetDestination(hit.point);
              
                    anim.SetBool("Walk", true);
    
    
                    if (playerTabObject != null)
                        DestroyPlayerTabObject();
    
                    playerTabObject = Instantiate(playerTabPrefab, hit.point + new Vector3(0, 0.2f, 0), Quaternion.identity);
    
    
                }
            }
    
            if (transform.position == agent.destination)
            {
                anim.SetBool("Walk", false);
                DestroyPlayerTabObject();
            }
         
    
    
        }
    
    
        private void DestroyPlayerTabObject()
        {
            Destroy(playerTabObject);
            playerTabObject = null;
        }
    }
}

