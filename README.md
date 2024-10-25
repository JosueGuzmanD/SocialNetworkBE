# Proyecto: Red Social de Fútbol

## Descripción

Esta red social está centrada en la organización y gestión de partidos de fútbol. Los jugadores pueden crear perfiles, formar equipos, organizar partidos, reservar campos de fútbol, interactuar entre ellos a través de publicaciones y comentarios, y consultar estadísticas personales y de sus equipos.

El sistema sigue los principios de Domain-Driven Design (DDD), donde el dominio del fútbol está bien representado mediante entidades, Value Objects, y servicios de dominio que gestionan la lógica de negocio. El sistema también implementa patrones como agregados para gestionar entidades relacionadas y Value Objects para encapsular comportamientos y valores inmutables.

## Stack Tecnológico
- **Back-end**: .NET 8 (ASP.NET Core)
- **Base de Datos**: SQL Server
- **Front-end** (futuro): Blazor WebAssembly

## Características Principales
- **Registro de jugadores**
- **Gestión de partidos y reservas**
- **Publicaciones y resultados**
- **Estadísticas de jugadores y equipos**

## Uso *SOON*
- Crear un usuario: `POST /api/register`
- Crear un partido: `POST /api/matches`
- Reservar un campo: `POST /api/bookings`

## Documentación
Para obtener más información sobre la arquitectura del sistema, flujos de trabajo y detalles técnicos, consulta la [documentación completa](docs/index.md).
