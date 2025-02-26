using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Threading;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

[Binding]
public class ApiStepDefinitions
{
    private RestClient client;
    private RestResponse response;

    public ApiStepDefinitions()
    {
        client = new RestClient("http://dummy.restapiexample.com/api/v1/");
    }

    [Given(@"I call the employees API")]
    public void GivenICallTheEmployeesAPI()
    {
        var request = new RestRequest("employees", Method.Get);
        request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/133.0.0.0 Safari/537.36");
        request.AddHeader("Cookie", "humans_21909=1");
        response = ExecuteRequestWithRetry(request);
    }

    [Then(@"I verify that employee ""(.*)"" has a salary of (.*)")]
    public void ThenIVerifyEmployeeSalary(string employeeName, int expectedSalary)
    {
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "API response was not successful.");

        JObject jsonResponse = JObject.Parse(response.Content);
        Console.WriteLine($"Scenario 1: ....... {jsonResponse}");
        JToken employee = jsonResponse["data"].FirstOrDefault(e => e["employee_name"].ToString() == employeeName);
        Assert.IsNotNull(employee, $"Employee '{employeeName}' was not found.");
        Assert.AreEqual(expectedSalary, (int)employee["employee_salary"], "Salary does not match.");
        
    }

    [Given(@"I call the employee API for ID (.*)")]
    public void GivenICallTheEmployeeAPIForID(int employeeId)
    {
        var request = new RestRequest($"employee/{employeeId}", Method.Get);
        request.AddHeader("Cookie", "humans_21909=1");
        response = ExecuteRequestWithRetry(request);
    }

    [Then(@"I verify the response is valid")]
    public void ThenIVerifyTheResponseIsValid()
    {
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "API response was not successful.");
        JObject jsonResponse = JObject.Parse(response.Content);
        Console.WriteLine($"Scenario 2: ....... {jsonResponse}");
        Assert.IsNotNull(jsonResponse["data"], "Response data is null.");
        Assert.IsNotNull(jsonResponse["data"].ToString(), "Response data is empty.");
    }

    private RestResponse ExecuteRequestWithRetry(RestRequest request)
    {
        int retryCount = 10;
        for (int i = 0; i < retryCount; i++)
        {

            var response = client.Execute(request);
            Console.WriteLine($"Received 429 Too Many Requests. Retrying in 2 seconds... ({i + 1}/{retryCount})");
            Console.WriteLine($"Response Code..... ({response.StatusCode})");
            if (response.StatusCode == (HttpStatusCode)200) return response; // Success or another failure
            Thread.Sleep(2000);
        }
        return client.Execute(request);
    }
}
