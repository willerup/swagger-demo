using System;
using System.IO;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPublicApi
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get list of customers.
        /// </remarks>
        /// <param name="offset">number of items to skip</param>
        /// <param name="limit">max items to return</param>
        /// <returns></returns>
        List<CustomerSummary> ListCustomers (int? offset, int? limit);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get list of customers.
        /// </remarks>
        /// <param name="offset">number of items to skip</param>
        /// <param name="limit">max items to return</param>
        /// <returns></returns>
        System.Threading.Tasks.Task<List<CustomerSummary>> ListCustomersAsync (int? offset, int? limit);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create a customer
        /// </remarks>
        /// <param name="customer"></param>
        /// <returns>CustomerDetail</returns>
        CustomerDetail CreateCustomer (CustomerCreate customer);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create a customer
        /// </remarks>
        /// <param name="customer"></param>
        /// <returns>CustomerDetail</returns>
        System.Threading.Tasks.Task<CustomerDetail> CreateCustomerAsync (CustomerCreate customer);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a customer by id
        /// </remarks>
        /// <param name="customerId"></param>
        /// <returns>CustomerDetail</returns>
        CustomerDetail GetCustomer (string customerId);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a customer by id
        /// </remarks>
        /// <param name="customerId"></param>
        /// <returns>CustomerDetail</returns>
        System.Threading.Tasks.Task<CustomerDetail> GetCustomerAsync (string customerId);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete customer by id
        /// </remarks>
        /// <param name="customerId"></param>
        /// <returns></returns>
        void CustomersCustomerIdDelete (string customerId);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete customer by id
        /// </remarks>
        /// <param name="customerId"></param>
        /// <returns></returns>
        System.Threading.Tasks.Task CustomersCustomerIdDeleteAsync (string customerId);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PublicApi : IPublicApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PublicApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PublicApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        
        /// <summary>
        ///  Get list of customers.
        /// </summary>
        /// <param name="offset">number of items to skip</param> 
        /// <param name="limit">max items to return</param> 
        /// <returns></returns>            
        public List<CustomerSummary> ListCustomers (int? offset, int? limit)
        {
            
    
            var path_ = "/customers";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (offset != null) queryParams.Add("offset", ApiClient.ParameterToString(offset)); // query parameter
            if (limit != null) queryParams.Add("limit", ApiClient.ParameterToString(limit)); // query parameter
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListCustomers: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ListCustomers: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<CustomerSummary>) ApiClient.Deserialize(response, typeof(List<CustomerSummary>));
        }
    
        /// <summary>
        ///  Get list of customers.
        /// </summary>
        /// <param name="offset">number of items to skip</param>
        /// <param name="limit">max items to return</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<List<CustomerSummary>> ListCustomersAsync (int? offset, int? limit)
        {
            
    
            var path_ = "/customers";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (offset != null) queryParams.Add("offset", ApiClient.ParameterToString(offset)); // query parameter
            if (limit != null) queryParams.Add("limit", ApiClient.ParameterToString(limit)); // query parameter
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ListCustomers: " + response.Content, response.Content);

            return (List<CustomerSummary>) ApiClient.Deserialize(response, typeof(List<CustomerSummary>));
        }
        
        /// <summary>
        ///  Create a customer
        /// </summary>
        /// <param name="customer"></param> 
        /// <returns>CustomerDetail</returns>            
        public CustomerDetail CreateCustomer (CustomerCreate customer)
        {
            
    
            var path_ = "/customers";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            
            
            postBody = ApiClient.Serialize(customer); // http body (model) parameter
            
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path_, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateCustomer: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateCustomer: " + response.ErrorMessage, response.ErrorMessage);
    
            return (CustomerDetail) ApiClient.Deserialize(response, typeof(CustomerDetail));
        }
    
        /// <summary>
        ///  Create a customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>CustomerDetail</returns>
        public async System.Threading.Tasks.Task<CustomerDetail> CreateCustomerAsync (CustomerCreate customer)
        {
            
    
            var path_ = "/customers";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            
            
            postBody = ApiClient.Serialize(customer); // http body (model) parameter
            
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path_, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CreateCustomer: " + response.Content, response.Content);

            return (CustomerDetail) ApiClient.Deserialize(response, typeof(CustomerDetail));
        }
        
        /// <summary>
        ///  Get a customer by id
        /// </summary>
        /// <param name="customerId"></param> 
        /// <returns>CustomerDetail</returns>            
        public CustomerDetail GetCustomer (string customerId)
        {
            
            // verify the required parameter 'customerId' is set
            if (customerId == null) throw new ApiException(400, "Missing required parameter 'customerId' when calling GetCustomer");
            
    
            var path_ = "/customers/{customerId}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (customerId != null) pathParams.Add("customerId", ApiClient.ParameterToString(customerId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetCustomer: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetCustomer: " + response.ErrorMessage, response.ErrorMessage);
    
            return (CustomerDetail) ApiClient.Deserialize(response, typeof(CustomerDetail));
        }
    
        /// <summary>
        ///  Get a customer by id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>CustomerDetail</returns>
        public async System.Threading.Tasks.Task<CustomerDetail> GetCustomerAsync (string customerId)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null) throw new ApiException(400, "Missing required parameter 'customerId' when calling GetCustomer");
            
    
            var path_ = "/customers/{customerId}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (customerId != null) pathParams.Add("customerId", ApiClient.ParameterToString(customerId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetCustomer: " + response.Content, response.Content);

            return (CustomerDetail) ApiClient.Deserialize(response, typeof(CustomerDetail));
        }
        
        /// <summary>
        ///  Delete customer by id
        /// </summary>
        /// <param name="customerId"></param> 
        /// <returns></returns>            
        public void CustomersCustomerIdDelete (string customerId)
        {
            
            // verify the required parameter 'customerId' is set
            if (customerId == null) throw new ApiException(400, "Missing required parameter 'customerId' when calling CustomersCustomerIdDelete");
            
    
            var path_ = "/customers/{customerId}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (customerId != null) pathParams.Add("customerId", ApiClient.ParameterToString(customerId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path_, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CustomersCustomerIdDelete: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling CustomersCustomerIdDelete: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  Delete customer by id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task CustomersCustomerIdDeleteAsync (string customerId)
        {
            // verify the required parameter 'customerId' is set
            if (customerId == null) throw new ApiException(400, "Missing required parameter 'customerId' when calling CustomersCustomerIdDelete");
            
    
            var path_ = "/customers/{customerId}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (customerId != null) pathParams.Add("customerId", ApiClient.ParameterToString(customerId)); // path parameter
            
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path_, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling CustomersCustomerIdDelete: " + response.Content, response.Content);

            
            return;
        }
        
    }
    
}
