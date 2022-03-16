using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class GameLogicSync : RealtimeComponent<GameLogicSyncModel>
{
    private GameLogic _gameLogic;

    private void Awake() {

        _gameLogic = GetComponent<GameLogic>();
    }

    protected override void OnRealtimeModelReplaced(GameLogicSyncModel previousModel, GameLogicSyncModel currentModel) {

        if (previousModel != null) {

            previousModel.isPlayersReadyToStartGameDidChange -= IsPlayersReadyToStartGameDidChange;
            previousModel.isGameStartedDidChange -= IsGameStartedDidChange;
            previousModel.colorWeaponPlayer1DidChange -= ColorWeaponPlayer1DidChange;
            previousModel.colorWeaponPlayer2DidChange -= ColorWeaponPlayer2DidChange;
            previousModel.gameTimeElapsedDidChange -= GameTimeElapsedDidChange;
            previousModel.streakPlayer1DidChange -= StreakPlayer1DidChange;
            previousModel.streakPlayer2DidChange -= StreakPlayer2DidChange;
            previousModel.trapsPlayer1DidChange -= TrapsPlayer1DidChange;
            previousModel.trapsPlayer2DidChange -= TrapsPlayer2DidChange;
            previousModel.levelPlayer1DidChange -= LevelPlayer1DidChange;
            previousModel.levelPlayer2DidChange -= LevelPlayer2DidChange;
            previousModel.livesPlayer1DidChange -= LivesPlayer1DidChange;
            previousModel.livesPlayer2DidChange -= LivesPlayer2DidChange;
            previousModel.gameWinnerDidChange -= GameWinnerDidChange;
            previousModel.backupVariable1DidChange -= BackupVariable1DidChange;
            previousModel.backupVariable2DidChange -= BackupVariable2DidChange;
            previousModel.backupVariable3DidChange -= BackupVariable3DidChange;
            previousModel.backupVariable4DidChange -= BackupVariable4DidChange;
            previousModel.backupVariable5DidChange -= BackupVariable5DidChange;
            previousModel.backupVariable6DidChange -= BackupVariable6DidChange;

        }

        if (currentModel != null) {
            if (currentModel.isFreshModel)
            {
                currentModel.isPlayersReadyToStartGame = _gameLogic._isPlayersReadyToStartGame;
                currentModel.isGameStarted = _gameLogic._isGameStarted;
                currentModel.colorWeaponPlayer1 = _gameLogic._colorWeaponPlayer1;
                currentModel.colorWeaponPlayer2 = _gameLogic._colorWeaponPlayer2;
                currentModel.gameTimeElapsed = _gameLogic._gameTimeElapsed;
                currentModel.streakPlayer1 = _gameLogic._streakPlayer1;
                currentModel.streakPlayer2 = _gameLogic._streakPlayer2;
                currentModel.trapsPlayer1 = _gameLogic._trapsPlayer1;
                currentModel.trapsPlayer2 = _gameLogic._trapsPlayer2;
                currentModel.levelPlayer1 = _gameLogic._levelPlayer1;
                currentModel.levelPlayer2 = _gameLogic._levelPlayer2;
                currentModel.livesPlayer1 = _gameLogic._livesPlayer1;
                currentModel.livesPlayer2 = _gameLogic._livesPlayer2;
                currentModel.gameWinner = _gameLogic._gameWinner;
                currentModel.backupVariable1 = _gameLogic._backupVariable1;
                currentModel.backupVariable2 = _gameLogic._backupVariable2;
                currentModel.backupVariable3 = _gameLogic._backupVariable3;
                currentModel.backupVariable4 = _gameLogic._backupVariable4;
                currentModel.backupVariable5 = _gameLogic._backupVariable5;
                currentModel.backupVariable6 = _gameLogic._backupVariable6;
            }

            UpdateIsPlayersReadyToStartGame();
            UpdateIsGameStarted();
            UpdateColorWeaponPlayer1();
            UpdateColorWeaponPlayer2();
            UpdateGameTimeElapsed();
            UpdateStreakPlayer1();
            UpdateStreakPlayer2();
            UpdateTrapsPlayer1();
            UpdateTrapsPlayer2();
            UpdateLevelPlayer1();
            UpdateLevelPlayer2();
            UpdateLivesPlayer1();
            UpdateLivesPlayer2();
            UpdateGameWinner();
            UpdateBackupVariable1();
            UpdateBackupVariable2();
            UpdateBackupVariable3();
            UpdateBackupVariable4();
            UpdateBackupVariable5();
            UpdateBackupVariable6();

            currentModel.isPlayersReadyToStartGameDidChange += IsPlayersReadyToStartGameDidChange;
            currentModel.isGameStartedDidChange += IsGameStartedDidChange;
            currentModel.colorWeaponPlayer1DidChange += ColorWeaponPlayer1DidChange;
            currentModel.colorWeaponPlayer2DidChange += ColorWeaponPlayer2DidChange;
            currentModel.gameTimeElapsedDidChange += GameTimeElapsedDidChange;
            currentModel.streakPlayer1DidChange += StreakPlayer1DidChange;
            currentModel.streakPlayer2DidChange += StreakPlayer2DidChange;
            currentModel.trapsPlayer1DidChange += TrapsPlayer1DidChange;
            currentModel.trapsPlayer2DidChange += TrapsPlayer2DidChange;
            currentModel.levelPlayer1DidChange += LevelPlayer1DidChange;
            currentModel.levelPlayer2DidChange += LevelPlayer2DidChange;
            currentModel.livesPlayer1DidChange += LivesPlayer1DidChange;
            currentModel.livesPlayer2DidChange += LivesPlayer2DidChange;
            currentModel.gameWinnerDidChange += GameWinnerDidChange;
            currentModel.backupVariable1DidChange += BackupVariable1DidChange;
            currentModel.backupVariable2DidChange += BackupVariable2DidChange;
            currentModel.backupVariable3DidChange += BackupVariable3DidChange;
            currentModel.backupVariable4DidChange += BackupVariable4DidChange;
            currentModel.backupVariable5DidChange += BackupVariable5DidChange;
            currentModel.backupVariable6DidChange += BackupVariable6DidChange;
        }
    }

    // Register for changes! 

    private void IsPlayersReadyToStartGameDidChange(GameLogicSyncModel model, bool value)
    {
        UpdateIsPlayersReadyToStartGame();
    }

    private void IsGameStartedDidChange(GameLogicSyncModel model, bool value)
    {
        UpdateIsGameStarted();
    }

    private void ColorWeaponPlayer1DidChange(GameLogicSyncModel model, Color value)
    {
        UpdateColorWeaponPlayer1();
    }

    private void ColorWeaponPlayer2DidChange(GameLogicSyncModel model, Color value)
    {
        UpdateColorWeaponPlayer2();
    }

    private void GameTimeElapsedDidChange(GameLogicSyncModel model, double value)
    {
        UpdateGameTimeElapsed();
    }

    private void StreakPlayer1DidChange(GameLogicSyncModel model, int value)
    {
        UpdateStreakPlayer1();
    }

    private void StreakPlayer2DidChange(GameLogicSyncModel model, int value)
    {
        UpdateStreakPlayer2();
    }

    private void TrapsPlayer1DidChange(GameLogicSyncModel model, int value)
    {
        UpdateTrapsPlayer1();
    }

    private void TrapsPlayer2DidChange(GameLogicSyncModel model, int value)
    {
        UpdateTrapsPlayer2();
    }

    private void LevelPlayer1DidChange(GameLogicSyncModel model, int value)
    {
        UpdateLevelPlayer1();
    }

    private void LevelPlayer2DidChange(GameLogicSyncModel model, int value)
    {
        UpdateLevelPlayer2();
    }

    private void LivesPlayer1DidChange(GameLogicSyncModel model, int value)
    {
        UpdateLivesPlayer1();
    }

    private void LivesPlayer2DidChange(GameLogicSyncModel model, int value)
    {
        UpdateLivesPlayer2();
    }

    private void GameWinnerDidChange(GameLogicSyncModel model, int value)
    {
        UpdateGameWinner();
    }

    private void BackupVariable1DidChange(GameLogicSyncModel model, bool value)
    {
        UpdateBackupVariable1();
    }

    private void BackupVariable2DidChange(GameLogicSyncModel model, bool value)
    {
        UpdateBackupVariable2();
    }

    private void BackupVariable3DidChange(GameLogicSyncModel model, int value)
    {
        UpdateBackupVariable3();
    }

    private void BackupVariable4DidChange(GameLogicSyncModel model, int value)
    {
        UpdateBackupVariable4();
    }

    private void BackupVariable5DidChange(GameLogicSyncModel model, float value)
    {
        UpdateBackupVariable5();
    }

    private void BackupVariable6DidChange(GameLogicSyncModel model, float value)
    {
        UpdateBackupVariable6();
    }

    // Update functions (update model with info from GameLogic)

    private void UpdateIsPlayersReadyToStartGame()
    {
        _gameLogic._isPlayersReadyToStartGame = model.isPlayersReadyToStartGame;
    }

    private void UpdateIsGameStarted()
    {
        _gameLogic._isGameStarted = model.isGameStarted;
    }

    private void UpdateColorWeaponPlayer1()
    {
        _gameLogic._colorWeaponPlayer1 = model.colorWeaponPlayer1;
    }

    private void UpdateColorWeaponPlayer2()
    {
        _gameLogic._colorWeaponPlayer2 = model.colorWeaponPlayer2;
    }

    private void UpdateGameTimeElapsed()
    {
        _gameLogic._gameTimeElapsed = model.gameTimeElapsed;
    }

    private void UpdateStreakPlayer1()
    {
        _gameLogic._streakPlayer1 = model.streakPlayer1;
    }

    private void UpdateStreakPlayer2()
    {
        _gameLogic._streakPlayer2 = model.streakPlayer2;
    }

    private void UpdateTrapsPlayer1()
    {
        _gameLogic._trapsPlayer1 = model.trapsPlayer1;
    }

    private void UpdateTrapsPlayer2()
    {
        _gameLogic._trapsPlayer2 = model.trapsPlayer2;
    }

    private void UpdateLevelPlayer1()
    {
        _gameLogic._levelPlayer1 = model.levelPlayer1;
    }

    private void UpdateLevelPlayer2()
    {
        _gameLogic._levelPlayer2 = model.levelPlayer2;
    }

    private void UpdateLivesPlayer1()
    {
        _gameLogic._livesPlayer1 = model.livesPlayer1;
    }

    private void UpdateLivesPlayer2()
    {
        _gameLogic._livesPlayer2 = model.livesPlayer2;
    }

    private void UpdateGameWinner()
    {
        _gameLogic._gameWinner = model.gameWinner;
    }

    private void UpdateBackupVariable1()
    {
        _gameLogic._backupVariable1 = model.backupVariable1;
    }

    private void UpdateBackupVariable2()
    {
        _gameLogic._backupVariable2 = model.backupVariable2;
    }

    private void UpdateBackupVariable3()
    {
        _gameLogic._backupVariable3 = model.backupVariable3;
    }

    private void UpdateBackupVariable4()
    {
        _gameLogic._backupVariable4 = model.backupVariable4;
    }

    private void UpdateBackupVariable5()
    {
        _gameLogic._backupVariable5 = model.backupVariable5;
    }

    private void UpdateBackupVariable6()
    {
        _gameLogic._backupVariable6 = model.backupVariable6;
    }

    // GETTERS AND SETTERS

    public double GetTimeElapsed()
    {
        return model.gameTimeElapsed;
    }

    public void SetWeaponColorPlayer1(Color color)
    {
        model.colorWeaponPlayer1 = color;
    }

    public void SetWeaponColorPlayer2(Color color)
    {
        model.colorWeaponPlayer2 = color;
    }




}
