using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour
{
    Vector2 destination;

    public float distanceToPortal = 0.3f;

    public GameObject Player;

    string OutName = "Out";
    string InName = "In";

    private SpriteRenderer PlayerRenderer;

    private float visibleAlphaValue = 1f;
    private float invisibleAlphaValue = 0f;


    public void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.gameObject.tag == "Player")
        {
            CheckPortalTag();
            TeleportPlayer();            
        }

        

    }

    public void CheckPortalTag()
    {
        var PortalTag = gameObject.tag;

        if (PortalTag.Contains(InName))
        {
            var changedPortalTag = PortalTag.Replace("In", "Out");
            GameObject PortalToTeleportTo = GameObject.FindGameObjectWithTag(changedPortalTag);
            destination = PortalToTeleportTo.transform.position;
        }

        else if (PortalTag.Contains(OutName))
        {
            var changedPortalTag = PortalTag.Replace("Out", "In");
            GameObject PortalToTeleportTo = GameObject.FindGameObjectWithTag(changedPortalTag);
            destination = PortalToTeleportTo.transform.position;
        }
    }

    public void TeleportPlayer()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) > distanceToPortal)
        {
            FadeOutPlayer();
            Player.transform.position = new Vector2(destination.x, destination.y);
            FadeInPlayer();
        }
    }

    public void FadeOutPlayer()
    {
        SpriteRenderer PlayerAlpha = Player.GetComponent<SpriteRenderer>();

        Color newColor = PlayerAlpha.color;
        newColor.a = invisibleAlphaValue;
        PlayerAlpha.color = newColor;
    }

    public void FadeInPlayer()
    {
        SpriteRenderer PlayerAlpha = Player.GetComponent<SpriteRenderer>();

        Color newColor = PlayerAlpha.color;
        newColor.a = visibleAlphaValue;
        PlayerAlpha.color = newColor;
    }
}
