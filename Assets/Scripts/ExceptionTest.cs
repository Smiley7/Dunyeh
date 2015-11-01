using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ExceptionTest : MonoBehaviour {
    //////////////////////////////////////////////////////
    /////            TRY and CATCH SCRIPT           /////
    ////////////////////////////////////////////////////
        // Use this for initialization
	void Start () {
        FileStream file = null;
        FileInfo fileInfo = null;

        try
        {
            fileInfo = new FileInfo("C:\\file.txt"); // Creates a file at said location
            file = fileInfo.OpenWrite();

            for(int i = 0; i < 255; i++)
                file.WriteByte((byte)i);

            throw new ArgumentNullException("Something Happened"); // Creating own exception
        }

        catch(UnauthorizedAccessException e)
        {
            Debug.LogWarning(e.Message); // Warning message stating what happened
        }

        catch(ArgumentNullException e)
        {
            Debug.LogWarning("FAIL!!!");
        }

        finally
        {
            if (file != null)
                file.Close();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
