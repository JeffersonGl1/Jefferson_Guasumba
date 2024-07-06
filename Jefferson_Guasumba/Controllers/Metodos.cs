using ChoETL;
using Dapper;
using Jefferson_Guasumba.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using System.Net.WebSockets;
using System.Threading;

namespace Jefferson_Guasumba.Controllers
{

    public class Metodos
    {

        private IConfiguration _config;


        public Metodos()
        {
            _config = new ConfigurationBuilder()
         .AddJsonFile("appsettings.json")
         .Build();

        }

        public async Task<string> ListarTareas()
        {


            string jsonString = "";



            using var conn = new SqlConnection(_config.GetConnectionString("ReadWriteConnection"));




            try
            {
                await conn.OpenAsync();

                var res = await conn.QueryAsync("Select *from Tareas", commandType: System.Data.CommandType.Text);

                IDataReader reader = res.AsDataReader();

                var dt = new DataTable();

                dt.Load(reader);

                jsonString = JsonConvert.SerializeObject(dt);



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();

            }



            return jsonString;







        }



        public async Task<bool> RegistrarTarea(Tarea tarea)
        {

            bool valor = false;

            using var conn = new SqlConnection(_config.GetConnectionString("ReadWriteConnection"));

            await conn.OpenAsync();


            try
            {
                await conn.QueryAsync("Insert into Tareas(Titulo, Descripcion, FechaCreacion, FechaVencimiento, Completada) " +
                    "values (@Titulo, @Descripcion, @FechaCreacion, @FechaVencimiento, @Completada) ", new
                    {
                        tarea.Titulo,
                        tarea.Descripcion,
                        tarea.FechaCreacion,
                        tarea.FechaVencimiento,
                        tarea.Completada
                    }, commandType: System.Data.CommandType.Text);

                valor = true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();

            }



            return valor;



        }


        public async Task<bool> ModificarTarea(Tarea tarea)
        {

            bool valor = false;

            using var conn = new SqlConnection(_config.GetConnectionString("ReadWriteConnection"));

            await conn.OpenAsync();


            try
            {
                await conn.QueryAsync("Update Tareas set Titulo = @Titulo, Descripcion = @Descripcion, FechaCreacion = @FechaCreacion, FechaVencimiento = @FechaVencimiento," +
                    " Completada = @Completada Where Id = @Id", new
                    {
                        tarea.Id,
                        tarea.Titulo,
                        tarea.Descripcion,
                        tarea.FechaCreacion,
                        tarea.FechaVencimiento,
                        tarea.Completada
                    }, commandType: System.Data.CommandType.Text);

                valor = true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();

            }



            return valor;



        }


        public async Task<bool> EliminarTarea(int idTarea)
        {

            bool valor = false;

            using var conn = new SqlConnection(_config.GetConnectionString("ReadWriteConnection"));

            await conn.OpenAsync();


            try
            {
                await conn.QueryAsync("Delete from Tareas Where Id = @Id", new
                {
                    Id = idTarea
                }, commandType: System.Data.CommandType.Text);

                valor = true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();

            }



            return valor;



        }

        public async Task<string> LoginUsuario(string usuario, string password)
        {

            string valor = "";

            using var conn = new SqlConnection(_config.GetConnectionString("ReadWriteConnection"));

            await conn.OpenAsync();


            try
            {
                var res = await conn.QueryAsync("select *from Usuarios where Usuario = @Usuario and Passwrd = @Pass ", new
                {
                    Usuario = usuario,
                    Pass = password
                }, commandType: CommandType.Text);


                IDataReader reader = res.AsDataReader();

                var dt = new DataTable();

                dt.Load(reader);


                valor = JsonConvert.SerializeObject(dt);



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();

            }



            return valor;



        }




    }
}