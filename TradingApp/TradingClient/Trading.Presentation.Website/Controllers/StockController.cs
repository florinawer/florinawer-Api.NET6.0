using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trading.Business.Logic.Interfaces;
using Trading.Common.Dto;
using Trading.Common.Dto.Pagination;
using Trading.Presentation.Website.Models;
using Trading.Presentation.Website.Models.Pagination;

namespace Trading.Presentation.Website.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockBl _stockLogic;
        private readonly IMapper _mapper;

        public StockController(IStockBl stockLogic, IMapper mapper)
        {
            _stockLogic = stockLogic;
            _mapper = mapper;
        }

        // GET: StockController
        public async Task<ActionResult> Index([Bind("PageNumber", "PageSize")] PaginationFilterViewModel paginationFilter)
        {
            var result = await _stockLogic.GetAll(_mapper.Map<PaginationFilterDto>(paginationFilter));
            return View(_mapper.Map<PagedResponseViewModel<IEnumerable<StockViewModel>>>(result));

        }

        // GET: StockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: StockController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StockController/Edit/5
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

        // GET: StockController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StockController/Delete/5
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
