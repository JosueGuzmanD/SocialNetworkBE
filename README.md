# **Project: Football Social Network**

## **Description**

This social network is focused on the **organization and management of football matches**. Players can create profiles, form teams, organize matches, reserve football fields, interact with each other through posts and comments, and view personal and team statistics.

The system adheres to **Domain-Driven Design (DDD)** principles, where the football domain is well-represented through entities, Value Objects, and domain services that handle business logic. The system also implements patterns like **Aggregates** to manage related entities, and **Value Objects** to encapsulate behaviors and immutable values.

## **Technology Stack**

- **Back-end**: .NET 8 (ASP.NET Core)
- **Database**: SQL Server
- **Front-end (future)**: Blazor WebAssembly

## **Main Features**

- **Player Registration**: Users can create player profiles and customize their information, including positions and favorite roles.
- **Match and Booking Management**: Players can organize football matches and book football fields for their games.
- **Posts and Results**: Players can announce matches and share results through posts and comments.
- **Player and Team Statistics**: Detailed statistics for individual players and teams, including match history, goals, and wins.

## **Usage** _(Coming Soon)_

- **Register a Player**: `POST /api/register`
- **Create a Match**: `POST /api/matches`
- **Book a Football Field**: `POST /api/bookings`

## **Documentation**

For more information about the system's architecture, workflows, and technical details, please refer to the [complete documentation](docs/index.md).

---

## **Documentation Overview**

The following sections outline the complete documentation available for the project.

### **1. System Overview**

This document provides an in-depth look at how the system operates, including its main components and high-level architecture.

[View System Overview](./docs/system-overview.md)

---

### **2. Design Patterns and Principles**

The project follows key design principles like **Domain-Driven Design (DDD)** and **SOLID principles**, ensuring that the system is maintainable, scalable, and well-structured. The architecture is built around the football domain, with a focus on clean separation of concerns, aggregates, and value objects.

- **Domain-Driven Design (DDD)**: Football-related concepts are represented through entities like `Player`, `Match`, `Team`, and `FootballField`.
- **SOLID Principles**: Each part of the system adheres to principles such as Single Responsibility, Open/Closed, and Dependency Inversion.

[View Design Patterns and Principles](./docs/design-patterns-and-principles.md)

---

### **3. Entities and Relationships**

The main domain entities, their properties, and their relationships are fully documented in this section. This includes key entities like `Player`, `Match`, `FootballField`, `Booking`, and `Post`.

#### **Entities Covered**:

- **Player**: Represents football players, including attributes like name, email, favorite positions, and stats.
- **Match**: Encapsulates all match-related details like the start time, field, and participating players.
- **Team**: Represents teams, either recurrent or formed for a specific match.
- **FootballField**: Details the field where matches are played, including address, capacity, and type.
- **Booking**: Manages field reservations for matches.
- **Post**: Allows players to announce matches or share results.
- **Friendship**: Handles social connections between players.
- **MatchStats**: Captures match statistics, such as goals and performance.

[View Entities and Relationships](./docs/entities-and-relationships.md)

---

### **4. Core Workflows**

This section describes the **core workflows** that power the system's functionality, from match management to booking fields and team creation.

#### **Main Workflows**:

- **Match Management**: How players create, invite others to, and manage football matches.
- **Booking Management**: How fields are reserved and bookings are managed, including cancellations.
- **Post Management**: How players can create posts to announce matches or share results.
- **Team Management**: How players form teams, invite others, and manage team stats.

[View Core Workflows](./docs/core-workflows.md)

---
