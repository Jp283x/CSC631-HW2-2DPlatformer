using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int health = 10;
    public Text healthText;

    void Update()
    {
        healthText.text = "bigPog : " + health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
