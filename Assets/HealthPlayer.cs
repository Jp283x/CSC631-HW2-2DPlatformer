using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{

    public GameObject HealthPrefab;
    public Image BarBorder;
    public Image BarFilled;
    public float damage = 20.0f;

    public float currentHealth;
    public float maxHealth = 100.0f;
    public float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        BarBorder = Instantiate(HealthPrefab, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        BarFilled = new List<Image>(BarBorder.GetComponentsInChildren<Image>()).Find(img => img != BarBorder);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHealthBar();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= damage;
            // BarFilled.fillAmount -= .2f;
            Debug.Log(BarFilled.fillAmount);
            Debug.Log(currentHealth);
        }
    }

    private float HealthMap(float currentHealth, float healthMin, float healthMax, float barMin, float barMax)
    {
        return (currentHealth - healthMin) * (barMax - barMin) / (healthMax - healthMin) + barMin;
    }

    private void HandleHealthBar()
    {

        currentValue = HealthMap(currentHealth, 0, maxHealth, 0, 1);

        BarFilled.fillAmount = Mathf.Lerp(BarFilled.fillAmount, currentValue, Time.deltaTime);
    }
}
