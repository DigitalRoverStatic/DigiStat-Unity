﻿using UnityEngine;
using UnityEngine.UI;

public class Regions1 : MonoBehaviour
{

    public string[] oblasty = { "Архангельская область", "Астраханская область", "Белгородская область", "Брянская область", "Владимирская область", "Волгоградская область", "Вологодская область", "Воронежская область", "Ивановская область", "Кабардино-Балкарская Республика", "Калининградская область", "Калужская область", "Карачаево-Черкесская Республика", "Кировская область", "Костромская область", "Краснодарский край", "Курганская область", "Курская область", "Ленинградская область", "Липецкая область", "Московская область", "Мурманская область", "Нижегородская область", "Новгородская область", "Оренбургская область", "Орловская область", "Пензенская область", "Пермский край", "Псковская область", "Республика Башкортостан", "Республика Дагестан", "Республика Ингушетия", "Республика Калмыкия", "Республика Карелия", "Республика Коми", "Республика Крым", "Республика Марий Эл", "Республика Мордовия", "Республика Северная Осетия-Алания", "Республика Татарстан", "Ростовская область", "Рязанская область", "Самарская область", "Саратовская область", "Свердловская область", "Смоленская область", "Ставропольский край", "Тамбовская область", "Тверская область", "Тульская область", "Тюменская область", "Удмуртская Республика", "Ульяновская область", "Челябинская область", "Чеченская Республика", "Чувашская Республика", "Ярославская область", "Алтайский край", "Забайкальский край", "Иркутская область", "Кемеровская область", "Красноярский край", "Новосибирская область", "Омская область", "Республика Бурятия", "Республика Тыва", "Республика Хакасия", "Томская область" };
    public GameObject prefabButtonRegion;
    public GameObject content;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (string item in oblasty)
        {
            GameObject tempGO = Instantiate(prefabButtonRegion);
            tempGO.transform.parent = content.transform;
            var region = tempGO.GetComponent<Regions>();
            region.Text.text= item;
            region.GetComponent<Toggle>().group = region.GetComponentInParent<ToggleGroup>();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}