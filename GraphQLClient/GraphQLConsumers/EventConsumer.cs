using GraphQL.Common.Request;
using GraphQLClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLClient.GraphQLConsumers
{
    public interface IEventConsumer
    {
        Task<List<DataEvent>> GetDataData();
    }
    public class EventConsumer: IEventConsumer
    {
        private readonly GraphQL.Client.GraphQLClient _client;

        public EventConsumer(GraphQL.Client.GraphQLClient client)
        {
            _client = client;
        }
        public async Task<List<DataEvent>> GetDataData()
        {
            var query = new GraphQLRequest
            {
                Query = @"query
						    { eventMany {
                                routing {
                                    action
                                    entityId
                                }
                            }
                        }"
            };
            var token = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImZaTXdEZ2JDUllpbktDbWdDZjdZUFRPSHpScyIsInR5cCI6IkpXVCIsIng1dCI6ImZaTXdEZ2JDUllpbktDbWdDZjdZUFRPSHpScyJ9.eyJuYmYiOjE1ODkxODg2NjcsImV4cCI6MTU4OTE5MDQ2NywiaXNzIjoiaHR0cHM6Ly9pZG0uZGV2ZWxvcG1lbnQub3BhbDIuY29uZXh1cy5uZXQiLCJhdWQiOlsiaHR0cHM6Ly9pZG0uZGV2ZWxvcG1lbnQub3BhbDIuY29uZXh1cy5uZXQvcmVzb3VyY2VzIiwiY3hEb21haW5JbnRlcm5hbEFwaSJdLCJjbGllbnRfaWQiOiJPcGFsMldlYkFwcCIsImNsaWVudF9wb2xpY3lfaWQiOiJqd3QiLCJzdWIiOiIyMjgxRjFBMi04NDZDLTQyRDYtODQ1QS1FREUxMDdGRkVGQ0MiLCJhdXRoX3RpbWUiOjE1ODkxODg2NjYsImlkcCI6ImxvY2FsIiwiZ2l2ZW5fbmFtZSI6InN5cy1hZG1pbi0wMiIsImVtYWlsIjoic3lzLWFkbWluLTAyQHlvcG1haWwuY29tIiwicm9sZSI6WyJNT0VIUSBDb250ZW50IEFwcHJvdmluZyBPZmZpY2VyIiwiQ291cnNlIFBsYW5uaW5nIENvb3JkaW5hdG9yIiwiQ291cnNlIEFwcHJvdmluZyBPZmZpY2VyIiwiQ29udGVudCBDcmVhdG9yIiwiU3lzdGVtIEFkbWluaXN0cmF0b3IiLCJVc2VyIEFjY291bnQgQWRtaW5pc3RyYXRvciIsIkNvdXJzZSBBZG1pbmlzdHJhdG9yIiwiU2Nob29sIENvbnRlbnQgQXBwcm92aW5nIE9mZmljZXIiLCJXZWIgUGFnZSBFZGl0b3IiLCJDb3Vyc2UgQ29udGVudCBDcmVhdG9yIiwiT1BKIEFwcHJvdmluZyBPZmZpY2VyIiwiTGVhcm5lciIsIlNjaG9vbCBTdGFmZiBEZXZlbG9wZXIiLCJDb3Vyc2UgRmFjaWxpdGF0b3IiXSwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsImN4cHJvZmlsZSIsImN4RG9tYWluSW50ZXJuYWxBcGkiXSwiYW1yIjpbInB3ZCJdfQ.JibqF61ro1aMfU9Q66X5hKkIhHpqBT3VHp6pZxIxehx5j-Xz8qBGjo9hO30VX0sKGXqou96heDtWpo1XfztyTxFpv9BQ2LoDU3o-wrs3COXMXA7RGhz_YUYPlIMBwp44wHT0bkZ-lgRiYQdVrux3Xzox3P7L_rxJIrKJmjKqa682CBDoyqQbG0nmkWdy-VKu2wmzhwHIfPQNi5CTsWsVT7k--QeMiXnJPSqaY11jvgkia6f8oGR4fdAPikOAGmqd3JJrEV-1gFQxuE-IYNlz55WWpKbH6SxpBiCc25g3KIXg6U7n6iQcbCKszoSk7hTlqK7iiq1i57olf7di5Iv8Bg";
            _client.DefaultRequestHeaders.Add("Authorization", $"bearer {token}");
            var response = await _client.PostAsync(query);
            if (response.Data == null)
            {
                return null;
            }

            return response.GetDataFieldAs<List<DataEvent>>("eventMany");
        }

        private List<DataEvent> Json(string v)
        {
            throw new NotImplementedException();
        }
    }
}
