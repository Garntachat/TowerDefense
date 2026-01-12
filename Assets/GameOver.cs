using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject endGame;

    void Update() {
        if (EnemyAttackPlayer.gameEndStatus) {
            Debug.Log("end");
            endGame.SetActive(true);
        }
    }

}
