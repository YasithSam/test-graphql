using GraphQL;
using GraphQL.Client.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestGraphQL
{
    public class CompanyConsumer
    {
        private readonly IGraphQLClient _client;
        public CompanyConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task GetCompany()
        {
            //string qu = string.Format("{collectionByCompanyId(companyId: {0}) {collectionId companyId}}",50);
            Product product = new Product();
            product.CID = 50;
            string json = JsonConvert.SerializeObject(product);
            var query = new GraphQLRequest
            {
                Query = @" 
                   query getCollection($CID: Int!){
                    collectionByCompanyId(companyId: $CID) {
                           collectionId
                           companyId
                           domains
                         
                    } 
            } ",
                OperationName = "getCollection",
                Variables =json
            };
            
            var response = await _client.SendQueryAsync<CollectionByCompanyId>(query);
            var x= response.Data;

            
           
            
        }

        public async Task<ResponseCompanyType> CreateComapny(Domains domains)
        {
            
            Product2 product = new Product2();
            product.domains = domains.domains;
            string json = JsonConvert.SerializeObject(product);
            var query = new GraphQLRequest
            {
                Query = @"
                 mutation createCompany($domains: [String]!){
                  createCompany(domains: $domains){
                      company{
                          companyId
                      }
                  }
                }",
                OperationName = "createCompany",
                Variables = json
            };
            var response = await _client.SendMutationAsync<ResponseCompanyType>(query);
            var x = response.Errors;
            return response.Data;
        }

    }
}
