using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemySpawm : MonoBehaviour
{
    //[SerializeField] private Enemy[] prefabEnemy;
    [SerializeField] private List<Enemy> prefabEnemy;
    [SerializeField] int baseEnemy = 10;
    [SerializeField] float diffcult = 0.75f;
    [SerializeField] float enemyPerSecond = 1f;
    [SerializeField] float timeBetweenSpawm = 5f;
    [SerializeField] int waveMax;

    public static UnityEvent onEnemyDestroy = new UnityEvent();
    private float currentWaves = 1;
    private float timeLastSpawm;
    private int enemyAlive;
    private int enemyLeftSpawm;
    private bool isSpawming = false;
    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }
    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawming) return;
        timeLastSpawm += Time.deltaTime;
        if(timeLastSpawm >= 1f / enemyPerSecond  && enemyLeftSpawm > 0)
        {
            SpawmEnemy();
            enemyLeftSpawm--;
            enemyAlive++;
            timeLastSpawm = 0f;
        }
        if(currentWaves <= waveMax)
        {
            if (enemyAlive <= 0 && enemyLeftSpawm == 0)
            {
                EndWave();
            }
            else if(SconeManager.instance.countEnemyDesTroy > 3)
            {
                SceneManager.LoadScene("Scene lose");
               // return;
            }
        }

        
       


    }
    private int EnemyPerWave()
    {
        return Mathf.RoundToInt(baseEnemy * Mathf.Pow(currentWaves,diffcult));
    }
    private void SpawmEnemy()
    {
        
        Instantiate(prefabEnemy[Index()],SconeManager.instance.startPoint.position, Quaternion.identity);
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenSpawm);
        isSpawming = true;
        enemyLeftSpawm = EnemyPerWave();
    }
    private void EnemyDestroyed()
    {
        
        enemyAlive--;
        
    }

    private void EndWave()
    {
        isSpawming = false;
        timeLastSpawm = 0f;
        currentWaves++;
        if(currentWaves == waveMax)
        {
            SceneManager.LoadScene("GameWin");
           // return;
        }
        StartCoroutine(StartWave());
    }

    private int Index()
    {
        int index = Random.Range(0,prefabEnemy.Count);
        return index;
    }




   




}
