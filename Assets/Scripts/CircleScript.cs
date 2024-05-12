using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    [SerializeField]
    private float forceFactor = 200f;

    private float upForceFactor = 2000f;
    private float leftForceFactor = 200f;
    private float rightForceFactor = 200f;
    private float downForceFactor = 200f;

    private Rigidbody2D rb;   // посилання на компонент 
    private GameObject display;   // посилання на інший ГО
    private DisplayScript displayScript;   // посилання на об'єкт скрипту в іншому ГО
   
    private bool needClearField = false;

    void Start()
    {
        // одержання посилання: this - сам об'єкт,
        // this.GetComponent - перший компонент заданого типу
        rb = this.GetComponent<Rigidbody2D>();
        display = GameObject.Find("Display");   // пошук за іменем в ієрархії
        displayScript = display.GetComponent<DisplayScript>();   // компонент в іншому ГО
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(forceFactor * Time.timeScale * Vector3.up);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(upForceFactor * Time.deltaTime * Vector3.up);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(downForceFactor * Time.deltaTime * Vector3.down);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(leftForceFactor * Time.deltaTime * Vector3.left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(rightForceFactor * Time.deltaTime * Vector3.right);
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
            // Debug.Log("Game over coming soon... ");
            displayScript.messageText.text = "Спроба програна";
            displayScript.SetPause(true);
            needClearField = true;
        }        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tube"))
        {
            Debug.Log("+1 to score");
        }
    }
    public void OnContinueButtonClick()
    {
        if (needClearField)
        {
            // повторна спроба - прибираємо всі труби з поля
            foreach(var tube in GameObject.FindGameObjectsWithTag("Tube"))
            {
                GameObject.Destroy(tube);
            }
        }
    }
}
/* Д.З. Завершити проєкт 2D
 * - При програній спробі прибирати з поля всі елементи (у т.ч. "Їжу")
 * - Змінювати надпис на кнопці меню паузи в залежності від ситуації 
 *    (почати / продовжити / повторити)
 * - Відображати кількість пройдених перешкод (труб), а також кількість
 *     спроб, що залишились ("життів")
 * - По завершенні всіх спроб видавати надпис "Гра завершена" [Нова гра]
 * - Додати кнопку виходу з гри (*зауважити, що вихід робиться по-різному
 *     у режимі Editor та у скомпільованій грі)
 */