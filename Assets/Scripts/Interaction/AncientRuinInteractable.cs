using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AncientRuinInteractable : MonoBehaviour, IClickable
{

    [SerializeField] GlobalGameDataSO globalGameDataSO;

    public void Interact()
    {
        Debug.Log($"Ancient Ruin Interaction");

      int num =   Random.Range( 2, globalGameDataSO.ancientRuinListe.Length);

        SceneManager.LoadScene(num);
        //globalGameDataSO.ancientRuinListe[num];
       

    }
}
