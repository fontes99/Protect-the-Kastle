public class GameManager {

    public enum GameState { MENU, GAME, PAUSE, ENDGAME };

    public GameState gameState { get; private set; }

    private static GameManager _instance;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public int hp;

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
