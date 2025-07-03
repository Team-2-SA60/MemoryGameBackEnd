using MemoryGameBackEnd.data;
using MemoryGameBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MemoryGameBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        // DI
        private readonly MemoryGameBackEndContext _context;
        public AdvertisementController(MemoryGameBackEndContext context)
        {
            _context = context;
        }
        
        // GET: api/Advertisement/{id}
        // To get advertisement by id
        [HttpGet]
        [Route("{id}")]
        public ActionResult<byte[]> GetAdvertisementById(int id)
        {
            Advertisement? advertisement = _context.Advertisements.SingleOrDefault(x => x.Id == id);
            
            if (advertisement == null)
            {
                return NotFound("No advertisement found");
            }
            
            return Ok(advertisement.Image);
        }

        // GET: api/Advertisement/random
        // To get a random advertisement
        [HttpGet]
        [Route("random")]
        public IActionResult GetRandomAdvertisement()
        {
            List<Advertisement> adverts = _context.Advertisements.ToList();

            if (adverts.Count == 0 || adverts.IsNullOrEmpty())
            {
                return NotFound("No advertisement found");
            }

            Advertisement randomAdvert = adverts[new Random().Next(adverts.Count)];

            // return Ok(randomAdvert.Image);
            // return raw PNG bytes
            return File(
                fileContents: randomAdvert.Image,
                contentType: "image/png"
            );
        }

        // POST: api/Advertisement/create
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateAdvertisement(IFormFile image)
        {
            if (image.Length == 0)
            {
                return BadRequest("No file uploaded");
            }
            
            var allowedExtensions = new []{ ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Only .png, .jpg, and .jpeg files are allowed.");
            }

            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            Advertisement advertisement = new Advertisement()
            {
                Image = memoryStream.ToArray(),
            };
            
            _context.Advertisements.Add(advertisement);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(CreateAdvertisement),  new { id = advertisement.Id }, "Created advertisementId: " + advertisement.Id);
        }
    }
}