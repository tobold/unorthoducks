using UnityEngine;

namespace Unorthoducks
{
	[RequireComponent(typeof(AudioSource))]
	public class SoundManager : MonoBehaviour
	{
    public AudioSource[] sounds;

    public void InitialiseQuacks (AudioSource[] soundArray)
    {
      sounds = soundArray;
      float randomQuackTime = Random.Range(1f, 6f);
      Invoke("Quack", randomQuackTime);
    }

    public void Quack ()
    {
      int randomSample = Random.Range(0, 3);
      sounds[randomSample].Play();
      float randomQuackTime = Random.Range(5f, 10f);
      Invoke("Quack", randomQuackTime);
    }

  }
}
