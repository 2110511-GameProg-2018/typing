﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour {

	public GameObject[] weapons;
	public Button[] weaponButtons;
	public int currentWeapon;

	private Player player;

	// Use this for initialization
	void Start () {
		if (weapons.Length == 0) {
			Debug.LogError("Error: no weapons in weaponcontroller");
		}
		if (weapons.Length != weaponButtons.Length) {
			Debug.LogError("Error: weapons.length is not equal to weaponButtons.length");
		}

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		
		currentWeapon = 0;
		player.setWeapon(weapons[currentWeapon].GetComponent<Weapon>());

		// Unlock first weapon and lock the rest
		UnlockWeapon(0);
		for (int i = 1; i < weapons.Length; i++) {
			LockWeapon(i);
		}
	}
	
	public void LockWeapon(int weapon) {
		weapons[weapon].GetComponent<Weapon>().isUnlocked = false;
		weaponButtons[weapon].interactable = false;
	}
	
	public void UnlockWeapon(int weapon) {
		weapons[weapon].GetComponent<Weapon>().isUnlocked = true;
		weaponButtons[weapon].interactable = true;
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
