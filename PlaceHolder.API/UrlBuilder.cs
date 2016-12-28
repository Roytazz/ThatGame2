﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.Network;

namespace GuildWars2APIPlaceHolder
{
    internal class UrlBuilder
    {
        private static string BASE_URL_V1 = "https://api.guildwars2.com/v1";
        private static string BASE_URL_V2 = "https://api.guildwars2.com/v2";

        private API _selectedApi = API.Guildwars2V2;
        private List<string> _params = new List<string>();
        private List<string> _directives = new List<string>();

        private string BaseURL { 
            get {
                switch (_selectedApi) {
                    case API.Guildwars2V1:
                    return BASE_URL_V1;
                    case API.Guildwars2V2:
                    return BASE_URL_V2;

                    default:
                    return BASE_URL_V2;
                }
            }
        }

        public string URL {
            get {
                var url = new StringBuilder(BaseURL);
                if (_directives.Count > 0) {
                    url.Append('/');
                    url.Append(string.Join("/", _directives));
                }
                if (_params.Count > 0) {
                    url.Append('?');
                    url.Append(string.Join("&", _params));
                }
                return url.ToString();
            }
        }

        public UrlBuilder(params string[] endPoints)
        {
            if(endPoints.Count() > 0)
                _directives.AddRange(endPoints);
        }

        public T Request<T>(API api = API.Guildwars2V2)
        {
            _selectedApi = api;
            return new WebRequestHandler().GetRequest<T>(URL);
        }

        public T Request<T>(string apiKey, API api = API.Guildwars2V2)
        {
            _selectedApi = api;
            return new WebRequestHandler().GetRequest<T>(URL, new Dictionary<string, string>() { { "Authorization", string.Format("Bearer {0}", apiKey) } });
        }

        public UrlBuilder AddDirective(string directive)
        {
            _directives.Add(directive);
            return this;
        }

        public UrlBuilder AddParam(string parameter)
        {
            _params.Add(parameter);
            return this;
        }

        public UrlBuilder AddParam(string name, string value)
        {
            _params.Add($"{name}={value}");
            return this;
        }

        public UrlBuilder AddParam<T>(string name, IEnumerable<T> values)
        {
            _params.Add($"{name}={string.Join(",", values)}");  //Large requests might be a problem
            return this;
        }
    }

    public enum API
    {
        Guildwars2V1,
        Guildwars2V2
    }
}
