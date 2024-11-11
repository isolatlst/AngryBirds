using System.Collections.Generic;
using Bird;
using UnityEngine;

[CreateAssetMenu(fileName = "Level-", menuName = "Levels/New Level")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private AbstractBird[] _birds = new AbstractBird[3];

    public Queue<AbstractBird> Birds
    {
        get
        {
            var copy = new Queue<AbstractBird>();
            
            for (int i = 0; i < _birds.Length; i++)
            {
                copy.Enqueue(_birds[i]);
            }
            
            return copy;
        }
    }
}