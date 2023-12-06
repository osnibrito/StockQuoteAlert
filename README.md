# StockQuoteAlert

## Overview
The Stock Quote Alert is a C# Command Line Interface (CLI) that continuously monitors the stock price based on a provided stock and predefined selling and buying reference prices. The program is designed to send email notifications, whenever the stock price surpasses or falls below the specified reference values.
The stock prices are provided with the brapi API

## Execution
The project was made in JetBrains Rider 2023, the settings were also tested in Visual Studio 2023. It is recommended to run the program in any of the IDE's.
To run the project needs 3 arguments (stock, priceSell, priceBuy):
- **Stock**: symbol of the stock to be watcher.
- **priceSell**: reference of the price to sell.
- **priceBuy**: reference of the buy to sell.

Example:

```
>PETR4 36.67 35.59 
```
> This example is in the IDE settings for input arguments.

## Configuration
This aplication requires a configuration file in JSON, `appsetings.json`.
The file on this repository is just a example, because has some arguments private like a API token.

```json
{
  "Host": "{SMTP_HOST}",
  "Port": "{SMTP_PORT}",
  "Username": "{SMTP_USERNAME}",
  "Password": "{SMTP_PASSWORD}",
  "Sender": {
    "Address": "sender@company.com",
    "Username": "sender"
  },

  "Users": [
    {
      "Address": "receiver1@example.com",
      "Username": "receiver1"
    },
    {
      "Address": "receiver2@example.com",
      "Username": "receiver2"
    },
    {"..."},
    {
      "Address": "receiverN@example.com",
      "Username": "receiverN"
    },
  ],
  "ApiToken":"{YOUR_API_TOKEN}",
  "ApiTimer": "{TIME_API_REFRESH}"
}
```
Explanation of the parameters:

`Host:` Name or IP address of the host computer used for SMTP transactions.

`Port:` Port of the host.

`Username:` The user name associated with the credentials.

`Password:` The password for the user name associated with the credentials.

`Sender:` Refers to the email address and username of the sender. 

`Users:` List of email address and username of receivers.

`ApiToken:` API token of _BRAPI_.

`ApiTimer:` Interval of time to verify the prices.





