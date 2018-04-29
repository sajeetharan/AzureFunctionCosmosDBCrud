#r "Microsoft.Azure.Documents.Client"

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Formatting;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

public static HttpResponseMessage Run (Customer input, string id, TraceWriter log, dynamic customer) {

    customer.CustomerId = input.CustomerId;
    customer.CompanyName = input.CompanyName;
    customer.ContactName = input.ContactName;
    customer.ContactTitle = input.ContactTitle;
    customer.Address = input.Address;
    customer.City = input.City;
    customer.Region = input.Region;
    customer.PostalCode = input.PostalCode;
    customer.Latitude = input.Latitude;
    customer.Longitude = input.Longitude;
    customer.Country = input.Country;
    customer.Phone = input.Phone;
    customer.Fax = input.Fax;

    log.Info ($"Updated customer with id: {id}");

    HttpResponseMessage response = new HttpResponseMessage ();

    response.StatusCode = HttpStatusCode.OK;

    return response;
}

public class Customer {
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