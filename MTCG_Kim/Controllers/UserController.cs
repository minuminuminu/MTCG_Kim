using System;
using System.Net;
using System.IO;
using System.Text.Json;

namespace MTCG_Kim.Controllers
{
    internal class UserController
    {
        private HttpListener _listener;
        private string _url;

        public UserController(string url)
        {
            _url = url;
            _listener = new HttpListener();
            _listener.Prefixes.Add(url);
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine($"Listening on {_url}");

            while (true)
            {
                HttpListenerContext context = _listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                switch (request.Url.AbsolutePath)
                {
                    case "/users":
                        if (request.HttpMethod == "POST")
                            RegisterUser(request, response);
                        else if(request.HttpMethod == "GET")
                        {
                            HandleUserOperations(request, response);
                        }
                        break;
                    case "/sessions":
                        if (request.HttpMethod == "POST")
                            LoginUser(request, response);
                        break;
                    default:
                        if (request.HttpMethod == "GET" || request.HttpMethod == "PUT")
                            HandleUserOperations(request, response);
                        break;
                }

                response.Close();
            }
        }

        private void RegisterUser(HttpListenerRequest request, HttpListenerResponse response)
        {
            // Implement user registration logic
            try
            {
                // Your logic here (e.g., checking if the user exists)
                Console.WriteLine("POST REQUEST WAS MADE!");

                response.StatusCode = (int)HttpStatusCode.OK; // 200 status code
                string responseString = "User operation successful.";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);

                response.StatusCode = (int)HttpStatusCode.NotFound; // 404 status code
                string responseString = "User operation failed.";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
            }
        }

        private void LoginUser(HttpListenerRequest request, HttpListenerResponse response)
        {
            // Implement user login logic
        }

        private void HandleUserOperations(HttpListenerRequest request, HttpListenerResponse response)
        {
            try
            {
                // Your logic here (e.g., checking if the user exists)
                Console.WriteLine("GET REQUEST WAS MADE!");

                response.StatusCode = (int)HttpStatusCode.OK; // 200 status code
                string responseString = "User operation successful.";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);

                response.StatusCode = (int)HttpStatusCode.NotFound; // 404 status code
                string responseString = "User operation failed.";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
            }
        }

    }

}

