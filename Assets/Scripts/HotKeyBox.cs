using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HotKeyBox : MonoBehaviour
{
    public int hotKeyValue;

    [SerializeField] GameObject activeItemIcon;

    TextMeshProUGUI amountLabel;

    private void Awake()
    {
        amountLabel = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Update()
    {
        if (PlayerInventory.instance.hotkeyItems[hotKeyValue] != null)
        {
            amountLabel.text = PlayerInventory.instance.hotkeyItems[hotKeyValue]._amount.ToString();
        }
        else
        {
            amountLabel.text = "0";
        }

        activeItemIcon.SetActive(PlayerInventory.instance.activeHotKey == hotKeyValue);
    }
}
