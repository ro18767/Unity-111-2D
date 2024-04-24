using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TubePrefab;
    [SerializeField]
    private GameObject FoodPrefab;

    private float tubeSpawnDelay = 4f;   // кожні 4 сек
    private float tubeSpawnCountdown;
    private float foodSpawnCountdown;

    void Start()
    {
        SpawnTube();
        tubeSpawnCountdown = tubeSpawnDelay;
        foodSpawnCountdown = 1.5f * tubeSpawnDelay;
    }

    void Update()
    {
        tubeSpawnCountdown -= Time.deltaTime;
        if(tubeSpawnCountdown <= 0)
        {
            SpawnTube();
            tubeSpawnCountdown = tubeSpawnDelay;
        }

        foodSpawnCountdown -= Time.deltaTime;
        if (foodSpawnCountdown <= 0)
        {
            SpawnFood();
            foodSpawnCountdown = tubeSpawnDelay;
        }
    }

    private void SpawnTube()
    {
        GameObject tube = GameObject.Instantiate(TubePrefab);
        tube.transform.position = this.transform.position
            + Vector3.up * Random.Range(-2f, 2f);
    }
    private void SpawnFood()
    {
        if (Random.value < 0.5f) return;   // випадково через раз

        GameObject food = GameObject.Instantiate(FoodPrefab);
        food.transform.position = this.transform.position
            + Vector3.up * Random.Range(-2f, 2f);
    }
}
/* Д.З. (Префаби) Реалізувати префаб "Життя", який має збільшувати
 * кількість "життів" - ігрових спроб.
 * Забезпечити зникнення об'єктів ("Їжа" та "Життя") при їх контакті
 * з головним  персонажем
 */