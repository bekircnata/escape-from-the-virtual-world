using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int collectedItem = 0;
    [SerializeField] private TextMeshProUGUI pineappleCount;

    void Start()
    {
        
    }

    void Update()
    {
        pineappleCount.text = collectedItem.ToString();
    }
}
