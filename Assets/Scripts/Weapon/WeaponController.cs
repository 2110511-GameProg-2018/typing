using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject[] weapons;
	public int currentWeapon;

	// Use this for initialization
	void Start () {
		if (weapons.Length == 0) {
			Debug.LogError("Error: no weapons in weaponcontroller");
		}
		
		currentWeapon = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeWeapon(int weapon) {
		currentWeapon = weapon;
		hideAllWeapons();
		showWeapon(weapon);
	}

	private void hideAllWeapons() {
		foreach (GameObject weapon in weapons)
		{
			weapon.active = false;
		}
	}

	private void showWeapon(int weapon) {
		weapons[weapon].active = true;
	}
}
