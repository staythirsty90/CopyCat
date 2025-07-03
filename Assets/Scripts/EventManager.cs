// ******* GENERATED FILE. DO NOT MODIFY  *******
// ******* SEE EventInterfaceGenerator.cs *******

using UnityEngine;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {
	MonoBehaviour[] monoBehaviours;
	List<MonoBehaviour> IOnFall_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnFalling_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnGameBegin_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnGameInitialized_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnGameOver_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnGamePlaying_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnGameRestart_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnGameRestarted_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnJumping_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnMedalAwarded_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnNewHighScore_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnPlayerHitGround_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnPlayerJump_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnPlayerKilled_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnScorePoint_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnSettingsClose_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnSettingsOpen_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnUpdate_list = new List<MonoBehaviour>();
	List<MonoBehaviour> IOnWorldChanged_list = new List<MonoBehaviour>();

	void Awake() {
		monoBehaviours = FindObjectsOfType<MonoBehaviour>();
		foreach(var mono in monoBehaviours){
			if(mono is IOnFall) IOnFall_list.Add(mono);
			if(mono is IOnFalling) IOnFalling_list.Add(mono);
			if(mono is IOnGameBegin) IOnGameBegin_list.Add(mono);
			if(mono is IOnGameInitialized) IOnGameInitialized_list.Add(mono);
			if(mono is IOnGameOver) IOnGameOver_list.Add(mono);
			if(mono is IOnGamePlaying) IOnGamePlaying_list.Add(mono);
			if(mono is IOnGameRestart) IOnGameRestart_list.Add(mono);
			if(mono is IOnGameRestarted) IOnGameRestarted_list.Add(mono);
			if(mono is IOnJumping) IOnJumping_list.Add(mono);
			if(mono is IOnMedalAwarded) IOnMedalAwarded_list.Add(mono);
			if(mono is IOnNewHighScore) IOnNewHighScore_list.Add(mono);
			if(mono is IOnPlayerHitGround) IOnPlayerHitGround_list.Add(mono);
			if(mono is IOnPlayerJump) IOnPlayerJump_list.Add(mono);
			if(mono is IOnPlayerKilled) IOnPlayerKilled_list.Add(mono);
			if(mono is IOnScorePoint) IOnScorePoint_list.Add(mono);
			if(mono is IOnSettingsClose) IOnSettingsClose_list.Add(mono);
			if(mono is IOnSettingsOpen) IOnSettingsOpen_list.Add(mono);
			if(mono is IOnUpdate) IOnUpdate_list.Add(mono);
			if(mono is IOnWorldChanged) IOnWorldChanged_list.Add(mono);
		}
	}

	public void NotifyListeners_OnFall() {
		foreach (var listener in IOnFall_list){
			((IOnFall)listener).OnFall();
		}
	}

	public void NotifyListeners_OnFalling() {
		foreach (var listener in IOnFalling_list){
			((IOnFalling)listener).OnFalling();
		}
	}

	public void NotifyListeners_OnGameBegin() {
		foreach (var listener in IOnGameBegin_list){
			((IOnGameBegin)listener).OnGameBegin();
		}
	}

	public void NotifyListeners_OnGameInitialized() {
		foreach (var listener in IOnGameInitialized_list){
			((IOnGameInitialized)listener).OnGameInitialized();
		}
	}

	public void NotifyListeners_OnGameOver() {
		foreach (var listener in IOnGameOver_list){
			((IOnGameOver)listener).OnGameOver();
		}
	}

	public void NotifyListeners_OnGamePlaying() {
		foreach (var listener in IOnGamePlaying_list){
			((IOnGamePlaying)listener).OnGamePlaying();
		}
	}

	public void NotifyListeners_OnGameRestart() {
		foreach (var listener in IOnGameRestart_list){
			((IOnGameRestart)listener).OnGameRestart();
		}
	}

	public void NotifyListeners_OnGameRestarted() {
		foreach (var listener in IOnGameRestarted_list){
			((IOnGameRestarted)listener).OnGameRestarted();
		}
	}

	public void NotifyListeners_OnJumping() {
		foreach (var listener in IOnJumping_list){
			((IOnJumping)listener).OnJumping();
		}
	}

	public void NotifyListeners_OnMedalAwarded() {
		foreach (var listener in IOnMedalAwarded_list){
			((IOnMedalAwarded)listener).OnMedalAwarded();
		}
	}

	public void NotifyListeners_OnNewHighScore() {
		foreach (var listener in IOnNewHighScore_list){
			((IOnNewHighScore)listener).OnNewHighScore();
		}
	}

	public void NotifyListeners_OnPlayerHitGround() {
		foreach (var listener in IOnPlayerHitGround_list){
			((IOnPlayerHitGround)listener).OnPlayerHitGround();
		}
	}

	public void NotifyListeners_OnPlayerJump() {
		foreach (var listener in IOnPlayerJump_list){
			((IOnPlayerJump)listener).OnPlayerJump();
		}
	}

	public void NotifyListeners_OnPlayerKilled() {
		foreach (var listener in IOnPlayerKilled_list){
			((IOnPlayerKilled)listener).OnPlayerKilled();
		}
	}

	public void NotifyListeners_OnScorePoint(System.Int32 score) {
		foreach (var listener in IOnScorePoint_list){
			((IOnScorePoint)listener).OnScorePoint(score);
		}
	}

	public void NotifyListeners_OnSettingsClose() {
		foreach (var listener in IOnSettingsClose_list){
			((IOnSettingsClose)listener).OnSettingsClose();
		}
	}

	public void NotifyListeners_OnSettingsOpen() {
		foreach (var listener in IOnSettingsOpen_list){
			((IOnSettingsOpen)listener).OnSettingsOpen();
		}
	}

	public void NotifyListeners_OnUpdate() {
		foreach (var listener in IOnUpdate_list){
			((IOnUpdate)listener).OnUpdate();
		}
	}

	public void NotifyListeners_OnWorldChanged(System.Int32 colorIndex) {
		foreach (var listener in IOnWorldChanged_list){
			((IOnWorldChanged)listener).OnWorldChanged(colorIndex);
		}
	}

}
// ******* END OF GENERATED FILE. ******* 
