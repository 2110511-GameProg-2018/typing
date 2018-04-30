using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers : MonoBehaviour {

	private ComboController _comboController;
	private GameController _gameController;
	private SFXController _sfxController;
	private StatController _statController;
	private TypingController _typingController;
	private WeaponController _weaponController;

	// Getters 
	public ComboController comboController {
		get {return _comboController; }
	}

	public GameController gameController {
		get {return _gameController; }
	}

	public SFXController sfxController {
		get {return _sfxController; }
	}

	public StatController statController {
		get {return _statController; }
	}

	public TypingController typingController {
		get {return _typingController; }
	}

	public WeaponController WeaponController {
		get {return _weaponController; }
	}

	// Use this for initialization
	void Awake () {
		_comboController = GetComponentInChildren<ComboController>();
		_gameController = GetComponentInChildren<GameController>();
		_sfxController = GetComponentInChildren<SFXController>();
		_statController = GetComponentInChildren<StatController>();
		_typingController = GetComponentInChildren<TypingController>();
		_weaponController = GetComponentInChildren<WeaponController>();
	}
}
