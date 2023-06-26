using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    public GameObject prefab; 
    public GameObject spawnPoint;
    private Vector3 spawnPosition;
    public bool isCoroutineRunning = true;
    public float timeRun = 10f;
    private float timeGan;
    public float timeDestroyprefab = 2f;
    private void Start()
    {
        spawnPosition = spawnPoint.transform.position;
        timeGan = timeRun;
    }
    private void FixedUpdate()
    {
        timeRun -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        //StartCoroutine(WaitAndContinue());
        if (collision.gameObject.CompareTag("Player") && timeRun<=0 )
        {
            Debug.Log("va cham chuy");
            GameObject newPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
           
            Destroy(newPrefab, timeDestroyprefab);
            timeRun = timeGan;

        }
        
    }
    private IEnumerator WaitAndContinue()
    {
      
        // Đợi 5 giây
        yield return new WaitForSeconds(2f);
        isCoroutineRunning = false;

        yield return new WaitForSeconds(7f);
        isCoroutineRunning = true;
    }
}
