using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    Vector2 PlayerDestination; // The Portal from which the player will come out from

    public GameObject Player; // The player 

    public void OnTriggerEnter2D(Collider2D PortalDetect)
    {
        if (PortalDetect.gameObject.CompareTag("Player"))
        {
            CheckPortalTag();
            TeleportPlayer();
        }
    }

    public void CheckPortalTag()
    {
        var PortalTag = gameObject.tag;

        if (PortalTag.Contains("Start"))
        {
            var DestinationPortal = PortalTag + "Exit";
            GameObject PortalToTeleportTo = GameObject.FindGameObjectWithTag(DestinationPortal);
            PlayerDestination = PortalToTeleportTo.transform.position;
        }

        else if (PortalTag.Contains(PortalTag + "Exit"))
        {
            var FirstDestinationPortal = PortalTag.Replace("ExitExit", null);   
            GameObject PortalToTeleportTo = GameObject.FindGameObjectWithTag(FirstDestinationPortal);
            PlayerDestination = PortalToTeleportTo.transform.position;
        }        
    }

    public void TeleportPlayer()
    {
        Player.transform.position = PlayerDestination;
    }
}
