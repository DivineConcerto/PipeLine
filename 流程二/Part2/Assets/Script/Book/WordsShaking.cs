using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsShaking : MonoBehaviour
{
    public float maxSpeed = 0.005f;
    public float lifeTime = 2f;

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    void Move()
    {
        float x_realSpeed = Random.Range(-maxSpeed, maxSpeed);
        float y_realSpeed = Random.Range(-maxSpeed, maxSpeed);
        float z_realSpeed = Random.Range(-maxSpeed, maxSpeed);
        this.transform.Translate(x_realSpeed, y_realSpeed, z_realSpeed);

        Invoke("selfDestroy", lifeTime);
    }
    void selfDestroy()
    {
        Object.Destroy(this.gameObject);
    }

}
