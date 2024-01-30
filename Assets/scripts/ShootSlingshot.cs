using System.Collections;
using UnityEngine;

namespace Assets.scripts
{
    public class ShootSlingshot : MonoBehaviour
    {
        [SerializeField] private BirdMigration _birdMigration;
        [SerializeField] private BirdBirth birdBirth;
        [SerializeField] private ShotPoint shotPoint;
        //[SerializeField] private Shooting shooting;
         [SerializeField]  private float power = 10f;
        [SerializeField] private float numberBirds = 5;


        private IEnumerator Start()
        {
            for (int i = 0; i < numberBirds; i++)
            {
                var bird = birdBirth.GetBird();
                yield return SeatBird(bird);
                yield return WaitForShot(bird);

            }
            
        }
         
        private IEnumerator SeatBird(Bird bird)
        {
            shotPoint.enabled = false;
            yield return _birdMigration.Migration(bird, shotPoint.transform.position);
            shotPoint.enabled = true;

        }

        public IEnumerator WaitForShot(Bird bird)
        {
            var isCliked = false;

            void Shot(Vector2 direction)
            {
                isCliked = true;
                bird.Flight(direction * -power);
            }

            shotPoint.onRelease.AddListener(Shot);

            while (!isCliked)
            {
                bird.transform.position = shotPoint.transform.position;
                yield return null;
            }

            shotPoint.onRelease.RemoveAllListeners();
        }
    }
}