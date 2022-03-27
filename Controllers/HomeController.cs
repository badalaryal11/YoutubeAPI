using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Youtube_API.Models;

namespace Youtube_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = "AIzaSyBMDHOc8wMNxiPQLaZEBV31mT2a6fcyLKc";
            //create the request to the API
            WebRequest request = WebRequest.Create("  https://youtube.googleapis.com/youtube/v3/search?part=snippet&q=Pokemon&key= " + apiKey );
            //Send that request off
            WebResponse response = request.GetResponse();
            //Getb back the response stream
            Stream stream = response.GetResponseStream();
            // make it accessible
            StreamReader reader = new StreamReader(stream);
            //Put into string which is JSON formatted
            string responseFromServer = reader.ReadToEnd();
            JObject parsedString = JObject.Parse(responseFromServer);
            YoutubeSearch search = parsedString.ToObject<YoutubeSearch>();

            return View(search);
        }

     
        }
    }
