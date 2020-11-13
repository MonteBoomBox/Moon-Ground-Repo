using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    public GameObject PlayerBlaster;

    private int currentAmmoCount;

    string displayAmmo;

    TextMeshProUGUI AmmoCountDisplay;


    void Start()
    {
        currentAmmoCount = PlayerBlaster.GetComponent<Blaster>().currentAmmo;
        displayAmmo = currentAmmoCount.ToString();
        AmmoCountDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        AmmoCountDisplay.text = currentAmmoCount.ToString();           
    }
}
