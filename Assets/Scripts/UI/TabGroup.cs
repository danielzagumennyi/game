using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public List<GameObject> objectsToSwap;

    public Sprite tabIdle;
    public Sprite tabActive;

    public TabButton selectedTab;

    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++ )
        {
            objectsToSwap[i].SetActive(i == index);
        }
    }

    public void ResetTabs()
    {
        foreach(TabButton button in tabButtons)
        {
            if (selectedTab != null && selectedTab == button) { continue; }
            button.background.sprite = tabIdle;
        }
    }
}
