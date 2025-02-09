using Microsoft.AspNetCore.Mvc;
using CalisthenicsApp.Interfaces;
using CalisthenicsApp.Models;
using CalisthenicsApp.Repository;
using CalisthenicsApp.Services;
using CalisthenicsApp.ViewModels;

namespace CalisthenicsApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IPhotoService _photoService;

        public UserController(IUserRepository userRepository, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _photoService = photoService;
        }
        [HttpGet("users")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Pace = user.Pace,
                    Mileage = user.Mileage,
                    ProfileImageUrl = user.ProfileImageUrl,
                };
                result.Add(userViewModel);
            }
            return View(result);
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetUserData(int page = 1, int pageSize = 10)
        {
            var users = _userRepository.GetPagedUsers(page, pageSize);  // Sayfalı veriyi çekiyoruz
            var totalUsers = _userRepository.GetTotalUsers();  // Toplam kullanıcı sayısını alıyoruz

            var data = new
            {
                draw = Request.Query["draw"],  // DataTables'ın gönderdiği draw parametresi
                recordsTotal = totalUsers,  // Toplam kullanıcı sayısı
                recordsFiltered = totalUsers,  // Toplam kullanıcı sayısı (filtreleme yapılmadığı için aynı)
                data = users  // Sayfa başına veriler
            };
            return Json(data);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPagedUsers(int draw, int start, int length)
        {
            try
            {
                // Sayfalama işlemi
                var totalUsers = await _userRepository.GetTotalUsers(); // Toplam kullanıcı sayısını al
                var users = await _userRepository.GetPagedUsers(start / length, length); // Sayfa başına verileri getir

                var result = new
                {
                    draw = draw, // DataTables'dan gelen draw parametresi
                    recordsTotal = totalUsers, // Toplam kullanıcı sayısı
                    recordsFiltered = totalUsers, // Filtrelenmiş kullanıcı sayısı (Burada filtreleme yapılmadığı için aynı)
                    data = users.Select(user => new
                    {
                        profileImage = user.ProfileImageUrl, // Profil resminin URL'si
                        userName = user.UserName, // Kullanıcı adı
                        mileage = user.Mileage, // Kullanıcının kilometresi
                        pace = user.Pace, // Kullanıcının hızı
                        actions = "<a href='/User/Detail/" + user.Id + "' class='btn btn-sm btn-outline-secondary'>View</a>" // Görüntüleme butonu
                    }).ToList() // Verileri listeye dönüştür
                };

                return Json(result); // JSON formatında geri döndür
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya mesaj verme
                return Json(new { error = ex.Message });
            }
        }




        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Pace = user.Pace,
                Mileage = user.Mileage,
                ProfileImageUrl = user.ProfileImageUrl,
            };
            return View(userDetailViewModel);
        }












    }
}
