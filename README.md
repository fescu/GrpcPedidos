# GrpcPedidos proyecto final poli

# Participantes

Andres Felipe Escudero Gutierrez
William Andres Dussan Gonzalez

![CI](https://github.com/fescu/GrpcPedidos/actions/workflows/ci.yml/badge.svg)
[![codecov](https://codecov.io/gh/fescu/GrpcPedidos/branch/main/graph/badge.svg)](https://codecov.io/gh/fescu/GrpcPedidos)

Proyecto de ejemplo utilizando **.NET 8**, **gRPC** y **MongoDB** para gestionar pedidos. Funcionalidaes de insertar y listar 
Incluye integración continua con **GitHub Actions**, ejecución de pruebas unitarias y reporte de cobertura utilizando **Codecov**.

---

## 📌 Características principales

- API implementada con **gRPC**.
- Arquitectura por capas:
  - **Core** → Entidades y contratos.
  - **Application** → Casos de uso y servicios.
  - **Infrastructure** → Acceso a datos en **MongoDB**.
  - **Presentation** → Servidor gRPC.
- Pruebas unitarias con **xUnit** + **Moq**.
- Cobertura automática enviada a **Codecov**.
- Construcción y ejecución con **Docker** y **Docker Compose**.

---

## 🗂️ Estructura del proyecto
GrpcPedidos/
│
├── Src/
│ ├── GrpcPedidos.Core
│ ├── GrpcPedidos.Application
│ ├── GrpcPedidos.Infrastructure
│ └── GrpcPedidos.Api (gRPC Server)
│
├── GrpcPedidos.Tests/ → Pruebas unitarias
│
├── Dockerfile
├── docker-compose.yml
└── README.md


---

## 🧪 Ejecutar pruebas unitarias con paquete de xunit

Desde la raíz del proyecto de net core:

bash
dotnet test

dotnet test --collect:"XPlat Code Coverage"


---

## Ejecucion de docker
docker build -t grpc-pedidos .

## Comando de docker compose
docker compose up -d

## Detener el docker compose
docker compose down






