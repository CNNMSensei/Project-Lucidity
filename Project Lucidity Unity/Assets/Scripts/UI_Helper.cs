using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Helper : MonoBehaviour
{
    public GameObject HealthBar;
    private int lastHealthUIvalue = 8;

    public void SetHealthBar(int health){
        StartCoroutine(SetHealthBarInternal(health, health > lastHealthUIvalue));
        lastHealthUIvalue = health;
    }

    IEnumerator SetHealthBarInternal(int health, bool addHealth){
        List<GameObject> objectsToFlash = new List<GameObject>();
        
        for(int i = 0; i < 8; i++){
            if((i <= health && addHealth && !HealthBar.transform.GetChild(i).gameObject.activeSelf) || //Basically, this checks if the
                (i > health && !addHealth && HealthBar.transform.GetChild(i).gameObject.activeSelf)){ //bar is affected by the change
                objectsToFlash.Add(HealthBar.transform.GetChild(i).gameObject); //add the object to the list
            }
        }
        for(int rep = 0; rep < 5; rep++){
            for(int i = 0; i < objectsToFlash.Count; i++){
                objectsToFlash[i].SetActive(!objectsToFlash[i].activeSelf);
            }
            yield return new WaitForSeconds(0.15f);
        }
    }
}
