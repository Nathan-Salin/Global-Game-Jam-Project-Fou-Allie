using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> objects_to_spawn = new List<GameObject>();
    private int spawn_count = 0;
    public int spawm_max = 500;
    public Transform spawn_transform = null;

    public float spawn_interval = 1f;
    private float timer = 0f;



    void GenerateRandomGameObject()
    {

        Vector3 randomPosition = new Vector3(
            Random.Range(spawn_transform.position.x - spawn_transform.localScale.x / 2f, spawn_transform.position.x + spawn_transform.localScale.x / 2f),
            Random.Range(spawn_transform.position.y - spawn_transform.localScale.y / 2f, spawn_transform.position.y + spawn_transform.localScale.y / 2f),
            Random.Range(spawn_transform.position.z - spawn_transform.localScale.z / 2f, spawn_transform.position.z + spawn_transform.localScale.z / 2f)
        );

        Quaternion randomRotation = Quaternion.Euler(
            Random.Range(0, 360),
            Random.Range(0, 360),
            Random.Range(0, 360)
        );

        int random_gameObject = Random.Range(0, objects_to_spawn.Count);

        Instantiate(objects_to_spawn[random_gameObject], randomPosition, randomRotation);
        spawn_count ++;
    }

    // Update is called once per frame
    void Update()
    {
        // Utiliser le temps écoulé pour déterminer le moment du prochain spawn
        timer += Time.deltaTime;

        if (timer >= spawn_interval && spawn_count < spawm_max)
        {
            GenerateRandomGameObject();
            timer = 0f; // Réinitialiser le timer
        }
    }

}
