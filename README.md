

# RestApi

Simple RestApi implementation in c#

ENDPOINTS:

 - [x] GET /api/products
 
```
localhost:XXXXX/api/products
```
 - [x] GET /api/products/{id}
```
localhost:XXXXX/api/products/1
```
 - [x] POST/api/products
```
localhost:XXXXX/api/products
```
   
 - [x] GET/api/pricelists/{id}

```
localhost:XXXXX/api/pricelists/1
```
 - [x] POST/api/pricelists
```
localhost:XXXXX/api/pricelists
```
 - [x] GET /api/prices/evaluate
```
    localhost:XXXXX/api/prices/evaluate?productId=1,2,3,4&currency=NOK,PLN
```

*Currently works for maximum of 4 products and 2 currencies
