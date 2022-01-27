using Calculator;
using ExperianChange.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;


namespace ExperianChange.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public ChangeModel change { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            change = new ChangeModel();
        }

        public IActionResult OnPost()
        {
            var calculator = Calculator.Calculator.Create();
            change.ChangeGiven = calculator.getCalculatedChange(change.ProductPrice,change.AmountGiven);
            change.ChangeGiven = $"Change to be  given : "  + change.ChangeGiven;
            return Page();
         
            
        }


    }
}
