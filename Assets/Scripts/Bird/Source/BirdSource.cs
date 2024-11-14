using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Bird.Source
{
    public class BirdSource : MonoBehaviour // fixme
    {
        private Queue<AbstractBaseBird> _birds;
        public int BirdCount { get; private set; }
        
        
        // public void InitializeBirds(Transform parent)
        // {
        //     var level = Resources.Load<LevelInfo>("Levels/Level-1"); //fixme
        //     _birds = level.Birds;
        //     BirdCount = level.Birds.Count;
        //     
        //     for (var i = 0; i < BirdCount; i++)
        //     {
        //         var bird = _birds.Peek();
        //         GameObject.Instantiate(
        //             bird, 
        //             parent.position + new Vector3(-1.5f * i, 0, 0), 
        //             Quaternion.identity, 
        //             parent);
        //     }
        // }
        //
        // public AbstractBaseBird GetBird() => _birds.Dequeue();
        
        private void Awake()
        {
            var level = Resources.Load<LevelInfo>("Levels/Level-1"); //fixme
            _birds = level.Birds;
            BirdCount = level.Birds.Count;
        }
        
        
        public AbstractBaseBird GetBird()
        {
            var bird = _birds.Dequeue();
            
            return Instantiate(bird, transform);
        }
    }
}