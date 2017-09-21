using UnityEngine;

namespace Unorthoducks
{
	[RequireComponent(typeof(AudioSource))]
	public class Zombie : MonoBehaviour, IDuckMovementController
	{
    public GameObjectFinder objectFinder;
    public ZombieController zombieController;
		public SoundManager soundManager;
		public Vector3 direction;
		public bool eliminated;

    private void Start ()
		{
			eliminated = false;
			zombieController.SetMovementController (this);
			AudioSource[] sounds = GetComponents<AudioSource>();
      soundManager.InitialiseQuacks (sounds);
		}

    public void Update ()
		{
			Direction();
      zombieController.Move();
    }

		public void Direction ()
		{
			GameObject chasedDuck = objectFinder.GetClosestObject("Duck", transform.position, Mathf.Infinity);
			if(chasedDuck) direction = (chasedDuck.transform.position - transform.position).normalized;
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.15F);
		}

    public void Move ()
    {
			float speed = 0.5f;
			GetComponent<Rigidbody>().MovePosition(transform.position + (transform.forward * Time.deltaTime * speed));
    }

		void OnCollisionEnter (Collision col)
    {
			if(col.gameObject.tag == "Projectile" && !eliminated)
      {
				eliminated = true;
				ScoreManager.ZombieKill();
        Destroy (this.gameObject);
      }
    }
	}
}
