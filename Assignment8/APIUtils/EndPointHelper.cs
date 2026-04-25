using Assignment8.Data;
using Assignment8.Models;

namespace Assignment8.APIUtils
{
    public static class EndPointHelper
    {
        public static void MapEndPoints(this WebApplication app)
        {
            app.MapGet("/movies", GetAllMoviesAsync).WithName("GetAllMoviesAsync");
            app.MapGet("/movie/{id:int}", GetMovieByIdAsync).WithName("GetMovieByIdAsync");

            app.MapPost("/movie", PostMovieAsync).WithName("PostMovieAsync");
            app.MapPut("/movie/{id:int}", UpdatedMovie).WithName("Update");
            app.MapDelete("/movie/{id:int}", DeleteMovieAsync).WithName("DeleteMovieAsync");
        }

        public static async Task<IResult> GetAllMoviesAsync(IMovieRepo repo)
        {
            try
            {
                IEnumerable<Movie> movies = await repo.GetAllAsync();
                return Results.Ok(movies);

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> GetMovieByIdAsync(int id, IMovieRepo repo)
        {
            try
            {
                Movie? movie = await repo.GetByIdAsync((int?)id);
                if (movie != null)
                {
                    return Results.Ok(movie);
                }
                else
                {
                    return Results.NotFound();
                }
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        public static async Task<IResult> PostMovieAsync(Movie movie, IMovieRepo repo)
        {
            try
            {

                await repo.AddAsync(movie);
                await repo.Save();

                return Results.Created($"/movie/{movie.Id}", movie);
                //Might need to change this to CreatedAtRoute or something similar to return the created movie with its new ID.
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        public static async Task<IResult> DeleteMovieAsync(int id, IMovieRepo repo)
        {
            try
            {
                Movie? movie = repo.GetByIdAsync(id);
                if (movie != null)
                {
                    repo.RemoveAsync(movie);
                    await repo.Save();

                    return Results.Ok(movie);
                }
                else
                {
                    return Results.NotFound();
                }

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);

            }
        }

        public static async Task<IResult> UpdatedMovie(int id, Movie updatedMovie, IMovieRepo repo)
        {
            try
            {
                Movie? existingMovie = repo.GetByIdAsync(id);

                if (existingMovie == null)
                {
                    return Results.NotFound();
                }

                updatedMovie.Id = id;

                repo.Update(updatedMovie);

                return Results.Ok(updatedMovie);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            }
    }
}
