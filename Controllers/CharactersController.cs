using System.Linq;
using Microsoft.AspNet.Mvc;
using MyWebApp.Interfaces;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        // GET: /characters/
        public IActionResult Index()
        {
            var characters = _characterRepository.ListAll();
            if (!characters.Any())
            {
                _characterRepository.Add(new Character("Darth Maul"));
                _characterRepository.Add(new Character("Darth Vader"));
                _characterRepository.Add(new Character("Yoda"));
                _characterRepository.Add(new Character("Mace Windu"));
                characters = _characterRepository.ListAll();
            }

            return View(characters);
        }
    }
}