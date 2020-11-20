using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{

    public Vector2 movementVector = new Vector2(10f, 10f);

    public float period;

    [Range(0, 1)] public float movementFactor;

    Vector2 startingPos;


    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;

        const float tao = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tao);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector2 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}
