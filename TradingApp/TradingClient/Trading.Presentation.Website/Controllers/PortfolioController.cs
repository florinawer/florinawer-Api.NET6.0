using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trading.Business.Logic.Interfaces;
using Trading.Common.Dto;
using Trading.Presentation.Website.Models;

namespace Trading.Presentation.Website.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioBl _portfolioLogic;
        private readonly IMapper _mapper;

        public PortfolioController(IPortfolioBl portfolioLogic, IMapper mapper)
        {
            _portfolioLogic = portfolioLogic;
            _mapper = mapper;
        }
        // GET: PortfolioController
        public async Task<ActionResult> Index()
        {
            var result = await _portfolioLogic.GetAll();
            return View(_mapper.Map<IEnumerable<PortfolioViewModel>>(result));

        }

        // GET: PortfolioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PortfolioController/Create
        public async Task<ActionResult> Create(string name, string symbol)
        {
            PortfolioViewModel portfolio = new ();
            portfolio.Stock = new() { Name = name, Symbol = symbol };
            return View(portfolio);
        }

        // POST: PortfolioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(string name, string symbol, [Bind("Amount","BuyPrice","BuyDate")] PortfolioViewModel portfolio)
        {
            try 
            {
                portfolio.Stock = new() { Name = name, Symbol = symbol };
                await _portfolioLogic.Add(_mapper.Map<PortfolioDto>(portfolio));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortfolioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PortfolioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PortfolioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
