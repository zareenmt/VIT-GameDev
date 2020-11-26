// import two things with these lines:
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
//this dude used some advanced text variable called TMPro (TextMesh Pro) to store text, you could use the normal one also

public class LoadJSON : MonoBehaviour //idk if you need this class hierarchy 
{
    // create the variables to store the JSON data:
    public string var1;
    public string var2;
    public string var3;


    public void getJSON()
    {
        // to use JSON file from link:
        //RequestWebService is a function defined below
        StartCoroutine(RequestWebService());
    }

    IEnumerator RequestWebService()
    {

        //var to store the web link
        string getDataURL = "https://s3-ap-southeast-1.amazonaws.com/cdn.hitwicket.co/sample_user_data.json";

        print(getDataURL); //test this on the console

        using (UnityWebRequest webData = UnityWebRequest.Get(getDataURL))
        {

            // the data is recieved here:
            yield return webData.SendWebRequest();

            //checking for any errors while gettin the json file:
            if (webData.isNetworkError || webData.isHttpError)
            {
                print("error");
                print(webData.error);
            }
            else
            {
                if (webData.isDone)
                {
                    JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(webData.downloadHandler.data));

                    if (jsonData == null)
                    {
                        print("no data was recieved!");
                    }
                    else
                    {
                        // USE THE DATA RECIEVED FROM THE JSON DO DO THE MAGIC CONNECTION
                        // WITH THE UI FRONTEND, IDK HOW THAT WORKS

                        // the first variable
                        var1 = jsonData["current_points"];

                        //second variable
                        // LOOK AT THE EXAMPLE BELOW COMMENT TO SEE THE PROPER CODE TO ACCESS NESTED JSON OBJECT
                        var2 = jsonData["tasks"];

                        /**
                        JSON example for nested objects (like the one given in aws):
                        const data = {
                                        code: 42,
                                        items: [{ id: 1,name: 'foo'}, {id: 2,name: 'bar'}]
                                    };

                        to acces code value (which is 42):
                        data.code

                        to acces items value (which has a bunch of other objs):
                        data.items

                        to access the name of the first object:
                        data.items[0].name
                        
                        to access the id of the second object:
                        data.items[1].id
                        **/
                    }
                }
            }

        }
    }

}