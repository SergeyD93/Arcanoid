using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SoundManager : MonoBehaviour 
{
	public const string COMMON_SOUND_LOOSE_LIFE = "loseLife";
	public const string COMMON_SOUND_TAKE_POINT = "points";

	private static SoundManager _instance;
	public static SoundManager instance { get { return _instance; } }
	
	public List<AudioClip>commonSoundsList;
	public List<AudioClip>backgroundMusicList;
	public List<AudioClip>hitSoundList;

	public	enum SoundTipe {CommonSound, BackgroundMusic, HitSound, Unknown};

	void Awake()
	{
		_instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		playBackgroundMusic();
	}

	public void playBackgroundMusic()
	{
		//if(UserData.musicOnTrigger)
		//{
			System.Random rnd = new System.Random();
			rnd.Next(0,backgroundMusicList.Count);
			GetComponent<AudioSource>().clip = backgroundMusicList[rnd.Next(0,backgroundMusicList.Count)];
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().loop = true;
		//}
	}

	public void playHitSound ()
	{
		//if(UserData.soundsOnTrigger)
		//{
			if(hitSoundList.Count != 0)
			{
				System.Random rnd = new System.Random();
				rnd.Next(hitSoundList.Count);
				GetComponent<AudioSource>().PlayOneShot(hitSoundList[rnd.Next(hitSoundList.Count)]);
			}
			
			else
			{
				Debug.LogError("[SoundManager] There is no hit sounds");
			}
		//}
	}
	
	public void playSound(string name, SoundTipe soundTipe = SoundTipe.Unknown)
	{
		//if(UserData.soundsOnTrigger)
		//{
			AudioClip audioClip = getSoundByName(name, soundTipe);

			if(audioClip)
			{
				GetComponent<AudioSource>().PlayOneShot(audioClip);
			}
		//}
	}

	public AudioClip getSoundByName(string name,SoundTipe soundTipe = SoundTipe.Unknown)
	{
		if (soundTipe == SoundTipe.BackgroundMusic)
		{
			foreach(AudioClip audioClip in backgroundMusicList)
			{
				if(audioClip && audioClip.name == name)
				{
					return audioClip;
				}
			}
		}
		else if (soundTipe == SoundTipe.CommonSound)
		{
			foreach(AudioClip audioClip in commonSoundsList)
			{
				if(audioClip && audioClip.name == name)
				{
					return audioClip;
				}
			}
		}
		else if(soundTipe == SoundTipe.HitSound)
		{
			foreach(AudioClip audioClip in hitSoundList)
			{
				if(audioClip && audioClip.name == name)
				{
					return audioClip;
				}
			}
		}

		else
		{
			foreach(AudioClip audioClip in backgroundMusicList)
			{
				if(audioClip && audioClip.name == name)
				{
					return audioClip;
				}
			}
			foreach(AudioClip audioClip in commonSoundsList)
			{
				if(audioClip && audioClip.name == name)
				{
					return audioClip;
				}
			}
			foreach(AudioClip audioClip in hitSoundList)
			{
				if(audioClip && audioClip.name == name)
				{
					return audioClip;
				}
			}
		}

		Debug.LogError("[SoundManager]There is no sound with name: " + name);
		return null;
	}

	public void backgroundMusicSwitch(bool trigger)
	{
		if(!trigger)
		{
			GetComponent<AudioSource>().clip = null;
		}
		else
		{
			playBackgroundMusic();
		}
	}
}
