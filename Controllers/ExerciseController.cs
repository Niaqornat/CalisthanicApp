using Microsoft.AspNetCore.Mvc;
using CalisthenicsApp.Interfaces;
using CalisthenicsApp.Models;
using CalisthenicsApp.ViewModels;

namespace CalisthenicsApp.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExerciseController(IExerciseRepository exerciseRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _exerciseRepository = exerciseRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Exercise> Exercises = await _exerciseRepository.GetAll();
            return View(Exercises);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Exercise Exercises = await _exerciseRepository.GetByIdAsync(id);
            return View(Exercises);
        }

        public IActionResult Create()
        {
            var curUserID = _httpContextAccessor.HttpContext?.User.GetUserId();
            var createExerciseViewModel = new CreateExerciseViewModel { AppUserId = curUserID };
            return View(createExerciseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseViewModel exerciseVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(exerciseVM.Image);

                var exercise = new Exercise
                {
                    Title = exerciseVM.Title,
                    Description = exerciseVM.Description,
                    Image = result.Url.ToString(),
                    AppUserId = exerciseVM.AppUserId,
                    Address = new Address
                    {
                        Street = exerciseVM.Address.Street,
                        City = exerciseVM.Address.City,
                        State = exerciseVM.Address.State,
                    }
                };
                _exerciseRepository.Add(exercise);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(exerciseVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            if (exercise == null) return View("Error");
            var clubVM = new EditExerciseViewModel
            {
                Title = exercise.Title,
                Description = exercise.Description,
                AddressId = exercise.AddressId,
                Address = exercise.Address,
                URL = exercise.Image,
                RaceCategory = exercise.ExerciseCategory
            };
            return View(clubVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditExerciseViewModel exerciseVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", exerciseVM);
            }

            var userRace = await _exerciseRepository.GetByIdAsyncNoTracking(id);

            if (userRace != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userRace.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(exerciseVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(exerciseVM.Image);


                var exercise = new Exercise
                {
                    Id = id,
                    Title = exerciseVM.Title,
                    Description = exerciseVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = exerciseVM.AddressId,
                    Address = exerciseVM.Address,
                };

                _exerciseRepository.Update(exercise);

                return RedirectToAction("Index");
            }
            else
            {
                return View(exerciseVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var clubDetails = await _exerciseRepository.GetByIdAsync(id);
            if (clubDetails == null) return View("Error");
            return View(clubDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var exerciseDetails = await _exerciseRepository.GetByIdAsync(id);
            if (exerciseDetails == null) return View("Error");

            _exerciseRepository.Delete(exerciseDetails);
            return RedirectToAction("Index");
        }
    }
}
