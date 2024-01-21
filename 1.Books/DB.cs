using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Books
{

    public static class Queries
    {
        public static string addNewBookQuery = @"INSERT INTO Books(Id,Name,Pages,YearPress,Id_Themes, Id_Category, Id_Author, Id_Press, Comment, Quantity)
                                                 VALUES(@id,@name,@pages,@yearPress,@id_themes,@idCategory,@idAuthor,@idPress,@comment,@quantity)";
    }

    public static class DB
    {

        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;";
        public static List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();


                string query = "SELECT * FROM Books";

                using (var cmd = new SqlCommand(query, conn))
                {

                    var reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        var book = new Book
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Pages = (int)reader["Pages"],
                            YearPress = (int)reader["YearPress"],
                            Id_Themes = (int)reader["Id_Themes"],
                            Id_Category = (int)reader["Id_Category"],
                            Id_Author = (int)reader["Id_Author"],
                            Id_Press = (int)reader["Id_Press"],
                            //Comment = (string)reader["Comment"],
                            Quantity = (int)reader["Quantity"]
                        };

                        books.Add(book);
                    }

                }

            }
            return books;
        }

        public static int addNewBook(Book b)
        {
            int affectedRows = 0;

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(Queries.addNewBookQuery, conn))
                {


                    var idParam = new SqlParameter();
                    idParam.ParameterName = "@id";
                    idParam.Value = b.Id;
                    idParam.SqlDbType = System.Data.SqlDbType.Int;

                    var nameParam = new SqlParameter();
                    nameParam.ParameterName = "@name";
                    nameParam.Value = b.Name;
                    nameParam.SqlDbType = System.Data.SqlDbType.NVarChar;

                    var pagesParam = new SqlParameter();
                    pagesParam.ParameterName = "@pages";
                    pagesParam.Value = b.Pages;
                    pagesParam.SqlDbType = System.Data.SqlDbType.Int;

                    var yearPressParam = new SqlParameter();
                    yearPressParam.ParameterName = "@yearPress";
                    yearPressParam.Value = b.YearPress;
                    yearPressParam.SqlDbType = System.Data.SqlDbType.Int;

                    var id_themesParam = new SqlParameter();
                    id_themesParam.ParameterName = "@id_themes";
                    id_themesParam.Value = b.Id_Themes;
                    id_themesParam.SqlDbType = System.Data.SqlDbType.Int;

                    var idCategoryParam = new SqlParameter();
                    idCategoryParam.ParameterName = "@idCategory";
                    idCategoryParam.Value = b.Id_Category;
                    idCategoryParam.SqlDbType = System.Data.SqlDbType.Int;


                    var idAuthorParam = new SqlParameter();
                    idAuthorParam.ParameterName = "@idAuthor";
                    idAuthorParam.Value = b.Id_Author;
                    idAuthorParam.SqlDbType = System.Data.SqlDbType.Int;

                    var idPressParam = new SqlParameter();
                    idPressParam.ParameterName = "@idPress";
                    idPressParam.Value = b.Id_Press;
                    idPressParam.SqlDbType = System.Data.SqlDbType.Int;

                    var commentParam = new SqlParameter();
                    commentParam.ParameterName = "@comment";
                    commentParam.Value = b.Comment;
                    commentParam.SqlDbType = System.Data.SqlDbType.NVarChar;

                    var quantityParam = new SqlParameter();
                    quantityParam.ParameterName = "@quantity";
                    quantityParam.Value = b.Quantity;
                    quantityParam.SqlDbType = System.Data.SqlDbType.Int;

                    cmd.Parameters.Add(idParam);
                    cmd.Parameters.Add(nameParam);
                    cmd.Parameters.Add(pagesParam);
                    cmd.Parameters.Add(yearPressParam);
                    cmd.Parameters.Add(id_themesParam);
                    cmd.Parameters.Add(idCategoryParam);
                    cmd.Parameters.Add(idAuthorParam);
                    cmd.Parameters.Add(idPressParam);
                    cmd.Parameters.Add(commentParam);
                    cmd.Parameters.Add(quantityParam);
                    

                    affectedRows = cmd.ExecuteNonQuery();
                }
            }

            return affectedRows;
        }   


    }
}
