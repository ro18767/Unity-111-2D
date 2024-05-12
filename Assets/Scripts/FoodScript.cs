using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}
/* Time.deltaTime - час між поточним та попереднім фреймом (кадром)
 * FPS-інваріантність: рух з постійною швидкістю при різних FPS
 * 100 FPS    dt = 0.01 s     Vector3.left * 0.01 -- 100 разів на сек. | за 1с зсув 1 
 * 50  FPS    dt = 0.02 s     Vector3.left * 0.02 -- 50 разів на сек.  | за 1с зсув 1
 * 
 * Також множення на час спрощує постановку гри на паузу, оскільки
 * навіть на паузі Update() виконується, але йому передається deltaTime = 0
 */
