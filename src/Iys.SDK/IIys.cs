using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Iys.SDK.Models;

namespace Iys.SDK
{
    public interface IIys
    {
        Task<List<IntegrationBrand>> GetBrands(int iysCode, CancellationToken cancellationToken = default);

        Task<ResponseBrands> GetBrandsCustomer(int iysCode, CancellationToken cancellationToken = default);

        Task<RetailerModel> GetRetailers(int iysCode, int brandCode, CancellationToken cancellationToken = default);

        Task<RetailerAddResult> AddRetailer(int iysCode, int brandCode, RetailerAddItem retailer, CancellationToken cancellationToken = default);

        Task<RetailerItem> GetRetailer(int iysCode, int brandCode, int retailerCode, CancellationToken cancellationToken = default);

        Task<RetailerRemoveResult> DeleteRetailer(int iysCode, int brandCode, int retailerCode, CancellationToken cancellationToken = default);

        Task<ResponseSingleConsent> SetRetailerAccessToConsent(int iysCode, int brandCode, RequestRetailerAccess retailerAccess, CancellationToken cancellationToken = default);

        Task<RetailerConsentModel> GetConsentRetailers(int iysCode, int brandCode, RequestConsentStatus consent, CancellationToken cancellationToken = default);

        Task<ResponseRemoveRetailerAccess> RemoveRetailerAccessFromRecipients(int iysCode, int brandCode, RequestRemoveRetailerAccess request, CancellationToken cancellationToken = default);

        Task<ResponseRemoveRetailerAccess> RemoveAllRetailerAccessFromRecipients(int iysCode, int brandCode, RequestRemoveAllRetailerAccess request, CancellationToken cancellationToken = default);

        Task<ResponseSingleConsent> ChangeAllRetailerAccessFromRecipients(int iysCode, int brandCode, RequestRemoveRetailerAccess request, CancellationToken cancellationToken = default);

        Task<ResponseSingleConsent> AddSingleConsent(int iysCode, int brandCode, RequestConsent model, CancellationToken cancellationToken = default);

        Task<ResponseConsentStatus> GetConsentStatus(int iysCode, int brandCode, RequestConsentStatus consent, CancellationToken cancellationToken = default);

        Task<ResponseConsentChanges> GetConsentChanges(int iysCode, int brandCode, string source = "", string after = "", int limit = 0, CancellationToken cancellationToken = default);

        Task<ResponseBulkImport> ImportMultipleConsent(int iysCode, int brandCode, List<RequestConsent> consentList, CancellationToken cancellationToken = default);

        Task<List<ResponseBulkImportResult>> GetMultipleImportStatus(int? iysCode, int? brandCode, Guid requestId, CancellationToken cancellationToken = default);

        Task<List<RetailerAddr>> GetInfoCities(CancellationToken cancellationToken = default);

        Task<RetailerAddr> GetInfoCity(int code, CancellationToken cancellationToken = default);

        Task<List<RetailerAddrTown>> GetInfoTowns(CancellationToken cancellationToken = default);

        Task<RetailerAddrTown> GetInfoTown(int code, CancellationToken cancellationToken = default);

        Task<Integration> GetIntegrations(CancellationToken cancellationToken = default);

        Task<Integration> GetIntegration(int iysCode, CancellationToken cancellationToken = default);

        Task<string> GetIntegrationString(int iysCode, CancellationToken cancellationToken = default);
    }
}