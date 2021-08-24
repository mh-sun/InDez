using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PreviewShot : MonoBehaviour
{
	[SerializeField]
	GameObject canvas;

	[SerializeField]
	GameObject MenuPanel;

	[SerializeField]
	GameObject Next;

	[SerializeField]
	GameObject Prev;


	string[] files = null;
	int whichScreenShotIsShown = 0;

	void Start()
	{
		files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
		if (files.Length > 0)
		{
			GetPictureAndShowIt();
		}
		canvas.SetActive(false);
	}

	public void ChangePreviewPanel()
    {
		files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");
		if (files.Length > 0)
		{
			Next.SetActive(true);
			Prev.SetActive(true);
			GetPictureAndShowIt();
		}
        else
        {
			Next.SetActive(false);
			Prev.SetActive(false);
        }
		if (canvas.activeSelf)
        {
			canvas.SetActive(false);
			MenuPanel.SetActive(true);

		}
		else
        {
			canvas.SetActive(true);
			MenuPanel.SetActive(false);

		}
    }

	void GetPictureAndShowIt()
	{
		string pathToFile = files[whichScreenShotIsShown];
		Texture2D texture = GetScreenshotImage(pathToFile);
		Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
			new Vector2(0.5f, 0.5f));
		canvas.GetComponent<Image>().sprite = sp;
	}

	Texture2D GetScreenshotImage(string filePath)
	{
		Texture2D texture = null;
		byte[] fileBytes;
		if (File.Exists(filePath))
		{
			fileBytes = File.ReadAllBytes(filePath);
			texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
			texture.LoadImage(fileBytes);
		}
		return texture;
	}

	public void NextPicture()
	{
		Debug.Log(Application.persistentDataPath);
		if (files.Length > 0)
		{
			whichScreenShotIsShown += 1;
			if (whichScreenShotIsShown > files.Length - 1)
				whichScreenShotIsShown = 0;
			GetPictureAndShowIt();
		}
	}

	public void PreviousPicture()
	{
		Debug.Log("pre");
		if (files.Length > 0)
		{
			whichScreenShotIsShown -= 1;
			if (whichScreenShotIsShown < 0)
				whichScreenShotIsShown = files.Length - 1;
			GetPictureAndShowIt();
		}
	}
}