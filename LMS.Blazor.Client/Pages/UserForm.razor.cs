using Domain.Models.Entities;
using LMS.Blazor.Client.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LMS.Blazor.Client.Pages;
public partial class UserForm
{
    [Parameter]
    public string Id { get; set; } = string.Empty;
    private UserFormModel UserModel { get; set; } = new();
    private List<Course> AvailableCourses { get; set; } = [];
    private HttpClient Http;

    protected override async Task OnInitializedAsync()
    {
        Http = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7213")
        };
        Console.WriteLine($"HttpClient BaseAddress: {Http.BaseAddress}");
        // Fetch available courses for the dropdown
        // AvailableCourses = await Http.GetFromJsonAsync<List<Course>>("api/courses") ?? new();

        // If editing, fetch the user data
        if (!string.IsNullOrEmpty(Id))
        {
            var user = await Http.GetFromJsonAsync<UserFormModel>($"api/Users/{Id}");
            if (user != null)
            {
                UserModel = user;
            }
        }
    }

    private async Task HandleSubmit()
    {
        if (string.IsNullOrEmpty(Id))
        {
            // Create (POST)
            await Http.PostAsJsonAsync("api/users", UserModel);
        }
        else
        {
            // Edit (PATCH)
            await Http.PatchAsJsonAsync($"api/users/{Id}", UserModel);
        }
        Navigation.NavigateTo("/users"); // Redirect to user list or another page
    }
}
