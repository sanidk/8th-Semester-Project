using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    public int _gameMode = default;
    public int _previousGameMode = default;

    [SerializeField]
    public bool _isPlayersConnectedAndTeamsAssigned = default;
    public bool _previousIsPlayersConnectedAndTeamsAssigned = default;

    [SerializeField]
    public bool _isPlayersReadyToStartGame = default;
    public bool _previousIsPlayersReadyToStartGame = default;

    [SerializeField]
    public bool _isGameStart = default;
    public bool _previousIsGameStart = default;

    [SerializeField]
    public bool _isRoundStarted = default;
    public bool _previousIsRoundStarted = default;

    [SerializeField]
    public int _gameWinner = default;
    public int _previousGameWinner = default;

    [SerializeField]
    public int _teamSize = default;
    public int _previousTeamSize = default;

    [SerializeField]
    public float _roundTotalTime = default;
    public float _previousRoundTotalTime = default;

    [SerializeField]
    public float _roundStartTime = default;
    public float _previousRoundStartTime = default;

    [SerializeField]
    public float _roundElapsedTime = default;
    public float _previousRoundElapsedTime = default;

    [SerializeField]
    public int _team1Score = default;
    public int _previousTeam1Score = default;

    [SerializeField]
    public int _team2Score = default;
    public int _previousTeam2Score = default;

    [SerializeField]
    public int _roundCurrent = default;
    public int _previousRoundCurrent = default;

    [SerializeField]
    public int _roundsPlayed = default;
    public int _previousRoundsPlayed = default;

    [SerializeField]
    public int _roundsTotal = default;
    public int _previousRoundsTotal = default;

    [SerializeField]
    public float _team1Kills = default;
    public float _previousTeam1Kills = default;

    [SerializeField]
    public float _team2Kills = default;
    public float _previousTeam2Kills = default;

    [SerializeField]
    public float _team1TotalKills = default;
    public float _previousTeam1TotalKills = default;

    [SerializeField]
    public float _team2TotalKills = default;
    public float _previousTeam2TotalKills = default;

    [SerializeField]
    public float _team1PlayerCount = default;
    public float _previousTeam1PlayerCount = default;

    [SerializeField]
    public float _team2PlayerCount = default;
    public float _previousTeam2PlayerCount = default;


    public GameLogicSync _gameLogicSync;

    private void Awake()
    {
        _gameLogicSync = GetComponent<GameLogicSync>();       
    }

    private void Update()
    {
        

        if (_gameMode != _previousGameMode)
        {
            _gameLogicSync.SetGameMode(_gameMode);
            _previousGameMode = _gameMode;
        }

        if (_isPlayersConnectedAndTeamsAssigned != _previousIsPlayersConnectedAndTeamsAssigned)
        {
            _gameLogicSync.SetIsPlayersConnectedAndTeamsAssigned(_isPlayersConnectedAndTeamsAssigned);
            _previousIsPlayersConnectedAndTeamsAssigned = _isPlayersConnectedAndTeamsAssigned;
        }

        if (_isPlayersReadyToStartGame != _previousIsPlayersReadyToStartGame)
        {
            _gameLogicSync.SetIsPlayersReadyToStartGame(_isPlayersReadyToStartGame);
            _previousIsPlayersReadyToStartGame = _isPlayersReadyToStartGame;
        }

        if (_isGameStart != _previousIsGameStart)
        {
            _gameLogicSync.SetIsGameStart(_isGameStart);
            _previousIsGameStart = _isGameStart;
        }

        if (_isRoundStarted != _previousIsRoundStarted)
        {
            _gameLogicSync.SetIsRoundStarted(_isRoundStarted);
            _previousIsRoundStarted = _isRoundStarted;
        }

        if (_isRoundStarted != _previousIsRoundStarted)
        {
            _gameLogicSync.SetIsRoundStarted(_isRoundStarted);
            _previousIsRoundStarted = _isRoundStarted;
        }

        if (_gameWinner != _previousGameWinner)
        {
            _gameLogicSync.SetGameWinner(_gameWinner);
            _previousGameWinner = _gameWinner;
        }

        if (_teamSize != _previousTeamSize)
        {
            _gameLogicSync.SetTeamSize(_teamSize);
            _previousTeamSize = _teamSize;
        }

        if (_roundTotalTime != _previousRoundTotalTime)
        {
            _gameLogicSync.SetRoundTotalTime(_roundTotalTime);
            _previousRoundTotalTime = _roundTotalTime;
        }

        if (_roundStartTime != _previousRoundStartTime)
        {
            _gameLogicSync.SetRoundStartTime(_roundStartTime);
            _previousRoundStartTime = _roundStartTime;
        }

        if (_roundElapsedTime != _previousRoundElapsedTime)
        {
            _gameLogicSync.SetRoundElapsedTime(_roundElapsedTime);
            _previousRoundElapsedTime = _roundElapsedTime;
        }

        if (_team1Score != _previousTeam1Score)
        {
            _gameLogicSync.SetTeam1Score(_team1Score);
            _previousTeam1Score = _team1Score;
        }

        if (_team2Score != _previousTeam2Score)
        {
            _gameLogicSync.SetTeam2Score(_team2Score);
            _previousTeam2Score = _team2Score;
        }

        if (_roundCurrent != _previousRoundCurrent)
        {
            _gameLogicSync.SetRoundCurrent(_roundCurrent);
            _previousRoundCurrent = _roundCurrent;
        }

        if (_roundsPlayed != _previousRoundsPlayed)
        {
            _gameLogicSync.SetRoundsPlayed(_roundsPlayed);
            _previousRoundsPlayed = _roundsPlayed;
        }

        if (_roundsTotal != _previousRoundsTotal)
        {
            _gameLogicSync.SetRoundsTotal(_roundsTotal);
            _previousRoundsTotal = _roundsTotal;
        }

        if (_team1Kills != _previousTeam1Kills)
        {
            _gameLogicSync.SetTeam1Kills(_team1Kills);
            _previousTeam1Kills = _team1Kills;
        }

        if (_team2Kills != _previousTeam2Kills)
        {
            _gameLogicSync.SetTeam2Kills(_team2Kills);
            _previousTeam2Kills = _team2Kills;
        }

        if (_team1TotalKills != _previousTeam1TotalKills)
        {
            _gameLogicSync.SetTeam1TotalKills(_team1TotalKills);
            _previousTeam1TotalKills = _team1TotalKills;
        }

        if (_team2TotalKills != _previousTeam2TotalKills)
        {
            _gameLogicSync.SetTeam2TotalKills(_team2TotalKills);
            _previousTeam2TotalKills = _team2TotalKills;
        }

        if (_team1PlayerCount != _previousTeam1PlayerCount)
        {
            _gameLogicSync.SetTeam1PlayerCount(_team1PlayerCount);
            _previousTeam1PlayerCount = _team1PlayerCount;
        }

        if (_team2PlayerCount != _previousTeam2PlayerCount)
        {
            _gameLogicSync.SetTeam2PlayerCount(_team2PlayerCount);
            _previousTeam2PlayerCount = _team2PlayerCount;
        }

    }
}
