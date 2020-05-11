using GraphQL;
using System;

namespace GraphQLClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var graphQLClient = new GraphQLRequest
            {
                Query = @"
                    query PersonAndFilms($id: ID) {
                        person(id: $id) {
                            name
                            filmConnection {
                                films {
                                    title
                                }
                            }
                        }
                    }",
                OperationName = "PersonAndFilms",
                Variables = new
                {
                    id = "cGVvcGxlOjE="
                }
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<ResponseType>(personAndFilmsRequest);
        }
    }
}
