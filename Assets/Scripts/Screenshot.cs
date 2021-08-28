using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
	public void TakeShot()
	{
		StartCoroutine("CaptureIt");
	}

	IEnumerator CaptureIt()
	{

		//string folderPath = System.IO.Directory.GetCurrentDirectory() + "/Screenshots/";
		/*string folderPath = Application.persistentDataPath + "/";
		Debug.LogWarning(folderPath);

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);*/

		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot_" + timeStamp + ".png";
		string pathToSave = fileName;

		ScreenCapture.CaptureScreenshot(pathToSave);
		Debug.Log("SS Taken");
		Debug.Log(fileName);
		yield return new WaitForEndOfFrame();
	}
}
