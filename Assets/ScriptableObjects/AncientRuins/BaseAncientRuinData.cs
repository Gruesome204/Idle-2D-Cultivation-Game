using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBaseAncientRuin", menuName = "RPG/World/CreateAncientRuin")]
public class BaseAncientRuinData : ScriptableObject
{
    public string ruinName;
    public Sprite ruinSprite;
    public string targetRealmScene;
    private string originalRealmScene;
    public float realmStayDuration;
    public Vector3 realmSpawnPosition = new Vector3(0, 0, 0);

}
