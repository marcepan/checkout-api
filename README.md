# checkout-api

## About solution
Solution uses:
- SQL Serve DB (file)
- [Entity Framework](https://github.com/aspnet/EntityFramework) as ORM
- [AutoFac](https://github.com/autofac/Autofac) for Dependency Injection
- [OAuth2](https://oauth.net/2/) for authentication
- MS Unit Test with Moq

## Avaiable routes

`GET` - `/api/drinks` - gets list of all drinks from basket

`GET` - `/api/drink/{name}` - gets drink by the name

`DELETE` - `/api/drink/{name}` - deletes drink by the name

`POST` - `/api/drink` - adds new drink to basket

`PUT` - `/api/drink/{name}` - updates quantity for particular drink

## Authentication

Proposed solution uses OAuth to authenticate user needs to generate register and after that generates token.

`POST` - `api/account/register` - registers new user, request needs payload as follows:
```
{
  "username" : "username",
  "password" : "password",
  "confirmpassword" : "password"
}
```

To generate token user can use endpoint:

`POST` - `api/token` - with header:
```
Content-Type:application/x-www-form-urlencoded
grant_type:password
username:user
password:password
```
