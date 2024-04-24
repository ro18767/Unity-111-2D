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
        this.transform.eulerAngles = new Vector3(0, 0, 2f * rb.velocity.y);
    }

    /* Взаємодія колайдерів залежить від їх типу:
       - звичайні колайдери обробляються фізичним двигуном і при колізії
          генерують подію OnCollisionEnter[2D]
       - колайдери-тригери лише генерують події OnTriggerEnter[2D]
          і не обробляються фізикою
          Вихід колайдерів з перетину супроводжується подією 
           OnTriggerExit[2D]
       - незалежно від типу хоча б один з носіїв колайдерів
          повинен мати Rigidbody
       - події передаються обом учасникам колізії
       - події не створюються зі static об'єктом
    */
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision with " + other.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over coming soon... ");
        }        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tube"))
        {
            Debug.Log("+1 to score");
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