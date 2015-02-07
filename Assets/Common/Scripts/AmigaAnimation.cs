using UnityEngine;
using System.Collections;

public class AmigaAnimation : MonoBehaviour
{
	public Sprite[] sprites;
	public float[] times;

	public Transform amiga_text;
	public Transform amiga_cursor;
	public Transform fade_texture;
	public Transform cocainum_text;
	public AudioClip cocainum_audio;
	public AudioClip intro_audio;
	public float FadeTime;

	bool start_cocainum = false;
	bool fadeout = false;
	float fadeTimer = 0;
	float cocainTimer = 0;

	SpriteRenderer spriteRenderer;
	public float offsetValue = 0.01f;
	public void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		Blank();
		spriteRenderer.color = new Color(0.2627450980392157f, 0.2627450980392157f, 0.2627450980392157f);
		audio.Play();
		amiga_text.active = false;
		amiga_cursor.active = false;
		Camera.main.backgroundColor = new Color(0, 0.3411764705882353f, 0.6862745098039216f);
	}
	public void Update()
	{
		if (start_cocainum)
		{
			Cocainum();
			if (audio.time >= 1)
			{
				Camera.main.transform.position = new Vector3(0, 0, -10);
				Camera.main.transform.localEulerAngles = Vector3.zero;
				audio.Stop();
				Application.LoadLevelAsync(1);
			}
			return;
		}

		if (fadeout)
		{
			SpriteRenderer sr = fade_texture.GetComponent<SpriteRenderer>();
			Color col = sr.color;
			if (Time.timeSinceLevelLoad - fadeTimer < FadeTime)
			{
				col.a = 0.95f;
			}
			else if (Time.timeSinceLevelLoad - fadeTimer < FadeTime * 2)
			{
				col.a = 0.73f;
			}
			else if (Time.timeSinceLevelLoad - fadeTimer < FadeTime * 3f)
			{
				col.a = 0.36f;
			}
			else if (Time.timeSinceLevelLoad - fadeTimer < FadeTime * 6f)
			{
				col.a = 0.1f;
			}
			else
			{
				col.a = 0;
				start_cocainum = true;
				audio.Stop();
				audio.clip = cocainum_audio;
				audio.Play();
				cocainum_text.active = true;
			}
			sr.color = col;
			return;
		}

		if (audio.time > times[0] - offsetValue && audio.time < times[0] + offsetValue)
			spriteRenderer.color = new Color(0.5333333333333333f, 0.5333333333333333f, 0.5333333333333333f);
		else if (audio.time > times[1] - offsetValue && audio.time < times[1] + offsetValue)
			spriteRenderer.color = Color.white;
		else if (audio.time > times[2] - offsetValue && audio.time < times[2] + offsetValue)
			Hand();
		else if (audio.time > times[3] - offsetValue && audio.time < times[3] + offsetValue)
			Blank();
		else if (audio.time > times[4] - offsetValue && audio.time < times[4] + offsetValue)
		{
			amiga_text.active = true;
			amiga_cursor.active = true;
			Workspace();
			Text1();
		}
		else if (audio.time > times[5] - offsetValue && audio.time < times[5] + offsetValue)
		{
			Text2();
		}
		else if (audio.time > times[6] - offsetValue && audio.time < times[6] + offsetValue)
		{
			Text3();
		}
		else if (audio.time > times[7] - offsetValue && audio.time < times[7] + offsetValue)
		{
			Camera.main.backgroundColor = new Color(0, 0, 0);

			amiga_text.active = false;
			amiga_cursor.active = false;
			fadeout = true;
			fadeTimer = Time.timeSinceLevelLoad;
			SpriteRenderer sr = fade_texture.GetComponent<SpriteRenderer>();
			Color col = sr.color;
			col.a = 1;
			sr.color = col;
			CocainumSprite();
		}
		Debug.Log(audio.time);
	}

	public void PlayMusic()
	{
		audio.Play();
	}

	public void StopMusic()
	{
		audio.Stop();
	}

	public void Blank()
	{
		spriteRenderer.sprite = sprites[0];
	}

	public void Hand()
	{
		spriteRenderer.sprite = sprites[1];
	}

	public void Workspace()
	{
		spriteRenderer.sprite = sprites[2];
	}

	public void CocainumSprite()
	{
		spriteRenderer.sprite = sprites[3];
	}

	public void Text1()
	{
		TextMesh text = amiga_text.GetComponent<TextMesh>();
		text.text =
@"Copyright @2015 Junion, Inc.
All rights reserved.
Release 2.5";

		Vector3 pos = amiga_cursor.position;
		pos.y = 9.76f;
		amiga_cursor.position = pos;
	}

	public void Text2()
	{ 
		TextMesh text = amiga_text.GetComponent<TextMesh>();
		text.text =
@"Copyright @2015 Junion, Inc.
All rights reserved.
Release 2.5
Nordic Game Jam Disk. Release 2.5.12 version 20.15";

		Vector3 pos = amiga_cursor.position;
		pos.y = 9.76f - 0.7f;
		amiga_cursor.position = pos;
	}

	public void Text3()
	{ 
		TextMesh text = amiga_text.GetComponent<TextMesh>();
		text.text = 
@"Copyright @2015 Junion, Inc.
All rights reserved.
Release 2.5
Nordic Game Jam Disk. Release 2.5.12 version 20.15
AutoExec ""Cocainum""";

		Vector3 pos = amiga_cursor.position;
		pos.y = 9.76f - 1.3f;
		amiga_cursor.position = pos;
	}

	public void Cocainum()
	{
		Camera.main.transform.position = new Vector3(Random.RandomRange(-1.0f, 1) * audio.time, Random.RandomRange(-1.0f, 1)*audio.time, -10);
		Camera.main.transform.localEulerAngles = new Vector3(0, 0, Random.RandomRange(-1.0f, 1) * audio.time);
		if (cocainTimer < Time.timeSinceLevelLoad)
		{
			cocainTimer = Time.timeSinceLevelLoad + 0.05f;
			cocainum_text.active = !cocainum_text.active;
		}
	}
}
