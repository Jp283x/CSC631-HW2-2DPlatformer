using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBuffScript : MonoBehaviour
{

    public GameObject ShieldGear;
    public Image GearSlot;
    public Image Shield;

    private bool shieldActive = false;

    // Start is called before the first frame update
    void Start()
    {
        GearSlot = Instantiate(ShieldGear, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        Shield = Instantiate(ShieldGear, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        Shield.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            shieldActive = !shieldActive;
            Shield.enabled = true;
            Debug.Log("I key pressed");
        }
        else
        {
            shieldActive = false;
            Shield.enabled = false;
        }
    }
}
