using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Iys.SDK.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Iys.SDK
{
    public class Iys : IIys
    {
        private readonly string _baseUrl;
        private readonly string _password;
        private readonly string _username;
        private ResponseToken _token;
        private DateTime _tokenExpire;

        public Iys(string baseUrl, string username, string password)
        {
            _baseUrl = baseUrl;
            _username = username;
            _password = password;
        }

        public async Task<List<IntegrationBrand>> GetBrands(int iysCode, CancellationToken cancellationToken = default)
        {
            return (await GetIntegration(iysCode, cancellationToken)).List.First().Brands;
        }

        public async Task<ResponseBrands> GetBrandsCustomer(int iysCode, CancellationToken cancellationToken = default)
        {
            var brandModels = new List<BrandModel>();
            var errorWrapper = new ErrorWrapper
            {
                List = new List<IysError>()
            };

            var response = await RestClientRequest((List<BrandModel>) null, $"/sps/{iysCode}/brands", Method.GET, cancellationToken: cancellationToken);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                brandModels = JsonConvert.DeserializeObject<List<BrandModel>>(response.Content);
            }
            else
            {
                await Console.Out.WriteLineAsync(response.Content);
                errorWrapper = JsonConvert.DeserializeObject<ErrorWrapper>(response.Content);
            }

            return new ResponseBrands
            {
                List = brandModels,
                Errors = errorWrapper
            };
        }

        public async Task<RetailerItem> GetRetailer(int iysCode, int brandCode, int retailerCode, CancellationToken cancellationToken = default)
        {
            var response = await RestClientRequest((RetailerItem) null, $"/sps/{iysCode}/brands/{brandCode}/retailers/{retailerCode}", Method.GET, cancellationToken: cancellationToken);
            var retailerItem = JsonConvert.DeserializeObject<RetailerItem>(response.Content);

            return retailerItem;
        }

        public async Task<RetailerModel> GetRetailers(int iysCode, int brandCode, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((RetailerModel) null, $"/sps/{iysCode}/brands/{brandCode}/retailers", Method.GET, cancellationToken: cancellationToken);
            var retailerModel = JsonConvert.DeserializeObject<RetailerModel>(restResponse.Content);

            return retailerModel;
        }

        public async Task<RetailerAddResult> AddRetailer(int iysCode, int brandCode, RetailerAddItem retailer, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(retailer, $"/sps/{iysCode}/brands/{brandCode}/retailers", Method.POST, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<RetailerAddResult>(restResponse.Content);
        }

        public async Task<RetailerRemoveResult> DeleteRetailer(int iysCode, int brandCode, int retailerCode, CancellationToken cancellationToken = default)
        {
            var response = await RestClientRequest((string) null, $"/sps/{iysCode}/brands/{brandCode}/retailers/{retailerCode}", Method.DELETE, cancellationToken: cancellationToken);
            if (response.StatusCode != HttpStatusCode.OK) return JsonConvert.DeserializeObject<RetailerRemoveResult>(response.Content);
            
            return new RetailerRemoveResult
            {
                Success = response.Content == "Success"
            };
        }

        public async Task<ResponseSingleConsent> SetRetailerAccessToConsent(int iysCode, int brandCode, RequestRetailerAccess retailerAccess, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(retailerAccess, $"/sps/{iysCode}/brands/{brandCode}/consents/retailers/access", Method.POST, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<ResponseSingleConsent>(restResponse.Content);
        }

        public async Task<RetailerConsentModel> GetConsentRetailers(int iysCode, int brandCode, RequestConsentStatus consent, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(consent, $"/sps/{iysCode}/brands/{brandCode}/consent/retailers/access/list", Method.POST, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<RetailerConsentModel>(restResponse.Content);
        }

        public async Task<ResponseRemoveRetailerAccess> RemoveRetailerAccessFromRecipients(int iysCode, int brandCode, RequestRemoveRetailerAccess request, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(request, $"/sps/{iysCode}/brands/{brandCode}/consents/retailers/access/remove", Method.POST, cancellationToken: cancellationToken);
            if (restResponse.StatusCode != HttpStatusCode.Accepted) return JsonConvert.DeserializeObject<ResponseRemoveRetailerAccess>(restResponse.Content);
            
            return new ResponseRemoveRetailerAccess
            {
                Success = true
            };
        }

        public async Task<ResponseRemoveRetailerAccess> RemoveAllRetailerAccessFromRecipients(int iysCode, int brandCode, RequestRemoveAllRetailerAccess request, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(request, $"/sps/{iysCode}/brands/{brandCode}/consents/retailers/access/remove/all", Method.POST, cancellationToken: cancellationToken);
            if (restResponse.StatusCode != HttpStatusCode.Accepted) return JsonConvert.DeserializeObject<ResponseRemoveRetailerAccess>(restResponse.Content);
            
            return new ResponseRemoveRetailerAccess
            {
                Success = true
            };
        }

        public async Task<ResponseSingleConsent> ChangeAllRetailerAccessFromRecipients(int iysCode, int brandCode, RequestRemoveRetailerAccess request, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(request, $"/sps/{iysCode}/brands/{brandCode}/consents/retailers/access", Method.PUT, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<ResponseSingleConsent>(restResponse.Content);
        }

        public async Task<ResponseSingleConsent> AddSingleConsent(int iysCode, int brandCode, RequestConsent model, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(model, $"/sps/{iysCode}/brands/{brandCode}/consents", Method.POST, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<ResponseSingleConsent>(restResponse.Content);
        }

        public async Task<ResponseConsentStatus> GetConsentStatus(int iysCode, int brandCode, RequestConsentStatus consent, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(consent, $"/sps/{iysCode}/brands/{brandCode}/consents/status", Method.POST, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<ResponseConsentStatus>(restResponse.Content);
        }

        public async Task<ResponseBulkImport> ImportMultipleConsent(int iysCode, int brandCode, List<RequestConsent> consentList, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest(consentList, $"/sps/{iysCode}/brands/{brandCode}/consents/request", Method.POST, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<ResponseBulkImport>(restResponse.Content);
        }

        public async Task<List<ResponseBulkImportResult>> GetMultipleImportStatus(int? iysCode, int? brandCode, Guid requestId, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((List<ResponseBulkImportResult>) null, $"/sps/{iysCode}/brands/{brandCode}/consents/request/{requestId}", Method.GET, cancellationToken: cancellationToken);
            if (restResponse.StatusCode != HttpStatusCode.OK) return null;

            return JsonConvert.DeserializeObject<List<ResponseBulkImportResult>>(restResponse.Content);
        }

        public async Task<ResponseConsentChanges> GetConsentChanges(int iysCode, int brandCode, string source = "", string after = "", int limit = 0, CancellationToken cancellationToken = default)
        {
            var query = string.Empty;
            if (!string.IsNullOrEmpty(source)) query = query + "source=" + source + "&";
            if (!string.IsNullOrEmpty(after)) query = query + "after=" + after + "&";
            if (limit > 0) query += $"limit={limit}";
            var restResponse = await RestClientRequest((ResponseConsentChanges) null, $"/sps/{iysCode}/brands/{brandCode}/consents/changes?{query}", Method.GET, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<ResponseConsentChanges>(restResponse.Content);
        }

        public async Task<Integration> GetIntegrations(CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((Integration) null, "/integrator/6891/sps", Method.GET, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<Integration>(restResponse.Content);
        }

        public async Task<Integration> GetIntegration(int iysCode, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((Integration) null, $"/integrator/6891/sps/{iysCode}", Method.GET, cancellationToken: cancellationToken);
            
            return JsonConvert.DeserializeObject<Integration>(restResponse.Content);
        }

        public async Task<string> GetIntegrationString(int iysCode, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((string) null, $"/integrator/6891/sps/{iysCode}", Method.GET, cancellationToken: cancellationToken);
            var content = restResponse.Content;

            return content;
        }

        public async Task<List<RetailerAddr>> GetInfoCities(CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((List<RetailerAddr>) null, "/info/cities", Method.GET, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<List<RetailerAddr>>(restResponse.Content);
        }

        public async Task<RetailerAddr> GetInfoCity(int code, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((RetailerAddr) null, $"/info/cities/{code}", Method.GET, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<RetailerAddr>(restResponse.Content);
        }

        public async Task<List<RetailerAddrTown>> GetInfoTowns(CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((List<RetailerAddrTown>) null, "/info/town", Method.GET, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<List<RetailerAddrTown>>(restResponse.Content);
        }

        public async Task<RetailerAddrTown> GetInfoTown(int code, CancellationToken cancellationToken = default)
        {
            var restResponse = await RestClientRequest((RetailerAddrTown) null, $"/info/town/{code}", Method.GET, cancellationToken: cancellationToken);

            return JsonConvert.DeserializeObject<RetailerAddrTown>(restResponse.Content);
        }
        
        private async Task<ResponseToken> GetToken(CancellationToken cancellationToken = default)
        {
            while (true)
            {
                var restResponse = await RestClientRequest(new IysCredentials
                    {
                        Username = _username,
                        Password = _password
                    }, "/oauth2/token", Method.POST, false, cancellationToken);
                
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    _token = new ResponseToken
                    {
                        Result = JsonConvert.DeserializeObject<ResponseTokenItem>(restResponse.Content)
                    };
                    _tokenExpire = DateTime.UtcNow.AddSeconds(Convert.ToInt32(_token.Result.ExpiresIn) - 60);

                    return _token;
                }

                Console.WriteLine("ERROR: GetToken : " + restResponse.StatusCode);
                await Task.Delay(1000, cancellationToken);
            }
        }

        private async Task<IRestResponse> RestClientRequest<T>(T parameters, string methodUrl, Method methodType, bool authorization = true, CancellationToken cancellationToken = default)
        {
            if (authorization && (_token == null || _tokenExpire <= DateTime.UtcNow))
            {
                _token = await GetToken();
            }

            var restClient = new RestClient(_baseUrl + methodUrl);
            var restRequest = new RestRequest(methodType);

            restRequest.AddHeader("Cache-Control", "no-cache");
            restRequest.AddHeader("Content-Type", "application/json");

            if (authorization)
            {
                restRequest.AddHeader("Authorization", "Bearer " + _token.Result.AccessToken);
            }

            if (parameters != null)
            {
                restRequest.AddParameter("params", JsonConvert.SerializeObject(parameters, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }), (ParameterType)4);
            }

            return await restClient.ExecuteAsync(restRequest, cancellationToken);
        }
    }
}