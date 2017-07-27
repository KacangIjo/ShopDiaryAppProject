﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;

using System.Net.Http.Headers;
using ShopDiaryProjectV1.Helper;
using Newtonsoft.Json;
using ShopDiaryProject.Domain.Models;
using ShopDiaryProject.Android.Models.ViewModels;

namespace ShopDiaryProjectV1.Services
{
    public class CategoryDataService
    {
        //JANGAN LUPA GANTI Category PAKE .DOMAIN
        private HttpClient client = new HttpClient();
        public async Task<List<CategoryViewModel>> GetAll()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var builder = new UriBuilder(new Uri(UrlHelper.Categories_Url + @"/GetCategories"));
                    var response = await client.GetAsync(builder.Uri);
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);

                    var modelResult = JsonConvert.DeserializeObject<List<CategoryViewModel>>(result);
                    return modelResult;
                }
                catch (Exception ex)
                {

                    return null;
                }
            }
        }

        public bool Add(Category data)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Price", data.Name.ToString()),
                new KeyValuePair<string, string>("Qty", data.Description.ToString()),
                new KeyValuePair<string, string>("CategoryId", data.Id.ToString()),

            });

            try
            {

                HttpResponseMessage resp = client.PostAsync(UrlHelper.Categories_Url + @"/PostCategory", content).Result;
                Category t = JsonConvert.DeserializeObject<Category>(resp.Content.ReadAsStringAsync().Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Guid id, Category data)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Price", data.Name.ToString()),
                new KeyValuePair<string, string>("Qty", data.Description.ToString()),
                new KeyValuePair<string, string>("CategoryId", data.Id.ToString()),

            });

            try
            {
                HttpResponseMessage resp = client.PutAsync(UrlHelper.Categories_Url + @"/PutCategory/" + id, content).Result;
                Category t = JsonConvert.DeserializeObject<Category>(resp.Content.ReadAsStringAsync().Result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {

                HttpResponseMessage resp = client.DeleteAsync(UrlHelper.Categories_Url + @"/DeleteCategory/" + id).Result;
                Category t = JsonConvert.DeserializeObject<Category>(resp.Content.ReadAsStringAsync().Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
    