using System.Data;
using GalloTube.Interfaces;
using GalloTube.Models;
using MySql.Data.MySqlClient;

namespace GalloTube.Repositories;

public class VideoRepository : IVideoRepository
{
    readonly string connectionString = "server=localhost;port=3306;database=GalloTubedb;uid=root;pwd=''";
    readonly IVideoTagRepository _videotagRepository;

    public VideoRepository(IVideoTagRepository videotagRepository)
    {
        _videoTagRepository = videoTagRepository;
    }


    public void Create(Video model)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "insert into Movie(Title, OriginalTitle, Synopsis, MovieYear, Duration, AgeRating, Image) "
              + "values (@Title, @OriginalTitle, @Synopsis, @MovieYear, @Duration, @AgeRating, @Image)";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Title", model.Title);
        command.Parameters.AddWithValue("@OriginalTitle", model.OriginalTitle);
        command.Parameters.AddWithValue("@Synopsis", model.Synopsis);
        command.Parameters.AddWithValue("@MovieYear", model.MovieYear);
        command.Parameters.AddWithValue("@Duration", model.Duration);
        command.Parameters.AddWithValue("@AgeRating", model.AgeRating);
        command.Parameters.AddWithValue("@Image", model.Image);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void Delete(int? id)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "delete from Movie where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", id);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Video> ReadAll()
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Video";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        
        List<Video> Videos = new();
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Video Video = new()
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("Name"),
                Description = reader.GetString("Description"),
                UploadDate = reader.GetDateTime("UploadDate"),
                Duration = reader.GetInt16("duration"),
                Thumbnail = reader.GetString("thumbnail"),
                videofile = reader.GetString("VideoFile")
            };
            Videos.Add(Video);
        }
        connection.Close();
        return Videos;
    }

    public Video ReadById(int? id)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Video where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", id);
        
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        reader.Read();
        if (reader.HasRows)
        {
            Video Video = new()
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("Name"),
                Description = reader.GetString("Description"),
                UploadDate = reader.GetDateTime("UploadDate"),
                Duration = reader.GetInt16("duration"),
                Thumbnail = reader.GetString("thumbnail"),
                videofile = reader.GetString("VideoFile")
            connection.Close();
            return Video;
        }
        connection.Close();
        return null;
    }

    public void Update(Video model)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "update Movie set "
                        + "Name = @Name, "
                        + "Descripition = @Descripition, "
                        + "UploadDate = @UploadDate, "
                        + "Duration = @Duration, "
                        + "Thumbnail = @thumbnail "
                        + "VideoFile = @videoFile "
                    + "where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", model.Id);
        command.Parameters.AddWithValue("@Title", model.Title);
        command.Parameters.AddWithValue("@OriginalTitle", model.OriginalTitle);
        command.Parameters.AddWithValue("@Synopsis", model.Synopsis);
        command.Parameters.AddWithValue("@MovieYear", model.MovieYear);
        command.Parameters.AddWithValue("@Duration", model.Duration);
        command.Parameters.AddWithValue("@AgeRating", model.AgeRating);
        command.Parameters.AddWithValue("@Image", model.Image);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Video> ReadAllDetailed()
    {
        List<Video> Videos = ReadAll();
        foreach (Video Video in Videos)
        {
            video.Tags = _VideoTagRepository.ReadGenresByMovie(Video.Id);
        }
        return Videos;
    }

    public Video ReadByIdDetailed(int id)
    {
        Video video = ReadById(id);
        video.Tag = _videoTagRepository.ReadTagsByVideo(video.Id);
        return video;
    }
}
