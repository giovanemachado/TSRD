using RouteTeamStudios.Utilities;
using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    BaseGameState state;
    public GameSettingsScriptableObject gameSettings;
    public GameObject currentBlock;
    public GameObject blockCam;
    public GameObject player;

    public GameObject dialogueManager;
    public bool alreadyShowIntro = false;

    public string gameOverReason = "";

    [HideInInspector] public MainMenuState MainMenuState = new MainMenuState();
    [HideInInspector] public PlayingState PlayingState = new PlayingState();
    [HideInInspector] public QuitState QuitState = new QuitState();
    [HideInInspector] public GameOverState GameOverState = new GameOverState(); 
    [HideInInspector] public CutsceneState CutsceneState = new CutsceneState();

    public BaseGameState currentState;

    public static event Action<BaseGameState> OnGameStateChange;

    void Start()
    {
        InitStateAndInvokeEvent(MainMenuState);
    }

    void Update()
    {
        state.UpdateState(this);
    }

    public void SwitchState(BaseGameState newState)
    {
        state.ExitState(this);

        InitStateAndInvokeEvent(newState);
    }

    void InitStateAndInvokeEvent(BaseGameState initState)
    {
        state = initState;
        OnGameStateChange?.Invoke(state);

        bool playingOrPaused = initState == Instance.PlayingState;
        
        gameSettings.shipCanMove = playingOrPaused;
        currentState = this.state;
        state.EnterState(this);
    }
} 

