using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LMSServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LMSServices" in both code and config file together.
    public class LMSServices : ILMSServices
    {
        public string GetMessage(string StudentName)
        {
            return "The name of the Student is " + StudentName;
        }

        public string Hello()
        {
            return "Hello world";
        }


        public List<Genre> GetAllGenre()
        {

            SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Genre", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Genre> genres = new List<Genre>();
            while (reader.Read())
            {
                Genre genre = new Genre();
                genre.GenreID = int.Parse(reader["GenreId"].ToString());
                genre.GenreName = reader["GenreName"].ToString();

                genres.Add(genre);
            }

            con.Close();
            return genres;
        }


        //Used for detail and delete carrying id
        public Genre GetGenre(int id)
        {
            SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT GenreID, GenreName FROM Genre WHERE GenreID = @GenreID", con);
            cmd.Parameters.AddWithValue("@GenreID", id);
            SqlDataReader reader = cmd.ExecuteReader();

            Genre genre = new Genre();

            if (reader.Read())
            {
                genre.GenreID = int.Parse(reader["GenreID"].ToString());
                genre.GenreName = reader["GenreName"].ToString();
            }

            con.Close();
            return genre;
        }



        public int DeleteGenre(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Genre WHERE GenreID = @GenreID", con);
                cmd.Parameters.AddWithValue("@GenreID", id);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CreateGenre(Genre genrePara)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                con.Open();
                //SqlCommand cmd = new SqlCommand("INSERT INTO Genre (GenreID, GenreName) VALUES (@GenreID, @GenreName) ", con);
                //cmd.Parameters.AddWithValue("@GenreID", genrePara.GenreID);
                //cmd.Parameters.AddWithValue("@GenreName", genrePara.GenreName);

                SqlCommand cmd = new SqlCommand("INSERT INTO Genre (GenreName) VALUES (@GenreName) ", con);
                cmd.Parameters.AddWithValue("@GenreName", genrePara.GenreName);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }




        public int EditGenre(Genre genrePara)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Genre SET GenreName = @GenreName WHERE GenreID = @GenreID ", con);
                cmd.Parameters.AddWithValue("@GenreID", genrePara.GenreID);
                cmd.Parameters.AddWithValue("@GenreName", genrePara.GenreName);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }





        public List<Music> GetAllMusic()
        {

            SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT mu.MusicID, mu.MusicName, ge.GenreID AS genreID, ge.GenreName AS genreName FROM Music mu INNER JOIN Genre ge On mu.GenreID = ge.GenreID", con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Music> musics = new List<Music>();
            while (reader.Read())
            {
                Music music = new Music();
                music.MusicID = int.Parse(reader["MusicID"].ToString());
                music.MusicName = reader["MusicName"].ToString();

                Genre genre = new Genre();
                genre.GenreID = int.Parse(reader["genreID"].ToString());
                genre.GenreName = reader["genreName"].ToString();
                music.Genre = genre;

                musics.Add(music);
            }

            con.Close();
            return musics;
        }


        //Used for detail and delete carrying id
        public Music GetMusic(int id)
        {
            SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT MusicID, MusicName FROM Music WHERE MusicID = @MusicID", con);
            cmd.Parameters.AddWithValue("@MusicID", id);
            SqlDataReader reader = cmd.ExecuteReader();

            Music music = new Music();

            if (reader.Read())
            {
                music.MusicID = int.Parse(reader["MusicID"].ToString());
                music.MusicName = reader["MusicName"].ToString();
            }

            con.Close();
            return music;
        }



        public int DeleteMusic(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Music WHERE MusicID = @MusicID", con);
                cmd.Parameters.AddWithValue("@MusicID", id);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CreateMusic(Music musicPara)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Music (MusicName, GenreID) VALUES (@MusicName, @GenreID) ", con);
                cmd.Parameters.AddWithValue("@MusicName", musicPara.MusicName);
                cmd.Parameters.AddWithValue("@GenreID", musicPara.GenreID);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }




        public int EditMusic(Music musicPara)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Database=MusicDB;Trusted_Connection=True;MultipleActiveResultSets=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Music SET MusicName = @MusicName, GenreID = @GenreID WHERE MusicID = @MusicID ", con);
                //SqlCommand cmd = new SqlCommand("UPDATE Music SET MusicName = @MusicName WHERE MusicID = @MusicID ", con);
                cmd.Parameters.AddWithValue("@MusicID", musicPara.MusicID);
                cmd.Parameters.AddWithValue("@MusicName", musicPara.MusicName);
                cmd.Parameters.AddWithValue("@GenreID", musicPara.GenreID);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
