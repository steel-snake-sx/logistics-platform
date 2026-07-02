# Logistics Platform

Logistics Platform is a local microservice playground for order generation, customer data, service discovery, and logistics simulation. The system runs with Docker Compose and uses gRPC, Kafka, and PostgreSQL.

## Services

| Service | Purpose |
| --- | --- |
| `customer-service` | gRPC API for customer data |
| `orders-generator-web` | Order generator for website traffic |
| `orders-generator-mobile` | Order generator for mobile traffic |
| `orders-generator-api` | Order generator for API traffic |
| `service-discovery` | Provides database cluster resources to services |
| `logistic-simulator` | Simulates logistics order state changes |
| `broker-1`, `broker-2` | Kafka brokers |
| `customer-service-db` | PostgreSQL database |

## Requirements

- Docker
- Docker Compose
- .NET 8 SDK for local development without Docker

## Quick Start

```bash
docker compose up --build
```

Useful endpoints after startup:

- `http://localhost:5081` - customer service gRPC endpoint
- `http://localhost:5500` - service discovery HTTP endpoint
- `localhost:29091`, `localhost:29092` - Kafka brokers
- `localhost:5400` - PostgreSQL (`test` / `test`)

Stop the stack:

```bash
docker compose down
```

## Configuration

The services are configured with environment variables in `docker-compose.yml`.

| Variable | Description |
| --- | --- |
| `LOGISTICS_SD_ADDRESS` | Service discovery gRPC address |
| `LOGISTICS_GRPC_PORT` | gRPC port exposed by a service |
| `LOGISTICS_HTTP_PORT` | HTTP port exposed by a service |
| `LOGISTICS_ORDER_SOURCE` | Order source name for a generator |
| `LOGISTICS_KAFKA_BROKERS` | Kafka bootstrap servers |
| `LOGISTICS_ORDER_REQUEST_TOPIC` | Kafka topic for generated orders |
| `LOGISTICS_CUSTOMER_ADDRESS` | Customer service gRPC address |
| `LOGISTICS_DB_STATE` | Database cluster mapping for service discovery |
| `LOGISTICS_UPDATE_TIMEOUT` | Service discovery update interval in seconds |

## Project Structure

```text
src/
  LogisticsPlatform.CustomerService/
  LogisticsPlatform.OrdersGenerator/
  LogisticsPlatform.ServiceDiscovery/
  LogisticsPlatform.LogisticsSimulator/
```

## Development

Build the solution locally:

```bash
dotnet build LogisticsPlatform.sln
```

The repository intentionally ignores IDE caches and build artifacts such as `.vs/`, `.idea/`, `bin/`, and `obj/`.

## License

MIT License. See `LICENSE` for details.
