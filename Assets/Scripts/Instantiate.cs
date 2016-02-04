using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour
{
    public GameObject Go_Enemy;

    // Use this for initialization
    void Start()
    {
        InstantiateEnemy();
    }
    void InstantiateEnemy()
    {
        GameObject Go_current = (GameObject)Instantiate(Go_Enemy);
        Go_current.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        StartCoroutine("waitForFewSeconds");
    }
    IEnumerator waitForFewSeconds()
    {
        yield return new WaitForSeconds(5.0f);
        InstantiateEnemy();
    }
    // Update is called once per frame
    void Update()
    {

    }
}