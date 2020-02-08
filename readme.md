# Url Shortener

"Url Shortener" is URL shortening service and a link management platform.

![](https://img.shields.io/github/stars/keshavarz13/url-shortener.svg) 
![](https://img.shields.io/github/forks/keshavarz13/url-shortener.svg) 
![](https://img.shields.io/github/issues/keshavarz13/url-shortener.svg)

## Build

### Build migration
Use the flowing commands to setup database migration.

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add $migration_name
dotnet ef database update
```

### Run project
Use the flowing command to run project.

```bash
cd .\shortener\
dotnet run 
```
Now listening on: [http://localhost:5000](http://localhost:5000)

### Run tests
Use the flowing command to run project.

```bash
cd .\shortener.test\
dotnet test
```

## Usage
for create a short url use this curl command: 
```b
 curl --location --request POST 'http://localhost:5000/urls' \
--header 'Content-Type: application/json' \
--data-raw '{
               "LongUrl" : "$LongUrl
            }'
```
for redirect to long url:
```b
curl --location --request GET "http://localhost:5000/redirect/$ShortUrl" 
```


## َAuthors
created by [MohammadAli Keshavarz](https://github.com/keshavarz13)