using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerStatSync : RealtimeComponent<PlayerStatSyncModel>
{
    private PlayerStat _playerStat;

    private void Awake() {

        _playerStat = GetComponent<PlayerStat>();
    }

    protected override void OnRealtimeModelReplaced(PlayerStatSyncModel previousModel, PlayerStatSyncModel currentModel) {

        if (previousModel != null) {

        previousModel.isReadyDidChange -= IsReadyDidChange;
        previousModel.weaponColorDidChange -= WeaponColorDidChange;
        previousModel.scoreStreakDidChange -= ScoreStreakDidChange;
        previousModel.trapsSentDidChange -= TrapsSentDidChange;
        previousModel.currentLevelDidChange -= CurrentLevelDidChange;
        previousModel.livesDidChange -= LivesDidChange;
        previousModel.backupVariable1DidChange -= BackupVariable1DidChange;
        previousModel.backupVariable2DidChange -= BackupVariable2DidChange;
        previousModel.backupVariable3DidChange -= BackupVariable3DidChange;
        previousModel.backupVariable4DidChange -= BackupVariable4DidChange;
        previousModel.backupVariable5DidChange -= BackupVariable5DidChange;
        previousModel.backupVariable6DidChange -= BackupVariable6DidChange;

        }

        if (currentModel != null) {
            if (currentModel.isFreshModel) {
                currentModel.isReady = _playerStat._isReady;
                currentModel.weaponColor = _playerStat._weaponColor;
                currentModel.scoreStreak = _playerStat._scoreStreak;
                currentModel.trapsSent = _playerStat._trapsSent;
                currentModel.currentLevel = _playerStat._currentLevel;
                currentModel.lives = _playerStat._lives;
                currentModel.backupVariable1 = _playerStat._backupVariable1;
                currentModel.backupVariable2 = _playerStat._backupVariable2;
                currentModel.backupVariable3 = _playerStat._backupVariable3;
                currentModel.backupVariable4 = _playerStat._backupVariable4;
                currentModel.backupVariable5 = _playerStat._backupVariable5;
                currentModel.backupVariable6 = _playerStat._backupVariable6;
            }

            UpdateIsReady();
            UpdateWeaponColor();
            UpdateScoreStreak();
            UpdateTrapsSent();
            UpdateCurrentLevel();
            UpdateLives();
            UpdateBackupVariable1();
            UpdateBackupVariable2();
            UpdateBackupVariable3();
            UpdateBackupVariable4();
            UpdateBackupVariable5();
            UpdateBackupVariable6();

            currentModel.isReadyDidChange += IsReadyDidChange;
            currentModel.weaponColorDidChange += WeaponColorDidChange;
            currentModel.scoreStreakDidChange += ScoreStreakDidChange;
            currentModel.trapsSentDidChange += TrapsSentDidChange;
            currentModel.currentLevelDidChange += CurrentLevelDidChange;
            currentModel.livesDidChange += LivesDidChange;
            currentModel.backupVariable1DidChange += BackupVariable1DidChange;
            currentModel.backupVariable2DidChange += BackupVariable2DidChange;
            currentModel.backupVariable3DidChange += BackupVariable3DidChange;
            currentModel.backupVariable4DidChange += BackupVariable4DidChange;
            currentModel.backupVariable5DidChange += BackupVariable5DidChange;
            currentModel.backupVariable6DidChange += BackupVariable6DidChange;
        }
    }

    // Register for changes! 

    private void IsReadyDidChange(PlayerStatSyncModel model, bool value)
    {
        UpdateIsReady();
    }

    private void WeaponColorDidChange(PlayerStatSyncModel model, Color value)
    {
        UpdateWeaponColor();
    }

    private void ScoreStreakDidChange(PlayerStatSyncModel model, float value)
    {
        UpdateScoreStreak();
    }

    private void TrapsSentDidChange(PlayerStatSyncModel model, float value)
    {
        UpdateTrapsSent();
    }

    private void CurrentLevelDidChange(PlayerStatSyncModel model, int value)
    {
        UpdateCurrentLevel();
    }

    private void LivesDidChange(PlayerStatSyncModel model, int value)
    {
        UpdateLives();
    }

    private void BackupVariable1DidChange(PlayerStatSyncModel model, bool value)
    {
        UpdateBackupVariable1();
    }

    private void BackupVariable2DidChange(PlayerStatSyncModel model, bool value)
    {
        UpdateBackupVariable2();
    }

    private void BackupVariable3DidChange(PlayerStatSyncModel model, float value)
    {
        UpdateBackupVariable3();
    }

    private void BackupVariable4DidChange(PlayerStatSyncModel model, float value)
    {
        UpdateBackupVariable4();
    }

    private void BackupVariable5DidChange(PlayerStatSyncModel model, float value)
    {
        UpdateBackupVariable5();
    }

    private void BackupVariable6DidChange(PlayerStatSyncModel model, float value)
    {
        UpdateBackupVariable6();
    }

    // Update functions (update model with info from PlayerStat)

    private void UpdateIsReady()
    {
        _playerStat._isReady = model.isReady;
    }

    private void UpdateWeaponColor()
    {
        _playerStat._weaponColor = model.weaponColor;
    }

    private void UpdateScoreStreak()
    {
        _playerStat._scoreStreak = model.scoreStreak;
    }

    private void UpdateTrapsSent()
    {
        _playerStat._trapsSent = model.trapsSent;
    }

    private void UpdateCurrentLevel()
    {
        _playerStat._currentLevel = model.currentLevel;
    }

    private void UpdateLives()
    {
        _playerStat._lives = model.lives;
    }

    private void UpdateBackupVariable1()
    {
        _playerStat._backupVariable1 = model.backupVariable1;
    }

    private void UpdateBackupVariable2()
    {
        _playerStat._backupVariable2 = model.backupVariable2;
    }

    private void UpdateBackupVariable3()
    {
        _playerStat._backupVariable3 = model.backupVariable3;
    }

    private void UpdateBackupVariable4()
    {
        _playerStat._backupVariable4 = model.backupVariable4;
    }

    private void UpdateBackupVariable5()
    {
        _playerStat._backupVariable5 = model.backupVariable5;
    }

    private void UpdateBackupVariable6()
    {
        _playerStat._backupVariable6 = model.backupVariable6;
    }

    // Getters and Setters

    public bool GetIsReady() {
        return model.isReady;
    }

    public void SetIsReady(bool value) {
        model.isReady = value;
    }

    public Color GetWeaponColor() {
        return model.weaponColor;
    }

    public void SetWeaponColor(Color value) {
        model.weaponColor = value;
    }

    public float GetScoreStreak() {
        return model.scoreStreak;
    }

    public void SetScoreStreak(float value) {
        model.scoreStreak = value;
    }

    public float GetTrapsSent() {
        return model.trapsSent;
    }

    public void SetTrapsSent(float value) {
        model.trapsSent = value;
    }

    public int GetCurrentLevel() {
        return model.currentLevel;
    }

    public void SetCurrentLevel(int value) {
        model.currentLevel = value;
    }

    public int GetLives() {
        return model.lives;
    }

    public void SetLives(int value) {
        model.lives = value;
    }

}
