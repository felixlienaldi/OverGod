using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_TurnManager : MonoBehaviour {

    public static Battle_TurnManager Instance;
    public enum e_TurnState {
        Start,
        DicePhase,
        BattlePhase,
        EnemyPhase,
        EndPhase
    }
    public e_TurnState m_TurnState;
    
    private void Awake() {
        f_Singleton();
        
    }

    public void f_Singleton() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else {
            Destroy(gameObject);
        }
    }

    public void f_NextPhase() {
       
        if (m_TurnState == e_TurnState.Start)               m_TurnState = e_TurnState.DicePhase;
        else if (m_TurnState == e_TurnState.DicePhase)      m_TurnState = e_TurnState.BattlePhase;
        else if (m_TurnState == e_TurnState.BattlePhase)    m_TurnState = e_TurnState.EnemyPhase;
        else if (m_TurnState == e_TurnState.EnemyPhase)     m_TurnState = e_TurnState.EndPhase;
        else if (m_TurnState == e_TurnState.EndPhase)       m_TurnState = e_TurnState.Start;

    }

    private void Update() {
        f_Update();
    }

    void f_Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            f_NextPhase();
        }
    }




}

                                                                                    

