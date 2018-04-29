# Cosmos databse CRUD Azure Function app

## Description

Azure Function App consuming DocumentDB (CosmosDB) with HTTP triggers to enable CRUD operations with Azure Functions Proxy in the same app.

## Overview

Aim of this app was to create connection between HTTP triggers that will easily controll data in database. Each trigger has appropriate method which are as follows:

* CREATE - HTTP PUT
* READ - HTTP GET
* UPDATE - HTTP POST
* DELETE - HTTP DELETE

After that we can call them directly (look for definition in file **function.json** in each folder) or via proxy (look for **proxies.json** files). The second approach, the proxy, can be located in another app in another resource group so you can use external API and change it for your use.

## Requirements

This repository is made for ease deployment to Azure continous integration via Github. It is important to remember that folders functions have to be located in root directory, the same with host.json file and proxies.json file if applicable.

Moreover, after you create Function App in Azure you must define 3 key-value app settings. In order to do so go to your Function App in Azure, click the app name, then in `Overview` tab click `Application setting`. In section `Application settings` click `Add new setting` and add key-value pairs:

* CosmosDbDatabaseName - database name in CosmosDB
* CosmosDbCollectionName - collection name in CosmosDB
* AnotherAppId - value should refer to your Function App name (applicable if you use Proxy)

Please be noted that these names are custom and you can change them for your convenience. For more info read [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings).

## Testing

This app can be tested locally (both API and proxy). For instructions plese refer [Code and test Azure Functions locally](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local). You will also need `local.settings.json` file in root folder that contains local key-value settings as mentioned in previous chapter. It should look like this:

```json
{
  "IsEncrypted": false,
  "Values": {
      "AzureWebJobsStorage": "",
      "AzureWebJobsDashboard": "",
      "azure-functions-proxy-cosmos-db_DOCUMENTDB": "AccountEndpoint={url_with_port_to_your_azure_cosmos_db};AccountKey={generated_account_key};",
      "CosmosDbDatabaseName":"{cosmosdb_database_name}",
      "CosmosDbCollectionName":"{cosmosdb_collection_name}",
      "AnotherAppId":"{another_app_name_for_proxy}"
    }
}
```

This file should not be made public and should be included in `.gitignore` file.

## Notes

All setting are automatically passed to application via `local.settings.json` file or via settings you created in Azure portal except **CustomerDelete** function when we cast to **DocumentClient** object which is necessary for deleting file. In **CreateDocumentUri** we manually enter database and collection name.

## Software

Recommended software:

* Visual Studio Code for managing project and executing test
* Postman (standalone version) for manual executing request
* Microsoft Azure Storage Explorer for manipulating data in Cosmos DB

## Links

[Azure Functions developers guide](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference) - necessary informations for beginners on Azure Functions

[Azure Functions triggers and bindings concepts](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings) - tutorial on triggers and bindings

[Azure Cosmos DB bindings for Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-documentdb) - good tutorial on how to consume Azure Cosmos DB but lacks info about casting possibilities

[host.json reference for Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-host-json) - host.json file reference

[Work with Azure Functions Proxies](https://docs.microsoft.com/en-us/azure/azure-functions/functions-proxies) - reference for creating and managing proxies
