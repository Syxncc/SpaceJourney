using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    public Slider slider;
    private TakeDamage takenDamage;
    // Start is called before the first frame update
    void Start()
    {
        takenDamage = GetComponent<TakeDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > .01f)
        {
            slider.value = takenDamage.GetCurrentHPPercent();
        }
        else
        {
            Debug.LogError("YOW");
            slider.gameObject.SetActive(false);
        }
    }
}
