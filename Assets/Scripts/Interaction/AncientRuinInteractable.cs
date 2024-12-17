using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class AncientRuinInteractable : MonoBehaviour, IClickable
{

    [SerializeField] GlobalGameDataSO globalGameDataSO;

    public float realmStayDuration;
    public string targetRealmSceneName;

    public void Interact()
    {
        Debug.Log($"Ancient Ruin Interaction");
        //int num = Random.Range(0, globalGameDataSO.ancientRuinListe.Length);
        //BaseAncientRuinData selectedRuin = globalGameDataSO.ancientRuinListe[num];

        //realmStayDuration = selectedRuin.realmStayDuration;
        //targetRealmSceneName = selectedRuin.targetRealmSceneName;
        //StartCoroutine(TeleportToRealm(realmStayDuration));
        //SceneManager.LoadScene($"{selectedRuin.targetRealmSceneName}");
        ////globalGameDataSO.ancientRuinListe[num];

    }

    //private IEnumerator TeleportToRealm(float realmStayDuration)
    //{
    //    AsyncOperation loadOperation = SceneManager.LoadSceneAsync(targetRealmSceneName, LoadSceneMode.Additive);
    //    while (!loadOperation.isDone)
    //    {
    //        yield return null;
    //    }
    //    yield return new WaitForSeconds(5);

    //    AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(targetRealmSceneName);
    //    while (!unloadOperation.isDone)
    //    {
    //        yield return null;
    //    }
    //}
}
