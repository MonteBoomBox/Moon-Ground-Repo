using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portals : MonoBehaviour
{
    Vector2 destination;

    public float distanceToPortal = 0.3f;

    GameObject Player;
    public GameObject bullet;

    string OutName = "Out";
    string InName = "In";

    private SpriteRenderer PlayerRenderer;

    private float visibleAlphaValue = 1f;
    private float invisibleAlphaValue = 0f;

    public float rotateSpeed = 15f;

    MemeEntry enterMeme;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enterMeme = GetComponent<MemeEntry>();
    }

    public void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if (HitInfo.gameObject.tag == "Player")
        {
            CheckPortalTag();
            TeleportPlayer();            
        }

        else if (HitInfo.gameObject.tag == "Bullet")
        {
            CheckPortalTag();
            TeleportBullet(HitInfo.gameObject);
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
            //enterMeme.TeleportPlayerToMeme();
        }

        else if (PortalTag.Contains(OutName))
        {
            var changedPortalTag = PortalTag.Replace("Out", "In");
            GameObject PortalToTeleportTo = GameObject.FindGameObjectWithTag(changedPortalTag);
            destination = PortalToTeleportTo.transform.position;
            //enterMeme.TeleportPlayerToGame();
        }
    }

    public void TeleportPlayer() // This will teleport the Player from portal to portal
    {
        if (Vector2.Distance(transform.position, Player.transform.position) > distanceToPortal)
        {
            FadeOutPlayer();
            Player.transform.position = new Vector2(destination.x, destination.y);
            
            FadeInPlayer();
        }
    }

    public void TeleportBullet(GameObject bulletFired) // This will teleport the bullet from portal to portal
    {
        if (Vector2.Distance(transform.position, bulletFired.transform.position) > distanceToPortal)
        {
            bulletFired.transform.position = new Vector2(destination.x, destination.y);
        }
    }

    public void Update()
    {
        RotatePortal();
    }

    public void RotatePortal()
    {
        transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
    }


    // This effect is unnoticable
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
