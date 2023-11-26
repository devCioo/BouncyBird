using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public static float speed = .65f;

    private void Update()
    {
        transform.position += Vector3.left * PipeSpawner.instance.pipesSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Despawn());
        }
    }

    private IEnumerator Despawn()
    {
        for (float i = 0f; i < speed / 2; i += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
