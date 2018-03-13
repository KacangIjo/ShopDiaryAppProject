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
    public class StorageDataService
    {
        //JANGAN LUPA GANTI Storage PAKE .DOMAIN
        private HttpClient client = new HttpClient();
        public async Task<List<StorageViewModel>> GetAll()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(30) })
            {
                try
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var builder = new UriBuilder(new Uri(UrlHelper.Storages_Url + @"/GetStorages"));
                    var response = await client.GetAsync(builder.Uri);
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    var byteResult = await response.Content.ReadAsByteArrayAsync();
                    var result = Encoding.UTF8.GetString(byteResult, 0, byteResult.Length);

                    var modelResult = JsonConvert.DeserializeObject<List<StorageViewModel>>(result);
                    return modelResult;
                }
                catch (Exception ex)
                {

                    return null;
                }
            }
        }

        public bool Add(Storage data)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", data.Name.ToString()),
                new KeyValuePair<string, string>("Area", data.Area.ToString()),
                new KeyValuePair<string, string>("Description", data.Description.ToString()),
                new KeyValuePair<string, string>("LocationId", data.LocationId.ToString()),

            });

            try
            {

                HttpResponseMessage resp = client.PostAsync(UrlHelper.Storages_Url + @"/PostStorage", content).Result;
                Storage t = JsonConvert.DeserializeObject<Storage>(resp.Content.ReadAsStringAsync().Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Guid id, Storage data)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", data.Name.ToString()),
                new KeyValuePair<string, string>("SeatSize", data.Area.ToString()),
                new KeyValuePair<string, string>("IsEmpty", data.Description.ToString()),
                


            });

            try
            {
                HttpResponseMessage resp = client.PutAsync(UrlHelper.Storages_Url + @"/PutStorage/" + id, content).Result;
                Storage t = JsonConvert.DeserializeObject<Storage>(resp.Content.ReadAsStringAsync().Result);
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

                HttpResponseMessage resp = client.DeleteAsync(UrlHelper.Storages_Url + @"/DeleteStorage/" + id).Result;
                Storage t = JsonConvert.DeserializeObject<Storage>(resp.Content.ReadAsStringAsync().Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
    