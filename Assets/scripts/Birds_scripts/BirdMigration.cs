using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



[Serializable]
    public class BirdMigration
    {
        [SerializeField] private float animationStart = 2f;
        [SerializeField] private float animationJump = 3f;

        public IEnumerator Migration(Bird bird, Vector2 target)
        {
            yield return bird.transform.DOJump(target, animationJump, 1, animationStart).WaitForCompletion();

        }

    }

