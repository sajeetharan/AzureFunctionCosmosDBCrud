#r "Microsoft.Azure.Documents.Client"

using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System.Net;
using System.Net.Http.Formatting;

public static HttpResponseMessage Run(HttpResponseMessage req, string customerid, TraceWriter log, dynamic customer)
{

    var castedCustomer = (Customer)customer;
    log.Info($"Read customer with id: {customerid}");

    HttpResponseMessage response = new HttpResponseMessage();

    response.Content = new ObjectContent<Customer>(castedCustomer, new JsonMediaTypeFormatter(), "application/json");
    response.StatusCode = HttpStatusCode.OK;

    return response;
}

public class Customer
{
    public string CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string id { get; set; }
}