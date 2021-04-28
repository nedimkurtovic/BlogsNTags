# Blogs N Tags

Simple API for blogs n' tags with CRUD operations. Using slugs for blog URI identification. When creating blogs it adds new tags if they don't exist in database.
It supports https with dotnet dev certificate.

## Testing

There are several ways you can test out application.
You can run the project locally using IIS or open the BlogsNTags.API\BlogsNTags.API folder and run the following command

```bash
dotnet run --project ./BlogsNTags.API.csproj
```

Follow the links in browser to test out application using swagger. The migrations and seed data are applied automatically.

## Docker

You can also test out application using docker by navigating to "BlogsNTags.API" folder (not BlogsNTags.API\BlogsNTags.API) and running the following:

```bash
docker-compose build
docker-compose up
```

If certain ports are being used on your machine, you can map different ones in docker-compose.yml file
