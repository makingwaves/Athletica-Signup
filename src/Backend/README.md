# Back-end

Back-end in .NET Core

## Table of contents

- [API](#api)
  - [Contracts](#contracts)
  - [Learning institutions](#learning-institutions)
  - [Memberships](#memberships)
  - [Users](#users)

# API

See [Controllers](./Controllers) folder for implementation details.

## Contracts

```http
GET api/signup/contractsbyinst?instId={id}
```

Returns 200 OK along with a list of the contracts associated with the relevant learning institution ID. `id` may be null, in which case all contracts _not_ associated with a learning institution are returned.

Example response body:

```json
[
  {
    "id": 1002,
    "learningInstitutionId": null,
    "lockInPeriod": false,
    "monthlyFeeNok": 500
  }
]
```

## Learning institutions

```http
GET api/signup/learninginstitutions
```

Returns 200 OK along with a list of all the registered learning institutions.

Example response body:

```json
[
  {
    "id": 1,
    "name": "Universitetet i Oslo"
  },
  {
    "id": 2,
    "name": "Oslomet"
  },
  {
    "id": 3,
    "name": "Arkitektur- og Designhøgskolen i Oslo"
  }
]
```

## Memberships

```http
POST api/signup/memberships
```

Example request body:

```json
{
  "userId": 2,
  "contractId": 2,
  "startDate": "15072020",
  "facilityId": 1234
}
```

Returns 204 No content if successful.

## Users

```http
GET api/signup/users/byphone?phoneNumber={nr}
```

Returns 200 OK along with an object containing the user, a bool indicating whether they are already a member or not, or 404 Not found if the user does not exist.

Example response body:

```json
{
  "user": {
    "id": 1,
    "firstName": "Ola",
    "lastName": "Nordmann",
    "lastPaidStudentFee": "2020V",
    "birthDate": "17052014",
    "learningInstitutionId": 1,
    "email": "mariusgenser@norway.no",
    "phoneNumber": "54321234",
    "address": "Norgegata 47, 1814, Askim",
    "brisId": 1,
    "ssn": "17051453158"
  },
  "isMember": false
}
```

```http
GET api/signup/users/byemail?email={emailAddress}
```

Returns 200 OK along with a User object matching the email address. Example response body:

```json
{
  "id": 1,
  "firstName": "Ola",
  "lastName": "Nordmann",
  "lastPaidStudentFee": "2020V",
  "birthDate": "17052014",
  "learningInstitutionId": 1,
  "email": "mariusgenser@norway.no",
  "phoneNumber": "54321234",
  "address": "Norgegata 47, 1814, Askim",
  "brisId": 1,
  "ssn": "17051453158"
}
```

```http
GET api/signup/users/{id}
```

Returns 200 OK along with a User object with the given id.

```http
GET api/signup/users/byssn?ssn={ssn}
```

Returns 200 OK along with a User object with the given ssn.

```http
POST api/signup/users
```

Creates a user and adds it to the mock database. The 201 response contains the created resource and its URI.
Example request body:

```json
{
  "firstName": "Ola",
  "lastName": "Nordmann",
  "learningInstitutionId": 1,
  "email": "mariusgenser@norway.no",
  "phoneNumber": "54321234",
  "address": "Norgegata 47, 1814, Askim",
  "ssn": "17051453158"
}
```

```http
PUT api/signup/users/{id}
```

```json
{
  "firstName": "Ola",
  "lastName": "Nordmann",
  "learningInstitutionId": 1,
  "email": "mariusgenser@norway.no",
  "phoneNumber": "54321234",
  "address": "Norgegata 47, 1905",
  "ssn": "17051453158"
}
```

Updates the user information in the database. Returns 204 No Content if successful.

```http
PATCH api/signup/users/{id}
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

```http
GET api/signup/users/studentfee?ssn={ssn}
```

Returns 200 OK along with an object containing information about the last paid student fee. Example response body:

```json
{
  "lastPaidStudentFee": "2020V"
}
```

```http
GET api/signup/users/postalcode/{postalcode}
```

Returns a 200 OK along with the city matching the postal code
