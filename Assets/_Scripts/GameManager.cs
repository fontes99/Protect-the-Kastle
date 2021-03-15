public class GameManager {

    public enum GameState { MENU, GAME, PAUSE, ENDGAME, HELP };

    public GameState gameState { get; private set; }

    private static GameManager _instance;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public int player_hp;
    public int kastle_hp;

    // --------------------------------------------

    public static GameManager GetInstance() {

        if(_instance == null) {

            _instance = new GameManager();
        }

        return _instance;
    }


    public void ChangeState(GameState nextState) {

        gameState = nextState;
        changeStateDelegate();
    
    }
    

    private GameManager() {

        gameState = GameState.MENU;
    
    }

}
