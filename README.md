# MagniseTask API

## Description
This API provides real-time and historical price information for various market assets (e.g., EUR/USD, GOOG) using the Fintacharts platform. The service acts as a REST API and implements best practices for modern web services, returning data in JSON format.

## Features
- **Real-Time Price Data**: Fetch live price updates for supported market assets.
- **Historical Price Data**: Retrieve historical prices for specified assets within a given date range.
- **WebSocket Integration**: Utilize WebSocket for real-time data streaming.
- **Swagger Documentation**: Auto-generated API documentation available for easy exploration.

## Endpoints
### 1. Get List of Supported Market Assets
- **URL**: `/api/assets`
- **Method**: `GET`
- **Response**: JSON array of supported market assets.

### 2. Get Real-Time Price Data
- **URL**: `/api/assets/realtime`
- **Method**: `GET`
- **Response**: A message indicating the start of the real-time data stream.

### 3. Get Historical Price Data
- **URL**: `/api/assets/historical`
- **Method**: `GET`
- **Query Parameters**:
  - `asset`: The symbol of the asset (e.g., `EUR/USD`).
  - `startDate`: The start date for historical data (format: `YYYY-MM-DD`).
  - `endDate`: The end date for historical data (format: `YYYY-MM-DD`).
- **Response**: JSON object containing historical price data.

## WebSocket URI
- **Real-Time Data**: `wss://platform.fintacharts.com`

## Historical API Endpoint
- **Historical Prices**: `https://platform.fintacharts.com/api/historical?symbol={assetSymbol}&startDate={startDate}&endDate={endDate}`

## Environment Configuration
You can set up the Postman environment with the following variables:

```json
{
    "URI": "https://platform.fintacharts.com",
    "USERNAME": "r_test@fintatech.com",
    "PASSWORD": "kisfiz-vUnvy9-sopnyv",
    "TOKEN": "",
    "REFRESH_TOKEN": "",
    "URI_WSS": "wss://platform.fintacharts.com"
}
