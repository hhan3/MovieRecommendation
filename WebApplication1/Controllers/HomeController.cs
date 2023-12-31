﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;







namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Shorts()
        {
            return View();
        }
        public ActionResult Genre()
        {
            return View();
        }
        public ActionResult Actors()
        {
            return View();
        }
        public ActionResult Directors()
        {
            return View();
        }
      
        public ActionResult Review()
        {
            return View();
        }

      /*

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
        
        */

        public async Task<ActionResult> Coupons()

        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://get-promo-codes.p.rapidapi.com/data/get-coupons/?page=1&sort=update_time_desc"),
                Headers =
        {
            { "X-RapidAPI-Key", "f45a75ea1cmsh0dd1751d526138fp1f1ac1jsn1b2f727d5f7a" },
            { "X-RapidAPI-Host", "get-promo-codes.p.rapidapi.com" },
        },
            };

            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    ViewBag.CouponData = body; // Assuming the response is in a format that your view can handle
                    return View("Coupons"); 
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Failed to load coupons. Please try again later.";
                return View("Error"); // An error view that shows the message

              
            }
        }




            public async Task<ActionResult> Rating(string id)
            {


            var movieId = string.IsNullOrEmpty(id) ? "defaultMovieId" : id;

            var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://movies-ratings2.p.rapidapi.com/ratings?id={movieId}"),
                    Headers =
                {
                    { "X-RapidAPI-Key", "f45a75ea1cmsh0dd1751d526138fp1f1ac1jsn1b2f727d5f7a" },
                    { "X-RapidAPI-Host", "movies-ratings2.p.rapidapi.com" },

                    
                },
                };

                try
                {
                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = await response.Content.ReadAsStringAsync();
                        ViewBag.RatingData = body;
                        return View("Rating"); 
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (log the error, return an error view, etc.)
                    ViewBag.ErrorMessage = "Failed to load rating data. Please try again later.";
                    return View("Error"); 
                }
            }

           



}
}
