using System.Collections;
using UnityEngine;

public class SFXController : MonoBehaviour {

	public AudioClip attackSfx;
	public AudioClip damagedSfx;

	public float volumeMin;
	public float volumeMax;

	private AudioSource source;

	void Start() {
		source = gameObject.GetComponent<AudioSource>();
	}

	public void PlayAttack() {
		float volume = Random.Range (volumeMin, volumeMax);
		source.PlayOneShot(attackSfx, volume);
	}

	public void PlayDamaged() {
		float volume = Random.Range (volumeMin, volumeMax);
		source.PlayOneShot(damagedSfx, volume);
	}
}
