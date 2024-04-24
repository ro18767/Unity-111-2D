using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private float speed = 1f;

    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
