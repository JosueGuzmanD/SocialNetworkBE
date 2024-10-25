# Arquitectura del Sistema

Este sistema sigue una arquitectura basada en Domain-Driven Design (DDD), con separación en capas y siguiendo los principios SOLID.

## Capas del sistema

1. **Domain**: Representa el núcleo del sistema, contiene las entidades, agregados, Value Objects y servicios de dominio.
2. **Application**: Contiene los servicios de aplicación que gestionan los flujos de trabajo de los casos de uso.
3. **Infrastructure**: Gestión de bases de datos, implementaciones de repositorios y configuraciones relacionadas con la persistencia.
4. **API**: Capa de presentación y API que expone los endpoints para que los usuarios interactúen con el sistema.

### Diagrama de Arquitectura **
