using AHR.Client.ViewModels;
using AIHR.Domain;
using AIHR.Domain.Dtos;
using AIHR.Domain.Dtos.Course;
using AIHR.Domain.Dtos.Student;
using AIHR.Domain.Dtos.StudyPlan;
using AIHR.Domain.Dtos.UsageHistory;
using Microsoft.AspNetCore.Mvc;

namespace AHR.Client.Controllers;

public class CourseController : Controller
{
    private readonly HttpClient _serverHttpClient;

    public CourseController(IHttpClientFactory httpClientFactory)
    {
        _serverHttpClient = httpClientFactory.CreateClient(Constants.AihrServerHttpClientName);
    }

    public async Task<IActionResult> Index(Guid? selectedStudentId, CancellationToken cancellationToken)
    {
        var courses = await _serverHttpClient.GetFromJsonAsync<IEnumerable<CourseDto>>("/api/Course", cancellationToken);
        var coursesVm = courses!
            .Select(course => new CourseIndexViewModel.Course(
                Id: course.Id,
                Name: course.Name,
                Duration: course.Duration,
                Selected: false))
            .ToList();

        var students = (await _serverHttpClient.GetFromJsonAsync<List<Student>>("/api/Student", cancellationToken))!;

        var courseIndexVm = new CourseIndexViewModel(coursesVm, students)
        {
            SelectedStudentId = selectedStudentId ?? Guid.Empty
        };
        
        var errors = TempData[Constants.ErrorsTempDataKey];
        if (errors is not null)
        {
            ModelState.AddModelError("", errors.ToString()!);
        }
        
        return View(courseIndexVm);
    }

    public async Task<IActionResult> GetStudentStudyPlanDetails(Guid studentId, CancellationToken cancellationToken)
    {
        var student = await _serverHttpClient.GetFromJsonAsync<StudentDto>($"/api/Student/{studentId}", cancellationToken);
        if (student is null)
        {
            return NotFound(studentId);
        }

        return PartialView("_StudyPlan", student.StudyPlans);
    }
    
    public async Task<IActionResult> GetStudentUsageHistories(Guid studentId, CancellationToken cancellationToken)
    {
        var usageHistories = await _serverHttpClient.GetFromJsonAsync<List<UsageHistoryDto>>($"/api/UsageHistory/{studentId}", cancellationToken);
        return PartialView("_UsageHistories", usageHistories);
    }
    
    public async Task<IActionResult> Create(CourseIndexViewModel model, CancellationToken cancellationToken)
    {
        CreateStudyPlanDto createStudyPlanDto = GenerateCreateStudyPlanDto();
        HttpResponseMessage httpResponse = await _serverHttpClient.PostAsJsonAsync("api/StudyPlan", createStudyPlanDto, cancellationToken);
        if (httpResponse.IsSuccessStatusCode is false)
        {
            var errorDto = await httpResponse.Content.ReadFromJsonAsync<ErrorDto>(cancellationToken: cancellationToken);
            TempData[Constants.ErrorsTempDataKey] = errorDto?.Error;
        }
        
        return RedirectToAction("Index", new { selectedStudentId = model.SelectedStudentId });

        CreateStudyPlanDto GenerateCreateStudyPlanDto()
        {
            var selectedCourseIds = model.Courses
                .Where(course => course.Selected)
                .Select(course => course.Id);

            return new(model.SelectedStudentId, selectedCourseIds, model.StartDate, model.EndDate, model.AvailableHoursPerDay);
        }
    }

    [HttpDelete("[controller]/[action]/{studyPlanId:int}")]
    public async Task<IActionResult> RemoveStudyPlan(int studyPlanId, CancellationToken cancellationToken)
    {
        HttpResponseMessage httpResponse = await _serverHttpClient.DeleteAsync($"api/StudyPlan/{studyPlanId}", cancellationToken);
        if (httpResponse.IsSuccessStatusCode)
        {
            return Ok();
        }
        
        var error = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        return BadRequest(error);
    }
}