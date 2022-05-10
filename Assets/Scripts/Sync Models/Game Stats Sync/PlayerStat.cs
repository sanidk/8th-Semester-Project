using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerStat : MonoBehaviour
{
    public PlayerStatSync _playerStatSync;
    GameObject livesUIObject;
    

    [SerializeField]
    public bool _isReady = default;
    public bool _previousIsReady = default;

    [SerializeField]
    public Color _weaponColor = default;
    public Color _previousWeaponColor = default;

    [SerializeField]
    public float _scoreStreak = default;
    public float _previousScoreStreak = default;

    [SerializeField]
    public float _trapsSent = default;
    public float _previousTrapsSent = default;

    [SerializeField]
    public int _currentLevel = default;
    public int _previousCurrentLevel = default;

    [SerializeField]
    public int _lives = default;
    public int _previousLives = default;

    //backup variable 1 used as isServer
    [SerializeField]
    public bool _backupVariable1 = default;
    public bool _previousBackupVariable1 = default;

    [SerializeField]
    public bool _backupVariable2 = default;
    public bool _previousBackupVariable2 = default;

    [SerializeField]
    public float _backupVariable3 = default;
    public float _previousBackupVariable3 = default;

    [SerializeField]
    public float _backupVariable4 = default;
    public float _previousBackupVariable4 = default;

    [SerializeField]
    public float _backupVariable5 = default;
    public float _previousBackupVariable5 = default;

    [SerializeField]
    public float _backupVariable6 = default;
    public float _previousBackupVariable6 = default;

    // Start is called before the first frame update
    void Awake()
    {
        _playerStatSync = GetComponent<PlayerStatSync>();
        livesUIObject = GameObject.Find("Lives");
    }   

    // Update is called once per frame
    void Update()
    {
        _lives = _playerStatSync.GetLives();

        /*
        if (!GameManagerLogic.isServer)
        {
            return;
        }*/
        if (_isReady != _previousIsReady)
        {
            _playerStatSync.SetIsReady(_isReady);
            _previousIsReady = _isReady;
        }
        if (_weaponColor != _previousWeaponColor)
        {
            _playerStatSync.SetWeaponColor(_weaponColor);
            _previousWeaponColor = _weaponColor;
        }
        if (_trapsSent != _previousTrapsSent)
        {
            _playerStatSync.SetTrapsSent(_trapsSent);
            _previousTrapsSent = _trapsSent;
        }
        if (_currentLevel != _previousCurrentLevel)
        {
            _playerStatSync.SetCurrentLevel(_currentLevel);
            _previousCurrentLevel = _currentLevel;
        }
        if (_lives != _previousLives)
        {
            _playerStatSync.SetLives(_lives);
            _previousLives = _lives;

            if (GetComponent<RealtimeView>().isOwnedLocallySelf)
            {
                livesUIObject.GetComponent<livesUIManager>().lives = _lives;
            }

            if (Application.platform != RuntimePlatform.Android)
            {
                if (GetComponent<RealtimeView>().isOwnedLocallySelf)
                {
                    
                    if (GetComponent<PlayerBehaviour>().playerNumber == 1)
                    {
                        TelemetryData.lives1 = _lives;
                    }
                    else if (GetComponent<PlayerBehaviour>().playerNumber == 2)
                    {
                        TelemetryData.lives2 = _lives;
                    }
                }
                    

                
            }
        }
        if (_scoreStreak != _previousScoreStreak)
        {
            _playerStatSync.SetScoreStreak(_scoreStreak);
            _previousScoreStreak = _scoreStreak;

            if (Application.platform != RuntimePlatform.Android)
            {
                
                if (GetComponent<PlayerBehaviour>().playerNumber == 1)
                {
                    TelemetryData.cubes1++;
                }
                else if (GetComponent<PlayerBehaviour>().playerNumber == 2)
                {
                    TelemetryData.cubes2++;
                }

                
            }
        }

        if (_backupVariable1 != _previousBackupVariable1)
        {
            _playerStatSync.SetBackupVariable1(_backupVariable1);
            _previousBackupVariable1 = _backupVariable1;
        }
        if (_backupVariable2 != _previousBackupVariable2)
        {
            _playerStatSync.SetBackupVariable2(_backupVariable2);
            _previousBackupVariable2 = _backupVariable2;
        }
        if (_backupVariable3 != _previousBackupVariable3)
        {
            _playerStatSync.SetBackupVariable3(_backupVariable3);
            _previousBackupVariable3 = _backupVariable3;
        }
        if (_backupVariable4 != _previousBackupVariable4)
        {
            _playerStatSync.SetBackupVariable4(_backupVariable4);
            _previousBackupVariable4 = _backupVariable4;
        }
        if (_backupVariable5 != _previousBackupVariable5)
        {
            _playerStatSync.SetBackupVariable5(_backupVariable5);
            _previousBackupVariable5 = _backupVariable5;
        }
        if (_backupVariable6 != _previousBackupVariable6)
        {
            _playerStatSync.SetBackupVariable6(_backupVariable6);
            _previousBackupVariable6 = _backupVariable6;
        }

    }

    // Remap function taken from unity forum (Don't know if we need this)
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}
