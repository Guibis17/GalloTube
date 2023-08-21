using System.Data;
using GalloTube.Interfaces;
using GalloTube.Models;
using MySql.Data.MySqlClient;

namespace GalloTube.Repositories;

public class VideoTagRepository : IVideoTagRepository
{
    readonly string connectionString = "server=localhost;port=3306;database=GalloFlixdb;uid=root;pwd=''";

    public void Create(int VideoId, byte TagId)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "insert into VideoTag(VideoId, TagId) values (@VideoId, @TagId)";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@VideoId", VideoId);
        command.Parameters.AddWithValue("@TagId", TagId);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void Delete(int VideoId, byte TagId)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "delete from VideoTag where VideoId = @VideoId and TagId = @TagId";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@VideoId", VideoId);
        command.Parameters.AddWithValue("@TagId", TagId);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void Delete(int VideoId)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "delete from VideoTag where TagId = @VideoId";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@VideoId", VideoId);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Tag> ReadTagByVideo(int VideoId)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Tag where id in "
                   + "(select TagId from VideoTag where VideoId = @VideoId)";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@VideoId", VideoId);
        
        List<Tag> Tags = new();
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Tag tag = new()
            {
                Id = reader.GetByte("id"),
                Name = reader.GetString("name")
            };
            Tags.Add(tag);
        }
        connection.Close();
        return Tags;
    }

    public List<VideoTag> ReadVideoTag()
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from VideoTag";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        
        List<VideoTag> videoTags = new();
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            VideoTag videoTag = new()
            {
                VideoId = reader.GetInt32("VideoId"),
                TagId = reader.GetByte("TagId")
            };
            movieGenres.Add(movieGenre);
        }
        connection.Close();
        return movieGenres;
    }

    public List<Movie> ReadMoviesByGenre(byte GenreId)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from movie where id in "
                   + "(select MovieId from moviegenre where GenreId = @GenreId)";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@GenreId", GenreId);
        
        List<Movie> movies = new();
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Movie movie = new()
            {
                Id = reader.GetInt32("id"),
                Title = reader.GetString("title"),
                OriginalTitle = reader.GetString("originalTitle"),
                Synopsis = reader.GetString("synopsis"),
                MovieYear = reader.GetInt16("movieYear"),
                Duration = reader.GetInt16("duration"),
                AgeRating = reader.GetByte("ageRating"),
                Image = reader.GetString("image")
            };
            movies.Add(movie);
        }
        connection.Close();
        return movies;
    }
}
