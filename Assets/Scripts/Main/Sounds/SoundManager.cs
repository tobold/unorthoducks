using UnityEngine;

namespace Unorthoducks
{
	[RequireComponent(typeof(AudioSource))]
	public class SoundManager : MonoBehaviour
	{
    public AudioSource[] biteSounds;
		public AudioSource[] quackSounds;

    public void InitialiseQuacks (AudioSource[] soundArray)
    {
      quackSounds = soundArray;
      float randomQuackTime = Random.Range(1f, 6f);
      Invoke("Quack", randomQuackTime);
    }

    public void Quack ()
    {
      int randomSample = Random.Range(0, 3);
      quackSounds[randomSample].Play();
      float randomQuackTime = Random.Range(5f, 10f);
      Invoke("Quack", randomQuackTime);
    }

    public void BiteSound (AudioSource[] soundArray)
    {
      biteSounds = soundArray;
      biteSounds[4].Play();
    }
  }
}
