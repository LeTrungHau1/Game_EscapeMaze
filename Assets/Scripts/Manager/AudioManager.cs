using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager<AudioManager>
{
    private float bgmFadeSpeedRate = CONST.BGM_FADE_SPEED_RATE_HIGH;

    //BGM (Background music)name, SE(sound effect) name
    private string nextBGMName;
    private string nextSEName;

    //is the bgm fading out
    private bool isFadeOut = false;

    //oudio sources for BGM and se
    public AudioSource AttachBGMSource;
    public AudioSource AttachSESource;

    //keep all audio
    private Dictionary<string, AudioClip> bgmDic, seDic;



    protected override void Awake()
    {
        base.Awake();

        //load all se & bgm from resource folder
        bgmDic = new Dictionary<string, AudioClip>();
        seDic = new Dictionary<string, AudioClip>();

        object[] bgmList = Resources.LoadAll("Audio/BGM");
        object[] seList = Resources.LoadAll("Audio/SE");

        foreach (AudioClip bgm in bgmList)
        {
            bgmDic[bgm.name] = bgm;
        }

        foreach (AudioClip se in seList)
        {
            seDic[se.name] = se;
        }

    }
    private void Start()
    {
        AttachBGMSource.volume = PlayerPrefs.GetFloat(CONST.BGM_VOLUME_KEY, CONST.BMG_VOLUME_DEFAULT);
        AttachSESource.volume = PlayerPrefs.GetFloat(CONST.SE_VOLUME_KEY, CONST.SE_VOLUME_DEFAULT);
    }

    public void PlaySE(string seName, float delay = 0.0f)//truyen ten va delay
    {
        if (!seDic.ContainsKey(seName))
        {
            Debug.LogError(seName + " there is no SE named");
            return;
        }
        nextSEName = seName;
        Invoke("DelayPlaySE", delay);
    }

    private void DelayPlaySE()
    {
        AttachSESource.PlayOneShot(seDic[nextSEName] as AudioClip);
    }




    public void PlayBGM(string bgmName, float fadeSpeedRate = CONST.BGM_FADE_SPEED_RATE_HIGH)
    {
        if (!bgmDic.ContainsKey(bgmName))
        {

            Debug.LogError(bgmName + " there is no SE named");
            return;
        }

        //BGM is not currently playing
        if (!AttachBGMSource.isPlaying)
        {
            nextBGMName = "";
            AttachBGMSource.clip = bgmDic[bgmName] as AudioClip;
            AttachBGMSource.Play();
        }

        //BGM is Playing
        else if (AttachBGMSource.clip.name != bgmName)
        {
            nextBGMName = bgmName;
            FadeOutBGM(fadeSpeedRate);
        }

    }
    public void FadeOutBGM(float fadeSpeedRate = CONST.BGM_FADE_SPEED_RATE_HIGH)
    {
        bgmFadeSpeedRate = fadeSpeedRate;
        isFadeOut = true;
    }
    private void Update()
    {
        if (!isFadeOut)
        {
            return;
        }

        //gradually lower the volume, when the volume reaches 0 play the next BGM
        AttachBGMSource.volume -= Time.deltaTime * bgmFadeSpeedRate;
        if (AttachBGMSource.volume <= 0)
        {
            AttachBGMSource.Stop();
            AttachBGMSource.volume = PlayerPrefs.GetFloat(CONST.BGM_VOLUME_KEY, CONST.BMG_VOLUME_DEFAULT);
            isFadeOut = false;
            if (!string.IsNullOrEmpty(nextBGMName))
            {
                PlayBGM(nextBGMName);
            }



        }



    }
    public void ChangeBGMVolume(float BGMvolume)
    {
        AttachBGMSource.volume = BGMvolume;
        PlayerPrefs.SetFloat(CONST.BGM_VOLUME_KEY, BGMvolume);
    }

    public void ChangeSEVolume(float SEvolume)
    {
        AttachSESource.volume = SEvolume;
        PlayerPrefs.SetFloat(CONST.SE_VOLUME_KEY, SEvolume);
    }
}
