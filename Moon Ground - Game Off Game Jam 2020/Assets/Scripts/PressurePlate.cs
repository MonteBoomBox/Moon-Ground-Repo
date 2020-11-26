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
    private bool hasStartedCoroutine;

    Coroutine GasPumping;

    public GameObject GasParent;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PressedState = new Vector2(transform.position.x, transform.position.y + offset);
        UnPressedState = new Vector2(transform.position.x, transform.position.y - offset);
        PumpMethod = GasParent.GetComponent<GasPump>();
        isPressed = false;
    }

    public void OnCollisionEnter2D(Collision2D trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            if (!isPressed)
            {
                isPressed = true;
                trigger.gameObject.transform.SetParent(transform);
                GasPumping = StartCoroutine(StartGasPump());
            }
                              
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        isPressed = false;
        collision.gameObject.transform.SetParent(null);
        StopCoroutine(GasPumping);
    }

    public void Update()
    {
        if (!isPressed)
        {
            transform.position = UnPressedState;
        }

        else if (isPressed)
        {
            transform.position = PressedState;
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
