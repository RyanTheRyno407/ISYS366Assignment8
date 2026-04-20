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

            //app.MapPost("/movie", PostMovieAsync);
            //app.MapDelete("/movie/{id:int}", DeleteMovieAsync);
        }

        public static async Task<IResult> GetAllMoviesAsync(IMovieRepo repo)
        {
            return Results.Ok(await repo.GetAllAsync());
        }
        public static  async Task<IResult> GetMovieByIdAsync(int id, IMovieRepo repo)
        {
            try 
            { 
                Movie? movie = await repo.GetByIdAsync(id);
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

        public static IResult PostMovieAsync( Movie movie, IMovieRepo repo)
        {
            try
            {
                movie.Id = 0;
                repo.AddAsync(movie);
                return Results.Ok();
            }
            catch (Exception ex) {
                return Results.Problem(ex.Message);
            }

            // AddAsync will be used here from the repo to add a new movie to the database.
        }

        public static IResult DeleteMovieAsync(int id, IMovieRepo repo)
        {
            try
            {
                Movie? movie = repo.GetById(id);
                if (movie != null)
                {
                    repo.RemoveAsync(movie);
                    return Results.Ok();
                }
                else
                {
                    return Results.NotFound();
                }

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
                // RemoveAsync will be used here from the repo to remove a movie from the database.
            }
        }

        //public static IResult PutMovieAsync(Movie movie, IMovieRepo repo)
        //{
        //    try
        //    {
        //        if (repo.(movie))
        //        {
        //            return Results.Ok();
        //        }
        //        return Results.Problem("Can't update movie");
        //    }
        //    catch
        //    {
        //        return Results.NotFound();
        //    }

        //    // UpdateAsync will be used here from the repo to update an existing movie in the database.
        //}

        
    }
}
