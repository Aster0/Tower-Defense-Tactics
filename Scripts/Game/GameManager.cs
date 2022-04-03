using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace TD.Game {
    public class GameManager : MonoBehaviour
    {
     

        public static GameManager Instance { get; set; }

        public GameState currentGameState;

        public GameObject preLoadItems;

        public GameObject playerUI;

        public TurretButtonManager CurrentTurretBuildInstance { get; set; }
        public GameObject buildParticle;

        public GameObject[] Points { get; set; }

        public GameObject deathParticles;

        public GameObject currency;

        public CurrencyManager CurrencyManager { get; set; }

        public GameObject Player { get; set;  }

        public GameObject playerPrefab;
        
        public Player playerComponent { get; set; }
        public Animator playerAnimator { get; set; }
        public PlayerMovement playerMovement { get; set; }


        public GameObject damageIndicator, tooCloseIndicator;

        public GameObject InfoIndicator { get; set; }
        public GameObject InfoBox { get; set; }
       





        public int Level { get; set; }

        [Header("A list of enemies.")]
        public Enemy[] enemies;

        private GameObject[] _turretIcons;

        public WaveManager WaveManager { get; set; }
        
        public WaveUIManager WaveUIManager { get; set; }


        public GameObject StartPoint { get; set; }

        public GameObject EndPoint {get; set;}

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                SetupGame();


            }
        }
        

        private void Start()
        {
            if(Instance != null)
                CacheDialogues();
        }

        private void SetupGame()
        {
            InfoIndicator = GameObject.FindGameObjectWithTag("InfoButton");
            InfoIndicator.SetActive(false); // when it finds the UI, turn it off.


            InfoBox = GameObject.FindGameObjectWithTag("InfoBox");



            WaveUIManager = GameObject.FindGameObjectWithTag("WaveUI").GetComponent<WaveUIManager>();
            

            CurrencyManager = GameObject.FindGameObjectWithTag("CurrencyUI").GetComponent<CurrencyManager>();


      

            Level = LevelManager.instance.chosenLevel;

            
            WaveManager = GetComponent<WaveManager>();
            
     


            LoadEnemies();
           
       

           

              

   

        


            _turretIcons = GameObject.FindGameObjectsWithTag("TurretIcon");
            foreach (GameObject turret in _turretIcons)
            {

                TurretIconManager turretIconManager = turret.GetComponent<TurretIconManager>();
                turretIconManager.UnlockTurret();
            }
        }


        public void LoadPoints()
        {
            Points = GameObject.FindGameObjectsWithTag("Waypoint");
            
            System.Array.Sort(Points, (x, y) => string.Compare(x.name, y.name));
            
            StartPoint = Points[0];
            EndPoint = Points[Points.Length - 1];
        }

    
        private void LoadEnemies()
        {
            Object[] enemyObj = Resources.LoadAll("Objects/Enemies", typeof(Enemy));


            enemies = new Enemy[enemyObj.Length];
            int count = 0;
            foreach (Object enemy in enemyObj)
            {

                enemies[count] = (Enemy) enemy;

                count++;
            }
            
           
        }
        private void CacheDialogues() // ran during loading screen.
        {
            Object[] dialogues = Resources.LoadAll("Objects/Dialogues", typeof(Dialogue));


            foreach (Object dialogueObject in dialogues) // this should be loaded in the loading screen.
            {

                Dialogue dialogue = (Dialogue) dialogueObject;
               


                if (dialogue.LoadDialogue()) // check if we should actually load this dialogue in the current level.
                {
                    DialogueManager.instance.StartDialogue(dialogue);
                    break;
                }

              
       



            }
        }

     

     
    }
}

