using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
		if (StaticData.isMusic)
		{
            music.Play();
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (StaticData.isMusic )
		{
			if (!music.isPlaying)
			{
                music.Play();
			}
        }
		else
		{
            music.Stop();
		}
    }
}
