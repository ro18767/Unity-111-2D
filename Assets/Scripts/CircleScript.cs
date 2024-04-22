using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    [SerializeField]
    private float forceFactor = 200f;

    private Rigidbody2D rb;   // посилання на компонент 
    void Start()
    {
        // одержання посилання: this - сам об'єкт,
        // this.GetComponent - перший компонент заданого типу
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceFactor);
        }
    }
}
/* Д.З. Створити проєкт 2D
 * Створити центральний об'єкт - Bird
 * Реалізувати управління (на базі фізики) - пробілом, 
 *  а також стрілками у 4 боки
 * Обмежити ігрове поле колайдерами з усіх боків - перевірити, що 
 * об'єкт не виходить з поля гри.
 * До звіти додати скріншоти / відеозапис
 */