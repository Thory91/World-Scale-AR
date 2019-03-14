using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using MiniJSON;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class InstagramGetter : MonoBehaviour
{
    private List<GameObject> pictures = new List<GameObject>();

    public AbstractMap _map;
    public string access_token;

    public GameObject instagramPrefab;

    



    private void Start()
    {

        StartCoroutine(GetInstaPictures());


    }

    private IEnumerator GetInstaPictures()
    {

        string url = "https://api.instagram.com/v1/users/self/media/recent/?access_token="+access_token;    

        WWW www = new WWW(url);
        yield return www;
        string api_response = www.text;
        Debug.Log(api_response);

        //Canter location. This is the center point for calculating location radius
        var centerLocation = _map.GeoToWorldPosition(_map.CenterLatitudeLongitude);

        //radius in meters. Change here if you want to increase or decrease from how far you want to show instagram pictures
        int radius = 1; //this means around 500 meter


        IDictionary apiParse = (IDictionary)Json.Deserialize(api_response);
        IList instagramPicturesList = (IList)apiParse["data"];

        foreach (IDictionary instagramPicture in instagramPicturesList)
        {
            //main picture info
            IDictionary images = (IDictionary)instagramPicture["images"];
            IDictionary standardResolution = (IDictionary)images["standard_resolution"];
            string mainPic_url = (string)standardResolution["url"];
            Debug.Log(mainPic_url);

            WWW mainPic = new WWW(mainPic_url);
            yield return mainPic;
          
            //location info
            IDictionary location = (IDictionary)instagramPicture["location"];

            //some pictures does not have location data so we only show the pictures with location data
            if (location != null)
            {
                double lat = (double)location["latitude"];
                double lon = (double)location["longitude"];
                string placeName = (string)location["name"];

                //getting the unity  position of every instagram picture to be able to check if it is inside or outside the radius
                var instagramPicturePosition = _map.GeoToWorldPosition(new Mapbox.Utils.Vector2d(lat, lon));


                if (Mathf.Abs(Vector3.Distance(centerLocation,instagramPicturePosition))<radius)
                {
                    GameObject instaPost = Instantiate(instagramPrefab) as GameObject;
                    instaPost.transform.SetParent(_map.transform);
                    instaPost.transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture = mainPic.texture;
                    instaPost.transform.GetChild(3).GetComponent<TextMeshPro>().text = placeName;

                    instaPost.transform.position = _map.GeoToWorldPosition(new Mapbox.Utils.Vector2d(lat, lon))+ new Vector3(0, 130f, 0);
                    //instaPost.transform.position = Conversions.GeoToWorldPosition(new Mapbox.Utils.Vector2d(lat, lon), _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz() + new Vector3(0, 24, 0);

                    //username,profile picture
                    IDictionary user = (IDictionary)instagramPicture["user"];
                    string userName = (string)user["username"];
                    string profilePic_url = (string)user["profile_picture"];

                    instaPost.transform.GetChild(2).GetComponent<TextMeshPro>().text = userName;
                    instaPost.transform.GetChild(6).GetComponent<TextMeshPro>().text = userName;

                    //likes
                    IDictionary Likes = (IDictionary)instagramPicture["likes"];
                    string likes = (string)Likes["count"].ToString();
                    instaPost.transform.GetChild(4).GetComponent<TextMeshPro>().text = likes + " likes";


                    WWW profilePic = new WWW(profilePic_url);
                    yield return profilePic;
                    instaPost.transform.GetChild(1).GetComponent<MeshRenderer>().material.mainTexture = profilePic.texture;                  
                                                  
                }          
            }
        }

    }

   
}
