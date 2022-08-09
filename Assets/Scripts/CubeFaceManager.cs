using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "CubeFaceManager", menuName = "ScriptableObjects/ Cube Face Manager")]
public class CubeFaceManager : SerializedScriptableObject
{
    public List<Sprite> cubeFaces;
}