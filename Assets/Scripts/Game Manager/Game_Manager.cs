using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    //This script is needed to save and load game data for levels

    //Resources - here are all of necessary data to save/load
    //I only added my own resources for my task
    //-->
    public Player player; //for save Player data
    public Chunks chunks;
    public Teleport teleport;
    private int _currentIDChunk = 0;
    //<--

    //Logic -->
    [SerializeField] private Text _statisticText;
    public int money;
    public int lvl;
    public int hp;
    //<--

    private void Awake()
    {
        SceneManager.sceneLoaded += LoadState;
    }

    //Save and load state -->
    public void SaveState()
    {
        //Debug.Log("Save state is completed");
    }

    public void LoadState(Scene scene, LoadSceneMode sceneMode)
    {
        //Debug.Log("Load state is completed");
        money = 150;
        hp = 100;
        lvl = 1;
        setTextStatistic();
    }
    //<--

    //Logic load levels -->
    public void LoadLevel()
    {
        int randomIntChunk = UnityEngine.Random.Range(0, chunks.GetLength());
        
        while(_currentIDChunk == randomIntChunk)
            randomIntChunk = UnityEngine.Random.Range(0, chunks.GetLength());

        Chunk newChunk = chunks.GetChunk(randomIntChunk);

        //we can Instantiate new chunk if we go to new Unity Scene (add in future if necessary)
        //But my task - just spawn chunks. So I'll just turn chunks "on" and "of"
        chunks.DisableChunk(_currentIDChunk);
        chunks.EnableChunk(randomIntChunk);
        SetPlayerPosition(newChunk.startPosPlayerX, newChunk.startPosPlayerY);
        SetTeleportPosition(newChunk.posTeleportX, newChunk.posTeleportY);

        _currentIDChunk = randomIntChunk; //save new chunk as currentChunk
    }

    private void SetPlayerPosition(int x, int y)
    {
        player.gameObject.transform.position = new Vector3(x, y, 0);
    }

    private void SetTeleportPosition(float x, float y)
    {
        teleport.gameObject.transform.position = new Vector3(x, y, 0);
    }
    //<--

    //-->Floating text statistic
    private void setTextStatistic()
    {
        _statisticText.text = "HP: " + hp + "\n" + "Money: " + money + "\n" + "Level: " + lvl;
    }
    //<--

}
