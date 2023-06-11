using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TestTask.Web.Exceptions;
using TestTask.Web.Models;
using TestTask.Web.Services;

namespace TestTask.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var order = await orderService.GetSingleOrder();
                return View(order);
            }
            catch(NotFoundException)
            {
                ModelState.AddModelError(String.Empty, "Order wasn't found");
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Error while loading data");
            }
            return View(new OrderModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var order = await orderService.UpdateSingleOrder(model);
                return View(order);
            }
            catch (NotFoundException)
            {
                ModelState.AddModelError(String.Empty, "Order wasn't found");
            }
            catch (BadRequestException)
            {
                ModelState.AddModelError(String.Empty, "Wrong data was sent");
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Error while saving data");
            }

            return View(model);
        }
    }
}
