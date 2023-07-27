using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunks : MonoBehaviour
{
    [SerializeField] private List<Chunk> chunks = new List<Chunk>();

    public int GetLength()
    {
        return chunks.Count;
    }

    public Chunk GetChunk(int idChunk)
    {
        return chunks[idChunk]; //return GameObject Chunk
    }


    //Added this function for spawning chunks in one scene -->
    public void EnableChunk(int idChunk)
    {
        chunks[idChunk].gameObject.SetActive(true);
    }

    public void DisableChunk(int idChunk)
    {
        chunks[idChunk].gameObject.SetActive(false);
    }
    //<--
}
