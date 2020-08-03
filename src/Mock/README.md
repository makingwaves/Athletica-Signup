# Mock Exceline API

## Table of contents

- [How to set up](#how-to-set-up)
- [Tables](#tables)
  - [Users](#users)
    - [Endpoints](#endpoints)
  - [Contracts](#contracts)
    - [Semantics for contract objects](#semantics-for-contract-objects)
    - [Endpoints](#endpoints-1)
  - [Memberships](#memberships)
    - [Endpoints](#endpoints-2)
  - [Learning institutions](#learning-institutions)
    - [Endpoints](#endpoints-3)
  - [Bris users](#bris-users)
    - [Endpoints](#endpoints-4)
  - [Facilities](#facilities)
    - [Endpoints](#endpoints-5)

## How to set up

1. Install [Docker](https://www.docker.com/get-started)
2. Run the following command

```bash
docker run -d --name MockServer -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD={A very secret password}' -p 1500:1433 mcr.microsoft.com/mssql/server:2019-latest
```

To check that the server is up and running, run

```bash
docker ps
```

3. If running `dotnet ef` gives you a Not found error, run

```bash
dotnet tool install --global dotnet-ef
```

4. To add your password to user secrets, run

```bash
dotnet user-secrets init
dotnet user-secrets set DbPassword {The very secret password}
```

Check that it worked:

```bash
dotnet user-secrets list
```

5. To create the database, run

```bash
dotnet ef database update
```

# Tables

## Users

### Endpoints

```http
GET /api/mock/users
```

Returns a 200 OK response containing a list of all users

```http
GET /api/mock/users/{id}
```

Returns a 200 OK response containing the `User` resource with the given id if it exists (404 Not Found if not).

```http
POST /api/mock/users
```

Creates a new `User` resource. The 201 response contains the created resource and its URI.
Example body:

```json
{
  "name": "Kari Nordmann",
  "lastPaidStudentFee": "2020V",
  "birthDate": "01012000",
  "learningInstitutionId": 1,
  "email": "local-part@domain.com",
  "phoneNumber": "12345678",
  "address": "Street Avenue 23, 0123, Cityville"
}
```

```http
PUT /api/mock/users/{id}
```

Replaces the resource at `id` with the resource in the request body. The response is 204 No Content if successful. If there is no resource at `id`, the response is 404 Not Found.
Example body:

```json
{
  "name": "Kari Nordmann",
  "lastPaidStudentFee": "2020V",
  "birthDate": "01012000",
  "learningInstitutionId": 1,
  "email": "local-part@domain.com",
  "phoneNumber": "12345678",
  "address": "Street Avenue 23, 0123, Cityville"
}
```

```http
PATCH /api/mock/users/{id}
```

Changes the specified attributes of the user with id `id`. The response is 204 No Content if successful.
Example request body:

```json
[
  {
    "op": "replace",
    "path": "/LastName",
    "value": "Nordmann"
  }
]
```

This patch object would change the last name of the user to "Nordmann" and leave everything else unchanged.

```http
DELETE /api/mock/users/{id}
```

Deletes the user with id `id` and responds with 204 No Content.

## Contracts

### Semantics for contract objects

All except `lockInPeriod` should be self-explanatory.

```json
{
  ...
  "lockInPeriod": 0
  ...
}
```

````json
{
  ...
  "lockInPeriod": 0
  ...
}

```json
{
  ...
  "lockInPeriod": 0
  ...
}
````

### Endpoints

```http
GET /api/mock/contracts
```

Returns a 200 OK response containing a list of all contracts

```http
GET /api/mock/contracts/{id}
```

Returns a 200 OK response containing the `Contract` resource with the given id if it exists (404 Not Found if not).

```http
POST /api/mock/contracts
```

Creates a new `Contract` resource. The 201 response contains the created resource and its URI.
Example body:

```json
{
  "learningInstitutionId": 1,
  "lockInPeriod": 1,
  "monthlyFeeNok": 175,
  "pdf": "Not implemented"
}
```

```http
PUT /api/mock/contracts/{id}
```

Replaces the resource at `id` with the resource in the request body. The response is 204 No Content if successful. If there is no resource at `id`, the response is 404 Not Found.
Example body:

```json
{
  "learningInstitutionId": 1,
  "lockInPeriod": 2,
  "monthlyFeeNok": 175,
  "pdf": "Not implemented"
}
```

```http
PATCH /api/mock/contracts/{id}
```

Changes the specified attribute of the user with id `id`. The response is 204 No Content if successful.
Example request body:

```json
[
  {
    "op": "replace",
    "path": "/pdf",
    "value": "Will look into this today"
  }
]
```

This patch object would change the pdf string of the contract to "Will look into this today" and leave everything else unchanged.

```http
DELETE /api/mock/contracts/{id}
```

Deletes the contract with id `id` and responds with 204 No Content.

## Memberships

### Endpoints

```http
GET /api/mock/memberships
```

Returns a 200 OK response containing a list of all memberships

```http
GET /api/mock/memberships/{id}
```

Returns a 200 OK response containing the `Membership` resource with the given id if it exists (404 Not Found if not).

```http
POST /api/mock/memberships
```

Creates a new `Membership` resource. The 201 response contains the created resource and its URI.
Example body:

```json
{
  "userId": 15,
  "contractId": 2,
  "startDate": "08072020",
  "agressoId": null
}
```

```http
PUT /api/mock/memberships/{id}
```

Replaces the resource at `id` with the resource in the request body. The response is 204 No Content if successful. If there is no resource at `id`, the response is 404 Not Found.
Example body:

```json
{
  "userId": 15,
  "contractId": 2,
  "startDate": "08072020",
  "agressoId": null
}
```

```http
PATCH /api/mock/memberships/{id}
```

Changes the specified attribute of the user with id `id`. The response is 204 No Content if successful.
Example request body:

```json
[
  {
    "op": "replace",
    "path": "/startDate",
    "value": "01012001"
  }
]
```

This patch object would change the start date of the membership to "01012001" and leave everything else unchanged.

```http
DELETE /api/mock/memberships/{id}
```

Deletes the membership with id `id` and responds with 204 No Content.

## Learning institutions

### Endpoints

```http
GET /api/mock/learninginstitutions
```

Returns a 200 OK response containing a list of all learning institutions

```http
GET /api/mock/learninginstitutions/{id}
```

Returns a 200 OK response containing the `LearningInstitution` resource with the given id if it exists (404 Not Found if not).

```http
POST /api/mock/learninginstitutions
```

Creates a new `LearningInstitution` resource. The 201 response contains the created resource and its URI.
Example body:

```json
{
  "name": "University of the World"
}
```

```http
PUT /api/mock/learninginstitutions/{id}
```

Replaces the resource at `id` with the resource in the request body. The response is 204 No Content if successful. If there is no resource at `id`, the response is 404 Not Found.
Example body:

```json
{
  "name": "University of the World"
}
```

```http
PATCH /api/mock/learninginstitutions/{id}
```

Changes the specified attribute of the user with id `id`. The response is 204 No Content if successful.
Example request body:

```json
[
  {
    "op": "replace",
    "path": "/name",
    "value": "University of Nowhere"
  }
]
```

This patch object would change the name of the resource to "University of Nowhere" and leave everything else unchanged.

```http
DELETE /api/mock/learninginstitutions/{id}
```

Deletes the learning institution with id `id` and responds with 204 No Content.

## Bris users

### Endpoints

```http
GET /api/mock/brisusers
```

Returns a 200 OK response containing a list of all BRIS users

```http
GET /api/mock/brisusers/{id}
```

Returns a 200 OK response containing the `BrisUser` resource with the given id if it exists (404 Not Found if not).

## Facilities

The locations that are registered when a new membership is created (e.g. Athletica Domus).

### Endpoints

```http
GET /api/mock/facilities
```

Returns a 200 OK response containing a list of all facilities. Example facility JSON object:

```json
{
  "id": 1, // Internal database ID
  "facilityId": 1234, // Official facility ID
  "name": "Athletica Domus" // Name
}
```
