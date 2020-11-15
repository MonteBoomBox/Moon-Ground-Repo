using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 PressedState;
    Vector2 UnPressedState;

    public float offset;
    public float GasPumpTime;

    GasPump PumpMethod;

    private bool isPressed;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PressedState = new Vector2(transform.position.x, transform.position.y + offset);
        UnPressedState = new Vector2(transform.position.x, transform.position.y - offset);
        PumpMethod = GetComponentInParent<GasPump>();
        isPressed = false;
    }

    public void OnCollisionEnter2D(Collision2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            if (!isPressed)
            {
                isPressed = true;
                StartCoroutine(StartGasPump());
            }            
        }
    }

    public void Update()
    {
        if (!isPressed)
        {
            transform.position = UnPressedState;
        }
        
    }

    IEnumerator StartGasPump()
    {
        rb.MovePosition(PressedState);
        yield return new WaitForSeconds(GasPumpTime);
        PumpMethod.SpawnGasBubble();
        isPressed = false;
    }
}
