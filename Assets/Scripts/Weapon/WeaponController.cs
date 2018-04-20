using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public GameObject[] weapons;
	public int currentWeapon;
	public Player player;

	// Use this for initialization
	void Start () {
		if (weapons.Length == 0) {
			Debug.LogError("Error: no weapons in weaponcontroller");
		}
		
		currentWeapon = 0;
		player.setWeapon(weapons[currentWeapon].GetComponent<Weapon>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeWeapon(int weapon) {
		currentWeapon = weapon;
		hideAllWeapons();
		showWeapon(weapon);
		player.setWeapon(weapons[currentWeapon].GetComponent<Weapon>());
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
