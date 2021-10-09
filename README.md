# h94type

 This project is a simple word memorization app
 
 `dotnet ef migrations add migrationName`

 `dotnet ef database update`

 `dotnet watch run`
 
 ##  Requirements

 - Postgresql
 - .Net 5

 ## 3rd Party Libraries

- EntityFramework
- FluentValidation
- Automapper
- Swagger

# Endpoints

## Genres
| Method | Endpoint                | Desc                                                     |
| -----------|-------------------------|----------------------------------------------------------|
| GET | /api/Genres| Get genres
| POST | /api/Genres| Create genre 
| DELETE | /api/Genres| Delete genre  
| GET | /api/Genres/Search/id/{id}| Get by genre id                            
| PUT | /api/Genres/{id}| Update genre       
| GET | /api/Genres/Search/Name/{name}| Get by genre name

## Texts
| Method | Endpoint                | Desc                                                     |
| -----------|-------------------------|----------------------------------------------------------|
| GET  | /api/Texts| Get texts
| POST | /api/Texts| Create text 
| DELETE | /api/Texts| Delete text  
| GET | /api/Texts/Search/id/{id}| Get by text id                            
| PUT | /api/Texts/{id}| Update text
| GET | /api/Texts/Search/word/{word}| Get by text word
| GET | /api/Texts/Search/GenreName/{genreName}| Get texts by genre name 
| GET | /api/Texts/Search/GenreNameAndStarly/{genreName}| Get texts by genre name and starly  