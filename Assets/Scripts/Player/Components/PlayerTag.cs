using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTag : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Slider hpBarSlider;

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private HealthComponent hpComponent;

    private void Start()
    {
        hpBarSlider.maxValue = hpComponent.GetMaxHP();
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        hpBarSlider.value = hpComponent.GetHP();
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }
}

