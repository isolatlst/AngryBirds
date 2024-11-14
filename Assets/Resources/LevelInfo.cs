using System.Collections.Generic;
using Bird;
using UnityEngine;

[CreateAssetMenu(fileName = "Level-", menuName = "Levels/New Level")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private AbstractBaseBird[] _birds = new AbstractBaseBird[3];

    public Queue<AbstractBaseBird> Birds => new Queue<AbstractBaseBird>(_birds);
}