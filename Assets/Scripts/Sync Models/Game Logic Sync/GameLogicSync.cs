using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class GameLogicSync : RealtimeComponent<GameLogicSyncModel>
{

    private GameLogic _gameLogic;

    private void Awake()
    {
        _gameLogic = GetComponent<GameLogic>();
    }

    protected override void OnRealtimeModelReplaced(GameLogicSyncModel previousModel, GameLogicSyncModel currentModel) {

        if (previousModel != null) {
            previousModel.gameModeDidChange -= GameModeDidChange;
            previousModel.isPlayersConnectedAndTeamsAssignedDidChange -= IsPlayersConnectedAndTeamsAssignedDidChange;
            previousModel.isPlayersReadyToStartGameDidChange -= IsPlayersReadyToStartGameDidChange;
            previousModel.isGameStartDidChange -= IsGameStartDidChange;
            previousModel.isRoundStartedDidChange -= IsRoundStartedDidChange;
            previousModel.gameWinnerDidChange -= GameWinnerDidChange;
            previousModel.teamSizeDidChange -= TeamSizeDidChange;
            previousModel.roundTotalTimeDidChange -= RoundTotalTimeDidChange;
            previousModel.roundStartTimeDidChange -= RoundStartTimeDidChange;
            previousModel.roundElapsedTimeDidChange -= RoundElapsedTimeDidChange;
            previousModel.team1ScoreDidChange -= Team1ScoreDidChange;
            previousModel.team2ScoreDidChange -= Team2ScoreDidChange;
            previousModel.roundCurrentDidChange -= RoundCurrentDidChange;
            previousModel.roundsPlayedDidChange -= RoundsPlayedDidChange;
            previousModel.roundsTotalDidChange -= RoundsTotalDidChange;
            previousModel.team1KillsDidChange -= Team1KillsDidChange;
            previousModel.team2KillsDidChange -= Team2KillsDidChange;
            previousModel.team1TotalKillsDidChange -= Team1TotalKillsDidChange;
            previousModel.team2TotalKillsDidChange -= Team2TotalKillsDidChange;
            previousModel.team1PlayerCountDidChange -= Team1PlayerCountDidChange;
            previousModel.team2PlayerCountDidChange -= Team2PlayerCountDidChange;
        }

        if (currentModel != null) {
            if (currentModel.isFreshModel) {
                currentModel.gameMode = _gameLogic._gameMode;
                currentModel.isPlayersConnectedAndTeamsAssigned = _gameLogic._isPlayersConnectedAndTeamsAssigned;
                currentModel.isPlayersReadyToStartGame = _gameLogic._isPlayersReadyToStartGame;
                currentModel.isGameStart = _gameLogic._isGameStart;
                currentModel.isRoundStarted = _gameLogic._isRoundStarted;
                currentModel.gameWinner = _gameLogic._gameWinner;
                currentModel.teamSize = _gameLogic._teamSize;
                currentModel.roundTotalTime = _gameLogic._roundTotalTime;
                currentModel.roundStartTime = _gameLogic._roundStartTime;
                currentModel.roundElapsedTime = _gameLogic._roundElapsedTime;
                currentModel.team1Score = _gameLogic._team1Score;
                currentModel.team2Score = _gameLogic._team2Score;
                currentModel.roundCurrent = _gameLogic._roundCurrent;
                currentModel.roundsPlayed = _gameLogic._roundsPlayed;
                currentModel.roundsTotal = _gameLogic._roundsTotal;
                currentModel.team1Kills = _gameLogic._team1Kills;
                currentModel.team2Kills = _gameLogic._team2Kills;
                currentModel.team1TotalKills = _gameLogic._team1TotalKills;
                currentModel.team2TotalKills = _gameLogic._team2TotalKills;
                currentModel.team1PlayerCount = _gameLogic._team1PlayerCount;
                currentModel.team2PlayerCount = _gameLogic._team2PlayerCount;
            }

            UpdateGameMode();
            UpdateIsPlayersConnectedAndTeamsAssigned();
            UpdateIsPlayersReadyToStartGame();
            UpdateIsGameStart();
            UpdateIsRoundStarted();
            UpdateGameWinner();
            UpdateTeamSize();
            UpdateRoundTotalTime();
            UpdateRoundStartTime();
            UpdateRoundElapsedTime();
            UpdateTeam1Score();
            UpdateTeam2Score();
            UpdateRoundCurrent();
            UpdateRoundsPlayed();
            UpdateRoundsTotal();
            UpdateTeam1Kills();
            UpdateTeam2Kills();
            UpdateTeam1TotalKills();
            UpdateTeam2TotalKills();
            UpdateTeam1PlayerCount();
            UpdateTeam2PlayerCount();

            currentModel.gameModeDidChange += GameModeDidChange;
            currentModel.isPlayersConnectedAndTeamsAssignedDidChange += IsPlayersConnectedAndTeamsAssignedDidChange;
            currentModel.isPlayersReadyToStartGameDidChange += IsPlayersReadyToStartGameDidChange;
            currentModel.isGameStartDidChange += IsGameStartDidChange;
            currentModel.isRoundStartedDidChange += IsRoundStartedDidChange;
            currentModel.gameWinnerDidChange += GameWinnerDidChange;
            currentModel.teamSizeDidChange += TeamSizeDidChange;
            currentModel.roundTotalTimeDidChange += RoundTotalTimeDidChange;
            currentModel.roundStartTimeDidChange += RoundStartTimeDidChange;
            currentModel.roundElapsedTimeDidChange += RoundElapsedTimeDidChange;
            currentModel.team1ScoreDidChange += Team1ScoreDidChange;
            currentModel.team2ScoreDidChange += Team2ScoreDidChange;
            currentModel.roundCurrentDidChange += RoundCurrentDidChange;
            currentModel.roundsPlayedDidChange += RoundsPlayedDidChange;
            currentModel.roundsTotalDidChange += RoundsTotalDidChange;
            currentModel.team1KillsDidChange += Team1KillsDidChange;
            currentModel.team2KillsDidChange += Team2KillsDidChange;
            currentModel.team1TotalKillsDidChange += Team1TotalKillsDidChange;
            currentModel.team2TotalKillsDidChange += Team2TotalKillsDidChange;
            currentModel.team1PlayerCountDidChange += Team1PlayerCountDidChange;
            currentModel.team2PlayerCountDidChange += Team2PlayerCountDidChange;

        }
    }
    
    private void GameModeDidChange(GameLogicSyncModel model, int value)
    {
        UpdateGameMode();
    }

    private void IsPlayersConnectedAndTeamsAssignedDidChange(GameLogicSyncModel model, bool value)
    {
        UpdateIsPlayersConnectedAndTeamsAssigned();
    }

    private void IsPlayersReadyToStartGameDidChange(GameLogicSyncModel model, bool value)
    {
        UpdateIsPlayersReadyToStartGame();
    }

    private void IsGameStartDidChange(GameLogicSyncModel model, bool value)
    {
        UpdateIsGameStart();
    }

    private void IsRoundStartedDidChange(GameLogicSyncModel model, bool value)
    {
        UpdateIsRoundStarted();
    }

    private void GameWinnerDidChange(GameLogicSyncModel model, int value)
    {
        UpdateGameWinner();
    }

    private void TeamSizeDidChange(GameLogicSyncModel model, int value)
    {
        UpdateTeamSize();
    }

    private void RoundTotalTimeDidChange(GameLogicSyncModel model, float value)
    {
        UpdateRoundTotalTime();
    }

    private void RoundStartTimeDidChange(GameLogicSyncModel model, float value)
    {
        UpdateRoundStartTime();
    }

    private void RoundElapsedTimeDidChange(GameLogicSyncModel model, float value)
    {
        UpdateRoundElapsedTime();
    }

    private void Team1ScoreDidChange(GameLogicSyncModel model, int value)
    {
        UpdateTeam1Score();
    }

    private void Team2ScoreDidChange(GameLogicSyncModel model, int value)
    {
        UpdateTeam2Score();
    }

    private void RoundCurrentDidChange(GameLogicSyncModel model, int value)
    {
        UpdateRoundCurrent();
    }

    private void RoundsPlayedDidChange(GameLogicSyncModel model, int value)
    {
        UpdateRoundsPlayed();
    }

    private void RoundsTotalDidChange(GameLogicSyncModel model, int value)
    {
        UpdateRoundsTotal();
    }

    private void Team1KillsDidChange(GameLogicSyncModel model, float value)
    {
        UpdateTeam1Kills();
    }

    private void Team2KillsDidChange(GameLogicSyncModel model, float value)
    {
        UpdateTeam2Kills();
    }

    private void Team1TotalKillsDidChange(GameLogicSyncModel model, float value)
    {
        UpdateTeam1TotalKills();
    }

    private void Team2TotalKillsDidChange(GameLogicSyncModel model, float value)
    {
        UpdateTeam2TotalKills();
    }

    private void Team1PlayerCountDidChange(GameLogicSyncModel model, float value)
    {
        UpdateTeam1PlayerCount();
    }

    private void Team2PlayerCountDidChange(GameLogicSyncModel model, float value)
    {
        UpdateTeam2PlayerCount();
    }












    private void UpdateGameMode() {
        _gameLogic._gameMode = model.gameMode;
    }

    private void UpdateIsPlayersConnectedAndTeamsAssigned() {
        _gameLogic._isPlayersConnectedAndTeamsAssigned = model.isPlayersConnectedAndTeamsAssigned;
    }

    private void UpdateIsPlayersReadyToStartGame() {
        _gameLogic._isPlayersReadyToStartGame = model.isPlayersReadyToStartGame;
    }

    private void UpdateIsGameStart() {
        _gameLogic._isGameStart = model.isGameStart;
    }

    private void UpdateIsRoundStarted() {
        _gameLogic._isRoundStarted = model.isRoundStarted;
    }

    private void UpdateGameWinner() {
        _gameLogic._gameWinner = model.gameWinner;
    }

    private void UpdateTeamSize() {
        _gameLogic._teamSize = model.teamSize;
    }

    private void UpdateRoundTotalTime() {
        _gameLogic._roundTotalTime = model.roundTotalTime;
    }

    private void UpdateRoundStartTime() {
        _gameLogic._roundStartTime = model.roundStartTime;
    }

    private void UpdateRoundElapsedTime() {
        _gameLogic._roundElapsedTime = model.roundElapsedTime;
    }

    private void UpdateTeam1Score() {
        _gameLogic._team1Score = model.team1Score;
    }

    private void UpdateTeam2Score() {
        _gameLogic._team2Score = model.team2Score;
    }

    private void UpdateRoundCurrent() {
        _gameLogic._roundCurrent = model.roundCurrent;
    }

    private void UpdateRoundsPlayed() {
        _gameLogic._roundsPlayed = model.roundsPlayed;
    }

    private void UpdateRoundsTotal() {
        _gameLogic._roundsTotal = model.roundsTotal;
    }

    private void UpdateTeam1Kills() {
        _gameLogic._team1Kills = model.team1Kills;
    }

    private void UpdateTeam2Kills() {
        _gameLogic._team2Kills = model.team2Kills;
    }

    private void UpdateTeam1TotalKills() {
        _gameLogic._team1TotalKills = model.team1TotalKills;
    }

    private void UpdateTeam2TotalKills() {
        _gameLogic._team2TotalKills = model.team2TotalKills;
    }

    private void UpdateTeam1PlayerCount()
    {
        _gameLogic._team1PlayerCount = model.team1PlayerCount;
    }

    private void UpdateTeam2PlayerCount()
    {
        _gameLogic._team2PlayerCount = model.team2PlayerCount;
    }






    public void SetGameMode(int gameMode) {
        model.gameMode = gameMode;
    }
    
    public void SetIsPlayersConnectedAndTeamsAssigned(bool isPlayersConnectedAndTeamsAssigned) {
        model.isPlayersConnectedAndTeamsAssigned = isPlayersConnectedAndTeamsAssigned;
    }

    public void SetIsPlayersReadyToStartGame(bool isPlayersReadyToStartGame) {
        model.isPlayersReadyToStartGame = isPlayersReadyToStartGame;
    }

    public void SetIsGameStart(bool isGameStart) {
        model.isGameStart = isGameStart;
    }

    public void SetIsRoundStarted(bool isRoundStarted) {
        model.isRoundStarted = isRoundStarted;
    } 

    public void SetGameWinner(int gameWinner) {
        model.gameWinner = gameWinner;
    }

    public void SetTeamSize(int teamSize) {
        model.teamSize = teamSize;
    }

    public void SetRoundTotalTime(float roundTotalTime) {
        model.roundTotalTime = roundTotalTime;
    }

    public void SetRoundStartTime(float roundStartTime) {
        model.roundStartTime = roundStartTime;
    }

    public void SetRoundElapsedTime(float roundElapsedTime) {
        model.roundElapsedTime = roundElapsedTime;
    }

    public void SetTeam1Score(int team1Score) {
        model.team1Score = team1Score;
    }

    public void SetTeam2Score(int team2Score) {
        model.team2Score = team2Score;
    }
    
    public void SetRoundCurrent(int roundCurrent) {
        model.roundCurrent = roundCurrent;
    }

    public void SetRoundsPlayed(int roundsPlayed) {
        model.roundsPlayed = roundsPlayed;
    }

    public void SetRoundsTotal(int roundsTotal) {
        model.roundsTotal = roundsTotal;
    }

    public void SetTeam1Kills(float team1Kills) {
        model.team1Kills = team1Kills;
    }
    
    public void SetTeam2Kills(float team2Kills) {
        model.team2Kills = team2Kills;
    }

    public void SetTeam1TotalKills(float team1TotalKills) {
        model.team1TotalKills = team1TotalKills;
    }
    
    public void SetTeam2TotalKills(float team2TotalKills) {
        model.team2TotalKills = team2TotalKills;
    }

    public void SetTeam1PlayerCount(float team1PlayerCount)
    {
        model.team1PlayerCount = team1PlayerCount;
    }
    public void SetTeam2PlayerCount(float team2PlayerCount)
    {
        model.team2PlayerCount = team2PlayerCount;
    }

}
