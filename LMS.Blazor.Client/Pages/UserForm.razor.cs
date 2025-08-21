using Domain.Models.Entities;
using LMS.Blazor.Client.Models;
using LMS.Blazor.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LMS.Blazor.Client.Pages;
public partial class UserForm
{
    [Parameter]
    public string Id { get; set; } = string.Empty;
    public UserFormModel UserModel { get; set; } = new();
    private List<Course> AvailableCourses { get; set; } = [];
    [Inject]
    private IApiService ApiService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        // Fetch available courses for the dropdown
        // AvailableCourses = await Http.GetFromJsonAsync<List<Course>>("api/courses") ?? new();

        AvailableCourses.Add(new Course()
        {
            Id = 0,
            Name = "C#",
            Description = "Dolorem dolorem id quaerat quas incidunt iure numquam voluptatem.",
            StartDate = DateTime.Now
        });

        AvailableCourses.Add(new Course()
        {
            Id = 1,
            Name = ".NET",
            Description = "dwadawdwadwa,ldwadad wawa wawadwadw awadwadwadwadwad",
            StartDate = DateTime.Now
        });

        // If editing, fetch the user data
        if (!string.IsNullOrEmpty(Id))
        {
            var user = await ApiService.GetUserByIdAsync(Id);
            if (user != null)
                UserModel = user;
        }
    }

    private void HandleCourseSelectionChange(ChangeEventArgs e)
    {
        if (e.Value is string[] selectedValues)
        {
            UserModel.SelectedCourseIds = [.. selectedValues.Select(int.Parse)];
            Console.WriteLine($"SelectedCourseIds: {string.Join(", ", UserModel.SelectedCourseIds)}");
        }
    }

    private async Task HandleSubmit()
    {
        if (string.IsNullOrEmpty(Id))
        {
            // Create (POST)
            await ApiService.CreateUserAsync(UserModel);
        }
        else
        {
            // Edit (PATCH)
            await ApiService.PatchAsJsonAsync(Id, UserModel);
        }
        //Navigation.NavigateTo("/users"); // Redirect to user list or another page
    }
}
