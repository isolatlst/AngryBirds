using System;
using UnityEngine;

namespace Bird.Source
{
    public class BirdSource : MonoBehaviour // fixme
    {
        [SerializeField] private AbstractBird[] _birdsArr;
        private int counter = 0;
        // private Queue<AbstractBird> _birds;
        
        // private void Start()
        // {
        //     var level = Resources.Load<LevelInfo>("Levels/Level-1"); //fixme
        //     BirdsCount = level.Birds.Count;
        //     _birds = level.Birds;
        // }
        
        public AbstractBird GetBird()
        {
            if (counter == _birdsArr.Length)
            {
                throw new IndexOutOfRangeException("Bird array is empty");
                return null;
            }
            // var bird = _birds.Dequeue();
            var bird = _birdsArr[counter];            
            counter++;
            
            return Instantiate(bird, transform);
        }
    }
}