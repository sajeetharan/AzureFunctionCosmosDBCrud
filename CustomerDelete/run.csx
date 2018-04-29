#r "Microsoft.Azure.Documents.Client"

using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Net;
using System.Net.Http.Formatting;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, string customerid, TraceWriter log, DocumentClient client)
{
    HttpResponseMessage response = new HttpResponseMessage();
    try {
        await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri("BankDatabase","Customers", customerid));
        response.StatusCode = HttpStatusCode.OK;
        log.Info($"Deleted customer with id: {customerid}");
    }
    catch (DocumentClientException exc)
    {
        if (exc.StatusCode == HttpStatusCode.NotFound)
        {
            response = req.CreateResponse(HttpStatusCode.NotFound, "There is no item with given ID in our database!");
        }
        else
        {
            response = req.CreateResponse(HttpStatusCode.InternalServerError, "Internal server error. Contact administrator.");
        }
    }

    return response;
}