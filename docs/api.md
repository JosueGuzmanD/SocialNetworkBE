# Documentación de la API

Esta sección describe los principales endpoints de la API expuesta por la aplicación.

## Endpoints

### **Autenticación**

- `POST /api/register`: Registra un nuevo jugador en el sistema.
    - **Body**:
      ```json
      {
        "name": "John Doe",
        "email": "john@example.com",
        "password": "Password123"
      }
      ```
    - **Response**:
      ```json
      {
        "token": "jwt-token"
      }
      ```

- `POST /api/login`: Autentica a un jugador existente y devuelve un token JWT.
    - **Body**:
      ```json
      {
        "email": "john@example.com",
        "password": "Password123"
      }
      ```

...

### **Partidos**

- `POST /api/matches`: Crea un nuevo partido.
    - **Body**:
      ```json
      {
        "fieldId": "1234-5678",
        "startTime": "2024-11-01T10:00:00",
        "createdById": "abcd-efgh"
      }
      ```
    - **Response**:
      ```json
      {
        "matchId": "wxyz-1234"
      }
      ```

...

