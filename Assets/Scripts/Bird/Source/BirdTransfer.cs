using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Bird.Source
{
    [Serializable]
    public class BirdTransfer // TODO добавить статус: в рогатку/перекат на некст позицию
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _jumpPower;

        public IEnumerator Transfer(AbstractBird bird, Vector3 targetPosition)
        {
             yield return bird.transform.DOJump(targetPosition, _jumpPower, default, _duration).WaitForCompletion();
        }
    }
}