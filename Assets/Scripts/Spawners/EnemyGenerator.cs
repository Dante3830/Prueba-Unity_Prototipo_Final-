using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    // Referencia a los prefabs
    [SerializeField] public GameObject[] objectsPrefabs;

    // Tiempo de espera (ajustable)
    [SerializeField][Range(0.5f, 10f)] public float WaitTime;

    // Tiempo de intervalo (ajustable)
    [SerializeField][Range(0.5f, 10f)] public float IntervalTime;

    // Repite la invocación
    private void OnEnable() {
        InvokeRepeating(nameof(GenerateRandomObject), WaitTime, IntervalTime);
    }

    // Toma los objetos prefab y los instancia
    void GenerateRandomObject() {
        int RandomIndex = Random.Range(0, objectsPrefabs.Length);
        GameObject RandomPrefab = objectsPrefabs[RandomIndex];
        GameObject enemy = EnemyPool.Instance.RequestEnemies();
        enemy.transform.position = transform.position;
    }
}
